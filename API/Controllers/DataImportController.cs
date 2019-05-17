using API.ParamModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _path;

        public DataImportController(IUnitOfWork unitOfWork,
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _path = configuration.GetSection("BasePath").Value;
        }

        [HttpPost]
        [Route("ImportData")]
        public void ImportData()
        {

            var createdFiles = Directory.GetFiles(_path, "*.*", SearchOption.AllDirectories);

            var xmlFile = createdFiles.SingleOrDefault(x => x.Contains(@"\AppData.xml"));

            if (xmlFile == null)
            {
                throw new Exception("Xml file not found! please Upload xml file and try again!");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary));
            using (FileStream fileStream = new FileStream(xmlFile, FileMode.Open))
            {
                var result = (Dictionary)serializer.Deserialize(fileStream);

                var allFiles = Directory.GetFiles(_path, "*.*", SearchOption.AllDirectories);

                AddCategories(result);
                var sekaniRootList = _unitOfWork.SekaniRoots.GetAll().ToList().Select(a => a.Id);
                var persistRoots = result.Roots.Where(a => !sekaniRootList.Contains(a.Id));
                var categoryList = _unitOfWork.SekaniCategories.GetAll().ToList();
                AddForms(result);
                var sekaniFormList = _unitOfWork.SekaniForms.GetAll().ToList();
                var sekaniLevelList = _unitOfWork.SekaniLevels.GetAll().ToList();
                AddTopics(result);
                var sekaniTopicsList = _unitOfWork.Topics.GetAll().ToList();
                AddEnglishWords(result);
                var englishWordList = _unitOfWork.EnglishWords.GetAll().ToList();

                List<SekaniRoot> sekaniRoots = new List<SekaniRoot>();
                Parallel.ForEach(persistRoots, root =>
                {


                    var sekaniRoot = new SekaniRoot
                    {
                        Id = root.Id,
                        IsNull = root.IsNull,
                        RootWord = root.Rootword,
                        UpdateTime = DateTime.Now,
                        SekaniCategoryId = categoryList.Find(x => x.Title == root.Category).Id,
                        SekaniFormId = sekaniFormList.Find(x => x.Title == root.Form).Id,
                        SekaniLevelId = sekaniLevelList.Find(x => x.Title == root.Level).Id
                    };




                    if (!string.IsNullOrEmpty(root.Image))
                    {
                        Regex regex = new Regex(@"^[\w,\s-]+\.[\w]{3}$");
                        Match match = regex.Match(root.Image);
                        if (match.Success)
                        {
                            var img = allFiles.SingleOrDefault(a => a.Contains("\\" + root.Image));
                            if (img != null)
                            {
                                var theFile = System.IO.File.ReadAllBytes(img);
                                sekaniRoot.SekaniRootImages.Add(new SekaniRootImage()
                                {
                                    Notes = root.Image,
                                    Format = root.Image.Split(".")[1],
                                    UpdateTime = DateTime.Now,
                                    Content = theFile
                                });
                            }
                        }

                    }

                    root.EnglishWords.EnglishWord.Distinct().ToList().ForEach(ew =>
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
                            SekaniRootId = root.Id,
                            Word = sekani.Inflectedform,
                            UpdateTime = DateTime.Now
                        };
                        sekani.Attributes?.AttributeElement.ForEach(attr =>
                        {
                            sw.SekaniWordAttributes.Add(new SekaniWordAttribute { Key = attr.Key, Value = attr.Value, UpdateTime = DateTime.Now });
                        });
                        sekani.Examples.ForEach(ex =>
                        {
                            var example = new SekaniWordExample
                            {
                                English = ex.ExampleElement.English,
                                Sekani = ex.ExampleElement.Sekani,
                                UpdateTime = DateTime.Now
                            };

                            if (!string.IsNullOrEmpty(ex.ExampleElement.Audio))
                            {
                                Regex regex = new Regex(@"^[\w,\s-]+\.[\w]{3}$");
                                Match match = regex.Match(ex.ExampleElement.Audio);
                                if (match.Success)
                                {
                                    var aud = allFiles.SingleOrDefault(a => a.Contains("\\" + ex.ExampleElement.Audio));
                                    if (aud != null)
                                    {
                                        var theFile = System.IO.File.ReadAllBytes(aud);
                                        example.SekaniWordExampleAudios.Add(new SekaniWordExampleAudio
                                        {
                                            Format = aud.Split(".")[1],
                                            Notes = ex.ExampleElement.Audio,
                                            Content = theFile,
                                            UpdateTime = DateTime.Now
                                        });
                                    }
                                }

                            }
                            sw.SekaniWordExamples.Add(example);
                        });
                        sekani.Audios?.ForEach(au =>
                        {
                            if (!string.IsNullOrEmpty(au))
                            {
                                Regex regex = new Regex(@"^[\w,\s-]+\.[\w]{3}$");
                                Match match = regex.Match(au);
                                if (match.Success)
                                {
                                    var aud = allFiles.SingleOrDefault(a => a.Contains("\\" + au));
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

                _unitOfWork.SekaniRoots.AddRange(sekaniRoots);
                _unitOfWork.Complete();
            }


        }

        private void AddCategories(Dictionary dictionary)
        {
            var dbCategory = _unitOfWork.SekaniCategories.GetAll().Select(a => a.Title).ToList();

            var categoryList = dictionary.Roots
                .Where(a => !dbCategory.Contains(a.Category))
                .Select(a => a.Category)
                .Distinct()
                .Select(a => new SekaniCategory { Title = a, UpdateTime = DateTime.Now }).ToList();
            _unitOfWork.SekaniCategories.AddRange(categoryList);
            _unitOfWork.Complete();
        }
        private void AddForms(Dictionary dictionary)
        {
            var dbSekaniForms = _unitOfWork.SekaniForms.GetAll().Select(a => a.Title).ToList();

            var sekaniFormList = dictionary.Roots
                .Where(a => !dbSekaniForms.Contains(a.Form))
                .Select(a => a.Form)
                .Distinct()
                .Select(a => new SekaniForm() { Title = a, UpdateTime = DateTime.Now }).ToList();
            _unitOfWork.SekaniForms.AddRange(sekaniFormList);
            _unitOfWork.Complete();
        }

        private void AddTopics(Dictionary dictionary)
        {
            var dbTopics = _unitOfWork.Topics.GetAll().Select(a => a.Title).ToList();

            var sekaniTopicList = dictionary.Roots.SelectMany(a => a.Topics.Title)
                .Where(a => !dbTopics.Contains(a))
                .Distinct()
                .Select(a => new Topic() { Title = a, UpdateTime = DateTime.Now }).ToList();
            _unitOfWork.Topics.AddRange(sekaniTopicList);
            _unitOfWork.Complete();
        }

        private void AddEnglishWords(Dictionary dictionary)
        {
            var dbEnglishWords = _unitOfWork.EnglishWords.GetAll().Select(a => a.Word).ToList();

            var englishWordsList = dictionary.Roots.SelectMany(a => a.EnglishWords.EnglishWord)
                .Where(a => !dbEnglishWords.Contains(a))
                .Distinct()
                .Select(a => new EnglishWord() { Word = a, UpdateTime = DateTime.Now }).ToList();
            _unitOfWork.EnglishWords.AddRange(englishWordsList);
            _unitOfWork.Complete();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("XmlFileUpload")]
        public void XmlFileUpload([FromForm]IFormFile xmlFile)
        {

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
                Directory.CreateDirectory(_path + @"\content");
            }

            var di = new DirectoryInfo(_path);
            var existingXmlFile = di.GetFiles().SingleOrDefault(x => x.Extension == ".xml");

            existingXmlFile?.Delete();

            string fileName = _path + "\\AppData.xml";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                xmlFile.CopyTo(fs);
                fs.Flush();
            }
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("ZipFileUpload")]
        public void ZipFileUpload([FromForm]IFormFile zipFile)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
                Directory.CreateDirectory(_path + @"\content");
            }

            var di = new DirectoryInfo(_path);
            var existingZipFile = di.GetFiles().SingleOrDefault(x => x.Extension == ".zip");

            existingZipFile?.Delete();

            di = new DirectoryInfo(_path + @"\content");

            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }
            string fileName = _path + $"\\{ zipFile.FileName}";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                zipFile.CopyTo(fs);
                fs.Flush();
            }

            ZipFile.ExtractToDirectory(fileName, _path + @"\content", true);

        }
    }
}