
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Infrastructure;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    public class ImportXmlController : Controller
    {

        string temp = ""; // todo delete this line

        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImportXmlController(IUnitOfWork unitOfWork,
                                   IHostingEnvironment hostingEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("path")]
        public async Task<ActionResult> path()
        {
            return Ok(_hostingEnvironment.ContentRootPath);
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            StreamReader rd = new StreamReader("C:\\projects\\AppData2.xml", System.Text.Encoding.UTF8);
            string fullText = rd.ReadToEnd();
            XmlSerializer ser = new XmlSerializer(typeof(_Dictionary));

            using (TextReader reader = new StringReader(fullText))
            {
                _Dictionary dic = (_Dictionary)ser.Deserialize(reader);

                foreach (_Root root in dic.Roots)
                {
                    temp = root.RootWord; // todo: delete this line
                    InsertRecords(root);
                }
            }

            return Ok("Sounds good!");
        }



        private int InsertRecords(_Root root)
        {
            string fileLoc = _hostingEnvironment.ContentRootPath + @"\";

            int categoryId = InsertSekaniCategory(root.Category);
            int formId = InsertSekaniForm(root.Form);
            int levelId = InsertSekaniLevel(root.Level.ToString());

            SekaniRoot sr = new SekaniRoot()
            {
                SekaniLevelId = levelId,
                RootWord = !String.IsNullOrEmpty(root.RootWord) ? root.RootWord : "",
                SekaniFormId = formId,
                SekaniCategoryId = categoryId,
                IsNull = root.IsNull,
                UpdateTime = DateTime.Now
            };

            int sekaniRootId = InsertSekaniRoot(sr);

            try
            {
                int SekaniRootImageId = InsertSekaniRootImage(fileLoc + @"Image\" + root.Image, sekaniRootId);
            }
            catch (NullReferenceException)
            {
                // no image
            }
            catch (DirectoryNotFoundException)
            {
                //todo rivisit later.
            }
            catch (FileNotFoundException)
            {
                // file does not exist
            }


            // insert EnglishWord records
            try
            {
                var englishWords = root.EnglishWords.Select(x => x.EnglishWord).ToList();
                IEnumerable<int> EnglishWordIds = InsertBulkEnglishWords(englishWords);
                // insert SekaniRoot_EnglishWords records.
                foreach (int engwId in EnglishWordIds)
                {
                    var rec = _unitOfWork.SekaniRootsEnglishWords.Find(x => x.SekaniRootId == sekaniRootId && x.EnglishWordId == engwId).Count();
                    if (rec == 0)
                    {
                        SekaniRootEnglishWord srew = new SekaniRootEnglishWord()
                        {
                            SekaniRootId = sekaniRootId,
                            EnglishWordId = engwId,
                            UpdateTime = DateTime.Now,
                        };
                        _unitOfWork.SekaniRootsEnglishWords.Add(srew);
                        _unitOfWork.Complete();
                    }
                }
            }
            catch (NullReferenceException)
            {
                // no english words associated.
            }


            // insert Topics
            try
            {
                var topics = root.Topics.Select(x => x.Title).ToList();
                IEnumerable<int> topicIds = InsertBulkTopics(topics);
                foreach (int tId in topicIds)
                {
                    var rec = _unitOfWork.SekaniRootsTopics.Find(x => x.SekaniRootId == sekaniRootId && x.TopicId == tId).Count();
                    if (rec == 0)
                    {
                        SekaniRootTopic srt = new SekaniRootTopic()
                        {
                            SekaniRootId = sekaniRootId,
                            TopicId = tId,
                            UpdateTime = DateTime.Now
                        };
                        _unitOfWork.SekaniRootsTopics.Add(srt);
                        _unitOfWork.Complete();
                    }
                }
            }
            catch (NullReferenceException)
            {
                // no topics associated
            }
            catch(InvalidOperationException)
            {
                // when the topic tag exists but there's nothing inside it/.
            }

            foreach (I_F_Element elm in root.InflectedForms)
            {
                SekaniWord sw = new SekaniWord()
                {
                    Phonetic = elm.Phonetic,
                    SekaniRootId = sekaniRootId,
                    UpdateTime = DateTime.Now,
                    Word = elm.InflectedForm
                };
                int sekaniWordId = InsertSekaniWord(sw);

                try
                {
                    int SekaniWordAudioId = InsertSekaniWordAudio(fileLoc + @"Audio\" + elm.Audio, sekaniWordId);
                }
                catch (NullReferenceException)
                {
                    // no audio
                }
                catch(FileNotFoundException)
                {
                    // file does not exist
                }

                foreach (I_F_Example ex in elm.Examples)
                {
                    SekaniWordExample swe = new SekaniWordExample()
                    {
                        English = ex.English,
                        Sekani = ex.Sekani,
                        SekaniWordId = sekaniWordId,
                        UpdateTime = DateTime.Now
                    };
                    int sekaniWordExampleId = InsertSekaniWordExample(swe);

                    try
                    {
                        int SekaniWordExampleAudioId = InsertSekaniWordExampleAudio(fileLoc + @"Audio\" + ex.Audio, sekaniWordExampleId);
                    }
                    catch (NullReferenceException)
                    {
                        // no audio
                    }
                    catch (FileNotFoundException)
                    {
                        // file does not exist
                    }
                }

                foreach (I_F_Attribute att in elm.Attributes)
                {
                    SekaniWordAttribute swa = new SekaniWordAttribute()
                    {
                        SekaniWordId = sekaniWordId,
                        Key = att.Key,
                        Value = att.Value,
                        UpdateTime = DateTime.Now
                    };
                    int SekaniWordAttributeId = InsertSekaniWordAttribute(swa);
                }
            }

            return 0;
        }

        // insert SekaniRootImage
        private int InsertSekaniRootImage(string fileAddress, int SekaniRootId)
        {
            try
            {
                var theFile = System.IO.File.ReadAllBytes(fileAddress);
                SekaniRootImage sri = new SekaniRootImage()
                {
                    SekaniRootId = SekaniRootId,
                    Content = theFile,
                    Notes = "",
                    Format = "PNG",
                    UpdateTime = DateTime.Now
                };
                _unitOfWork.SekaniRootImages.Add(sri);
                _unitOfWork.Complete();
                return sri.Id;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        // insert SekaniWordExampleAudio
        private int InsertSekaniWordExampleAudio(string fileAddress, int SekaniWordExampleId)
        {
            try
            {
                var theFile = System.IO.File.ReadAllBytes(fileAddress);
                SekaniWordExampleAudio swea = new SekaniWordExampleAudio()
                {
                    SekaniWordExampleId = SekaniWordExampleId,
                    Format = "MP3",
                    Notes = "",
                    Content = theFile,
                    UpdateTime = DateTime.Now
                };

                _unitOfWork.SekaniWordExampleAudios.Add(swea);
                _unitOfWork.Complete();
                return swea.Id;
            }
            catch
            {
                return -1;
            }
        }

        // insert sekaniWordAudio 
        private int InsertSekaniWordAudio(string fileAddress, int SekaniWordId)
        {
            // assuming database is empty
            // todo: what if it is not empty? or the file does not exist.
            try
            {
                var theFile = System.IO.File.ReadAllBytes(fileAddress);
                SekaniWordAudio swa = new SekaniWordAudio()
                {
                    SekaniWordId = SekaniWordId,
                    Content = theFile,
                    Format = "MP3",
                    UpdateTime = DateTime.Now,
                    Notes = ""
                };

                _unitOfWork.SekaniWordAudios.Add(swa);
                _unitOfWork.Complete();
                return swa.Id;
            }
            catch(FileNotFoundException)
            {
                return -1;
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

        private int InsertSekaniWordAttribute(SekaniWordAttribute attribute)
        {
            var att = _unitOfWork.SekaniWordAttributes.Find(x => x.SekaniWordId == attribute.SekaniWordId && x.Key == attribute.Key && x.Value == attribute.Value).FirstOrDefault();
            if (att != null)
                return att.Id;

            _unitOfWork.SekaniWordAttributes.Add(attribute);
            _unitOfWork.Complete();
            return attribute.Id;
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
            foreach (string w in words)
            {
                try
                {
                    int id = InsertEnglishWord(w);
                    Ids.Add(id);
                }
                catch(InvalidOperationException)
                {
                    
                    var s = Ids;
                    int x = 4;
                }

                // todo :  clean up
                
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
        /*private SekaniRoot ExtractSekaniRootObj(JObject obj)
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
        }*/
    }

    #region XmlClasses

    [XmlRoot("dictionary")]
    public class _Dictionary
    {
        [XmlElement("root")]
        public List<_Root> Roots { get; set; }
    }

    public class _Root
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("gloss")]
        public string Gloss { get; set; }

        [XmlElement("form")]
        public string Form { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("level")]
        public int Level { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("isNull")]
        public bool IsNull { get; set; }

        [XmlElement("rootword")]
        public string RootWord { get; set; }

        [XmlElement("EnglishWords")]
        public List<_EnglishWord> EnglishWords { get; set; }

        [XmlElement("topics")]
        public List<_Topic> Topics { get; set; }

        [XmlArray("inflectedforms"), XmlArrayItem("element")]
        public I_F_Element[] InflectedForms;
        //[XmlElement("inflectedforms")]
       // public List<I_F_Element> InflectedForms { get; set; }


    }

    [XmlType("element")]
    public class I_F_Element
    {

        [XmlElement("inflectedform")]
        public string InflectedForm { get; set; }
        [XmlElement("phonetic")]
        public string Phonetic { get; set; }

        [XmlElement("inflectedformtranslation")]
        public string InflectedFormTranslation { get; set; }

        [XmlElement("audio")]
        public string Audio { get; set; }
        [XmlArray("examples"), XmlArrayItem("element")]
        public I_F_Example[] Examples;

        //[XmlElement("examples")]
        //public List<I_F_Example> Examples { get; set; }

        [XmlArray("attributes"), XmlArrayItem("element")]
        public I_F_Attribute[] Attributes;

        //[XmlElement("attributes")]
        //public List<I_F_Attribute> Attributes { get; set; }


    }

    //public class I_F_SubElement
    //{
    //    [XmlElement("inflectedform")]
    //    public string InflectedForm { get; set; }

    //    [XmlElement("phonetic")]
    //    public string Phonetic { get; set; }

    //    [XmlElement("inflectedformtranslation")]
    //    public string InflectedFormTranslation { get; set; }

    //    [XmlElement("audio")]
    //    public string Audio { get; set; }

    //    [XmlElement("examples")]
    //    public List<I_F_Example> Examples { get; set; }

    //    [XmlElement("attributes")]
    //    public List<I_F_Attribute> Attributes { get; set; }
    //}

    public class I_F_Example
    {

        [XmlElement("sekani")]
        public string Sekani { get; set; }

        [XmlElement("english")]
        public string English { get; set; }

        [XmlElement("audio")]
        public string Audio { get; set; }
        //[XmlElement("element")]
        //public I_F_SubExample Example { get; set; }
    }

    //public class I_F_SubExample
    //{
    //    [XmlElement("sekani")]
    //    public string Sekani { get; set; }

    //    [XmlElement("english")]
    //    public string English { get; set; }

    //    [XmlElement("audio")]
    //    public string Audio { get; set; }
    //}

    public class I_F_Attribute
    {
        //[XmlElement("element")]
        //public I_F_SubAttribute Attribute { get; set; }
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }

    //public class I_F_SubAttribute
    //{
    //    [XmlElement("key")]
    //    public string Key { get; set; }

    //    [XmlElement("value")]
    //    public string Value { get; set; }
    //}

    public class _Topic
    {
        [XmlElement("title")]
        public string Title { get; set; }
    }

    public class _EnglishWord
    {
        [XmlElement("EnglishWord")]
        public string EnglishWord { get; set; }
    }

    #endregion



}
