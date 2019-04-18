using API.ParamModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure;


namespace API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]

    public class DataImportController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment hostingEnvironment;

        public DataImportController(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("ImportData")]
        public void ImportData()
        {
            var path = hostingEnvironment.WebRootPath + "\\files\\";
            var createdFiles = Directory.GetFiles(path);

            var xmlFile = createdFiles.SingleOrDefault(x => x.Contains(".xml"));

            if (xmlFile == null)
            {
                throw new Exception("Xml file not found! please Upload xml file and try again!");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary));
            using (FileStream fileStream = new FileStream(xmlFile, FileMode.Open))
            {
                var result = (Dictionary)serializer.Deserialize(fileStream);

                AddCategories(result);
                var sekaniRootList = unitOfWork.SekaniRoots.GetAll().ToList().Select(a => a.RootWord);
                var persistRoots = result.Roots.Where(a => !sekaniRootList.Contains(a.Rootword));
                var categoryList = unitOfWork.SekaniCategories.GetAll().ToList();
                AddForms(result);
                var sekaniFormList = unitOfWork.SekaniForms.GetAll().ToList();
                var sekaniLevelList = unitOfWork.SekaniLevels.GetAll().ToList();
                AddTopics(result);
                var sekaniTopicsList = unitOfWork.Topics.GetAll().ToList();
                AddEnglishWords(result);
                var englishWordList = unitOfWork.EnglishWords.GetAll().ToList();

                List<SekaniRoot> sekaniRoots = new List<SekaniRoot>();
                Parallel.ForEach(persistRoots, root =>
                {


                    var sekaniRoot = new SekaniRoot
                    {
                        //Id = root.Id,
                        IsNull = root.IsNull,
                        RootWord = root.Rootword,
                        UpdateTime = DateTime.Now
                    };

                    sekaniRoot.SekaniCategoryId = categoryList.Find(x => x.Title == root.Category).Id;

                    sekaniRoot.SekaniFormId = sekaniFormList.Find(x => x.Title == root.Form).Id;

                    sekaniRoot.SekaniLevelId = sekaniLevelList.Find(x => x.Title == root.Level).Id;

                    if (!string.IsNullOrEmpty(root.Image))
                    {
                        var img = Directory.GetFiles(path + "\\content", root.Image, SearchOption.AllDirectories).SingleOrDefault();
                        if (img != null)
                        {
                            var theFile = System.IO.File.ReadAllBytes(img);
                            sekaniRoot.SekaniRootImages.Add(new SekaniRootImage() { Notes = root.Image, Format = root.Image.Split(".")[1], UpdateTime = DateTime.Now, Content = theFile });
                        }

                    }

                    root.EnglishWords.EnglishWord.ForEach(ew =>
                    {
                        var word = englishWordList.Find(x => x.Word == ew);
                        if (word != null)
                        {
                            sekaniRoot.SekaniRoots_EnglishWords.Add(new SekaniRootEnglishWord { EnglishWordId = word.Id, UpdateTime = DateTime.Now });
                        }
                    });

                    root.Topics.Title.ForEach(t =>
                    {
                        var topic = sekaniTopicsList.Find(x => x.Title == t);

                        sekaniRoot.SekaniRoots_Topics.Add(new SekaniRootTopic { TopicId = topic.Id, UpdateTime = DateTime.Now });

                    });

                    root.Inflectedforms.Elements.ForEach(sekani =>
                    {

                        var sw = new SekaniWord
                        {
                                //SekaniRootId = root.Id,
                                Word = sekani.Inflectedform,
                            UpdateTime = DateTime.Now
                        };
                        sekani.Attributes?.ForEach(attr =>
                        {
                            sw.SekaniWordAttributes.Add(new SekaniWordAttribute { Key = attr.AttributeElement.Key, Value = attr.AttributeElement.Value, UpdateTime = DateTime.Now });
                        });
                        sekani.Examples?.ForEach(ex =>
                        {
                            var example = new SekaniWordExample
                            {
                                English = ex.ExampleElement.English,
                                Sekani = ex.ExampleElement.Sekani,
                                UpdateTime = DateTime.Now
                            };

                            if (!string.IsNullOrEmpty(ex.ExampleElement.Audio))
                            {
                                var aud = Directory.GetFiles(path + "\\content", ex.ExampleElement.Audio, SearchOption.AllDirectories).SingleOrDefault();
                                if (aud != null)
                                {
                                    var theFile = System.IO.File.ReadAllBytes(aud);
                                    example.SekaniWordExampleAudios.Add(new SekaniWordExampleAudio { Format = aud.Split(".")[1], Notes = ex.ExampleElement.Audio, Content = theFile, UpdateTime = DateTime.Now });
                                }
                            }
                            sw.SekaniWordExamples.Add(example);
                        });
                        sekani.Audios?.ForEach(au =>
                        {
                            if (!string.IsNullOrEmpty(au))
                            {
                                if (Directory.Exists(path + "content\\" + au))
                                {
                                    var aud = Directory
                                        .GetFiles(path + "content", au, SearchOption.AllDirectories)
                                        .SingleOrDefault();
                                    if (aud != null)
                                    {
                                        var theFile = System.IO.File.ReadAllBytes(aud);
                                        var audio = new SekaniWordAudio
                                        {
                                            Format = au.Split(".")[1],
                                            Content = theFile,
                                            UpdateTime = DateTime.Now,
                                            Notes = au
                                        };
                                        sw.SekaniWordAudios.Add(audio);
                                    }
                                }
                            }
                        });
                        sekaniRoot.SekaniWords.Add(sw);

                    });
                    lock (sekaniRoot)
                    {
                        sekaniRoots.Add(sekaniRoot);
                    }

                });

                unitOfWork.SekaniRoots.AddRange(sekaniRoots);
                unitOfWork.Complete();
            }


        }

        private void AddCategories(Dictionary dictionary)
        {
            var dbCategory = unitOfWork.SekaniCategories.GetAll().Select(a => a.Title).ToList();

            var categoryList = dictionary.Roots
                .Where(a => !dbCategory.Contains(a.Category))
                .Select(a => a.Category)
                .Distinct()
                .Select(a => new SekaniCategory { Title = a, UpdateTime = DateTime.Now }).ToList();
            unitOfWork.SekaniCategories.AddRange(categoryList);
            unitOfWork.Complete();
        }
        private void AddForms(Dictionary dictionary)
        {
            var dbSekaniForms = unitOfWork.SekaniForms.GetAll().Select(a => a.Title).ToList();

            var sekaniFormList = dictionary.Roots
                .Where(a => !dbSekaniForms.Contains(a.Form))
                .Select(a => a.Form)
                .Distinct()
                .Select(a => new SekaniForm() { Title = a, UpdateTime = DateTime.Now }).ToList();
            unitOfWork.SekaniForms.AddRange(sekaniFormList);
            unitOfWork.Complete();
        }

        private void AddTopics(Dictionary dictionary)
        {
            var dbTopics = unitOfWork.Topics.GetAll().Select(a => a.Title).ToList();

            var sekaniTopicList = dictionary.Roots.SelectMany(a => a.Topics.Title)
                .Where(a => !dbTopics.Contains(a))
                .Distinct()
                .Select(a => new Topic() { Title = a, UpdateTime = DateTime.Now }).ToList();
            unitOfWork.Topics.AddRange(sekaniTopicList);
            unitOfWork.Complete();
        }

        private void AddEnglishWords(Dictionary dictionary)
        {
            var dbEnglishWords = unitOfWork.EnglishWords.GetAll().Select(a => a.Word).ToList();

            var englishWordsList = dictionary.Roots.SelectMany(a => a.EnglishWords.EnglishWord)
                .Where(a => !dbEnglishWords.Contains(a))
                .Distinct()
                .Select(a => new EnglishWord() { Word = a, UpdateTime = DateTime.Now }).ToList();
            unitOfWork.EnglishWords.AddRange(englishWordsList);
            unitOfWork.Complete();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("XmlFileUpload")]
        public void XmlFileUpload([FromForm]IFormFile xmlFile)
        {
            if (!Directory.Exists($"{hostingEnvironment.WebRootPath}\\files\\"))
            {
                Directory.CreateDirectory($"{hostingEnvironment.WebRootPath}\\files\\");
                Directory.CreateDirectory($"{hostingEnvironment.WebRootPath}\\files\\content");
            }

            var di = new DirectoryInfo($"{hostingEnvironment.WebRootPath}\\files\\");
            var existingXmlFile = di.GetFiles().Where(x => x.Extension == ".xml").SingleOrDefault();
            if (existingXmlFile != null)
            {
                existingXmlFile.Delete();
            }
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{xmlFile.FileName}";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                xmlFile.CopyTo(fs);
                fs.Flush();
            };
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("ZipFileUpload")]
        public void ZipFileUpload([FromForm]IFormFile zipFile)
        {

            if (!Directory.Exists($"{hostingEnvironment.WebRootPath}\\files\\"))
            {
                Directory.CreateDirectory($"{hostingEnvironment.WebRootPath}\\files\\");
                Directory.CreateDirectory($"{hostingEnvironment.WebRootPath}\\files\\content");
            }

            var di = new DirectoryInfo($"{hostingEnvironment.WebRootPath}\\files\\");
            var existingZipFile = di.GetFiles().Where(x => x.Extension == ".zip").SingleOrDefault();
            if (existingZipFile != null)
            {
                existingZipFile.Delete();
            }
            di = new DirectoryInfo($"{hostingEnvironment.WebRootPath}\\files\\content");

            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{zipFile.FileName}";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                zipFile.CopyTo(fs);
                fs.Flush();
            };
            //if (contentFile == null)
            //{
            //    throw new Exception("Zip file not found! please Upload xml file and try again!");
            //}
            //ZipFile.ExtractToDirectory(contentFile, $"{hostingEnvironment.WebRootPath}\\files\\content", true);

        }
    }
}