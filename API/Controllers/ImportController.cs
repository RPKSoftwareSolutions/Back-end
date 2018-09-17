using AuthServer.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using DomainModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ImportController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImportController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("do")]
        public ActionResult Do()
        {
            StreamReader read = new StreamReader("C:\\projects\\Sekani\\convertjson.json");
            string str = read.ReadToEnd();
            JObject total = JObject.Parse(str);
            JArray arr = (JArray)total["dic"]["root"];

            Iterate(arr);
            return Ok();
            //
        }

        //
        private void Iterate(JArray roots)
        {
            foreach(JObject r in roots)
            {
                // insert the category
                var category = r["category"].Value<string>();
                int CategoryId = InsertSekaniCategory(category);

                // insert the form
                var form = r["form"].Value<string>();
                int FormId = InsertSekaniForm(form);

                // insert the level
                var level = r["level"].Value<string>();
                int LevelId = InsertSekaniLevel(level);

                // insert the sekaniRoot and fetch the Id for further data work
                SekaniRoot sekaniRoot = ExtractSekaniRootObj(r);
                int SekaniRootId = InsertSekaniRoot(sekaniRoot);

                // insert EnglishWords
                try
                {
                    var englishWords = r["EnglishWords"]["EnglishWord"].Values<string>();
                    IEnumerable<int> EnglishWordIds = InsertBulkEnglishWords(englishWords);
                    // insert SekaniRoot_EnglishWords records.
                    foreach (int engwId in EnglishWordIds)
                    {
                        var rec = _unitOfWork.SekaniRoots_EnglishWords.Find(x => x.SekaniRootId == SekaniRootId && x.EnglishWordId == engwId).Count();
                        if (rec == 0)
                        {
                            SekaniRoot_EnglishWord srew = new SekaniRoot_EnglishWord()
                            {
                                SekaniRootId = SekaniRootId,
                                EnglishWordId = engwId,
                                UpdateTime = DateTime.Now,
                            };
                            _unitOfWork.SekaniRoots_EnglishWords.Add(srew);
                            _unitOfWork.Complete();
                        }
                    }
                    
                }
                catch(NullReferenceException)
                {
                    // no english word associated with the root
                }

                // insert the topics
                try
                {
                    var topics = r["topics"]["title"].Values<string>();
                    IEnumerable<int> TopicIds = InsertBulkTopics(topics);
                    // insert SekaniRoot_Topics records
                    foreach (int tId in TopicIds)
                    {
                        var rec = _unitOfWork.SekaniRoots_Topics.Find(x => x.SekaniRootId == SekaniRootId && x.TopicId == tId).Count();
                        if (rec == 0)
                        {
                            SekaniRoot_Topic srt = new SekaniRoot_Topic()
                            {
                                SekaniRootId = SekaniRootId,
                                TopicId = tId,
                                UpdateTime = DateTime.Now
                            };
                            _unitOfWork.SekaniRoots_Topics.Add(srt);
                            _unitOfWork.Complete();
                        }
                    }
                    
                }
                catch (NullReferenceException)
                {
                    // no topics associated with the root
                }


                // TODO*: This piece is currently specifically developed for the first batch, where every root is "generic" and there is only one inflected form.
                // for the other root types, there needs to be a loop in here....

                SekaniWord sw = new SekaniWord()
                {
                    SekaniRootId = SekaniRootId,
                    Phonetic = "",
                    UpdateTime = DateTime.Now,
                    Word = r["inflectedforms"]["element"]["inflectedform"].Value<string>()
                };

                // insert the inflectedForm
                int sekaniWordId = InsertSekaniWord(sw);

                // TODO*: Same loop thing for examples here. For some reason in the first batch there is only one example for each inflected form at most.

                try
                {
                    SekaniWordExample swe = new SekaniWordExample()
                    {
                        English = r["inflectedforms"]["element"]["examples"]["element"]["english"].Value<string>(),
                        Sekani = r["inflectedforms"]["element"]["examples"]["element"]["sekani"].Value<string>(),
                        SekaniWordId = sekaniWordId,
                        UpdateTime = DateTime.Now
                    };

                    int SekaniWordExampleId = InsertSekaniWordExample(swe);
                }
                catch (NullReferenceException)
                {
                    // In case there is no examples.
                }
            }
        }

        // this method takes a SekaniWord and inserts it
        private int InsertSekaniWord(SekaniWord word)
        {
            var sw = _unitOfWork.SekaniWords.Find(x => x.SekaniRootId == word.SekaniRootId && x.Word == word.Word).FirstOrDefault();
            if (sw != null)
                return sw.Id;

            _unitOfWork.SekaniWords.Add(word);
            _unitOfWork.Complete();
            return word.Id;
        }

        private int InsertSekaniWordExample(SekaniWordExample example)
        {
            var sw = _unitOfWork.SekaniWordExamples.Find(x => x.SekaniWordId == example.SekaniWordId && x.Sekani == example.Sekani && x.English == example.English).FirstOrDefault();
            if (sw != null)
                return sw.Id;

            _unitOfWork.SekaniWordExamples.Add(example);
            _unitOfWork.Complete();
            return example.Id;
        }

        // this method takes a Topic and inserts it into the DB only if it does not already exist
        private int InsertTopic(string topic)
        {
            var T = _unitOfWork.Topics.Find(x => String.Equals(x.Title.ToLower(), topic.ToLower())).FirstOrDefault();
            if (T != null)
                return T.Id;

            Topic t = new Topic()
            {
                Title = topic,
                UpdateTime = DateTime.Now
            };
            _unitOfWork.Topics.Add(t);
            _unitOfWork.Complete();
            return t.Id;
        }

        private IEnumerable<int> InsertBulkTopics(IEnumerable<string> topics)
        {
            List<int> Ids = new List<int>();
            foreach (string t in topics)
            {
                int id = InsertTopic(t);
                Ids.Add(id);
            }
            return Ids;
        }

        // this method takes a category and inserts it into the DB only if it does not already exist
        private int InsertSekaniCategory(string category)
        {
            var C = _unitOfWork.SekaniCategories.Find(x => String.Equals(x.Title.ToLower(), category.ToLower())).FirstOrDefault();
            if (C != null)
                return C.Id;

            SekaniCategory sc = new SekaniCategory()
            {
                Title = category,
                UpdateTime = DateTime.Now
            };
            _unitOfWork.SekaniCategories.Add(sc);
            _unitOfWork.Complete();
            return sc.Id;
        }

        // this method takes a Form and and inserts it only if it does not already exist in Db
        private int InsertSekaniForm(string form)
        {
            var F = _unitOfWork.SekaniForms.Find(x => String.Equals(x.Title.ToLower(), form.ToLower())).FirstOrDefault();
            if (F != null)
                return F.Id;

            SekaniForm sf = new SekaniForm()
            {
                Title = form,
                UpdateTime = DateTime.Now
            };
            _unitOfWork.SekaniForms.Add(sf);
            _unitOfWork.Complete();
            return sf.Id;
        }

        // this method takes a Level and inserts it only if it does not already exist in Db
        private int InsertSekaniLevel(string level)
        {
            var L = _unitOfWork.SekaniLevels.Find(x => String.Equals(x.Title.ToLower(), level.ToLower())).FirstOrDefault();
            if (L != null)
                return L.Id;

            SekaniLevel sl = new SekaniLevel()
            {
                Title = level,
                UpdateTime = DateTime.Now
            };
            _unitOfWork.SekaniLevels.Add(sl);
            _unitOfWork.Complete();
            return sl.Id;
        }

        //this method takes an EnglishWord and inserts it in the Db if it does not already exist
        private int InsertEnglishWord(string word)
        {
            var W = _unitOfWork.EnglishWords.Find(x => String.Equals(x.Word.ToLower(), word.ToLower())).FirstOrDefault();
            if (W != null)
                return W.Id;

            EnglishWord w = new EnglishWord()
            {
                Standard = true,
                Word = word,
                UpdateTime = DateTime.Now
            };
            _unitOfWork.EnglishWords.Add(w);
            _unitOfWork.Complete();
            return w.Id;
        }

        private IEnumerable<int> InsertBulkEnglishWords(IEnumerable<string> words)
        {
            List<int> Ids = new List<int>();
            foreach(string w in words)
            {
                int id = InsertEnglishWord(w);
                Ids.Add(id);
            }
            return Ids;
        }

        // this method Inserts a SekaniRoot object in database and returns its assigned ID
        private int InsertSekaniRoot(SekaniRoot obj)
        {
            var root = _unitOfWork.SekaniRoots.Find(x => String.Equals(x.RootWord.ToLower(), obj.RootWord.ToLower())).FirstOrDefault();
            if (root != null)
                return root.Id;

            SekaniRoot sr = new SekaniRoot()
            {
                IsNull = obj.IsNull,
                RootWord = obj.RootWord,
                SekaniCategoryId = obj.SekaniCategoryId,
                SekaniFormId = obj.SekaniFormId,
                SekaniLevelId = obj.SekaniLevelId,
                UpdateTime = DateTime.Now
            };
            _unitOfWork.SekaniRoots.Add(sr);
            _unitOfWork.Complete();
            return sr.Id;
        }

        // This method extracts a SekaniRoot object out of one entity.
        private SekaniRoot ExtractSekaniRootObj(JObject obj)
        {
            int formId = _unitOfWork.SekaniForms.Find(x => String.Equals(x.Title, obj["form"].Value<string>())).FirstOrDefault().Id;
            int categoryId = _unitOfWork.SekaniCategories.Find(x => String.Equals(x.Title, obj["category"].Value<string>())).FirstOrDefault().Id;
            int levelId = _unitOfWork.SekaniLevels.Find(x => String.Equals(x.Title, obj["level"].Value<string>())).FirstOrDefault().Id;
            SekaniRoot sr = new SekaniRoot()
            {
                RootWord = obj["rootword"].Value<string>(),
                IsNull = obj["isNull"].Value<bool>(),
                UpdateTime = DateTime.Now,
                SekaniFormId = formId,
                SekaniCategoryId = categoryId,
                SekaniLevelId = levelId
            };

            return sr;
        }

        

        ///
        /// The EnglishWords nods are inconsistent, also the "standard" flag is missing.
        ///
    }

    
}
