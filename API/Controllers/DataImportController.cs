using API.ParamModels;

using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public JsonResult ImportData()
        {
            var path = hostingEnvironment.WebRootPath + "\\files\\";
            var createdFiles = Directory.GetFiles(path);

            var xmlFile = createdFiles.SingleOrDefault(x => x.Contains(".xml"));

            if (xmlFile == null)
            {
                throw new Exception("Xml file not found! please Upload xml file and try again!");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<,>));
            using (FileStream fileStream = new FileStream(xmlFile, FileMode.Open))
            {
                var result = (Dictionary)serializer.Deserialize(fileStream);
                result.Roots.ForEach(root =>
                {
                    try
                    {

                  

                    var rt = unitOfWork.SekaniRoots.Find(x => x.RootWord == root.Rootword).FirstOrDefault();
                    if (rt == null)
                    {
                        var sekaniRoot = new SekaniRoot
                        {
                            //Id = root.Id,
                            IsNull = root.IsNull,
                            RootWord = root.Rootword,
                            UpdateTime = DateTime.Now
                        };

                        var category = unitOfWork.SekaniCategories.Find(x => x.Title == root.Category).FirstOrDefault();
                        if (category == null)
                        {
                            sekaniRoot.SekaniCategory = new SekaniCategory { Title = root.Category, UpdateTime = DateTime.Now };
                        }
                        else
                        {
                            sekaniRoot.SekaniCategoryId = category.Id;
                        }

                        var form = unitOfWork.SekaniForms.Find(x => x.Title == root.Form).FirstOrDefault();
                        if (form == null)
                        {
                            sekaniRoot.SekaniForm = new SekaniForm { Title = root.Form, UpdateTime = DateTime.Now };
                        }
                        else
                        {
                            sekaniRoot.SekaniFormId = form.Id;
                        }

                        var level = unitOfWork.SekaniLevels.Find(x => x.Title == root.Level).FirstOrDefault();
                        if (level == null)
                        {
                            sekaniRoot.SekaniLevelId = unitOfWork.SekaniLevels.Find(x => x.Title == "Unknown").FirstOrDefault().Id; ;
                        }
                        else
                        {
                            sekaniRoot.SekaniLevelId = level.Id;
                        }

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
                            var word = unitOfWork.EnglishWords.Find(x => x.Word == ew).FirstOrDefault();
                            if (word == null)
                            {
                                //todo: what we do when we dont have english word?
                                sekaniRoot.SekaniRoots_EnglishWords.Add(new SekaniRootEnglishWord { EnglishWord = new EnglishWord { Word = ew, Standard = true, UpdateTime = DateTime.Now }, UpdateTime = DateTime.Now });
                            }
                            else
                            {
                                sekaniRoot.SekaniRoots_EnglishWords.Add(new SekaniRootEnglishWord { EnglishWordId = word.Id, UpdateTime = DateTime.Now });
                            }
                        });

                        root.Topics.Title.ForEach(t =>
                        {
                            var topic = unitOfWork.Topics.Find(x => x.Title == t).FirstOrDefault();
                            if (topic == null)
                            {
                                sekaniRoot.SekaniRoots_Topics.Add(new SekaniRootTopic { Topic = new Topic { Title = t, UpdateTime = DateTime.Now }, UpdateTime = DateTime.Now });
                            }
                            else
                            {
                                sekaniRoot.SekaniRoots_Topics.Add(new SekaniRootTopic { TopicId = topic.Id, UpdateTime = DateTime.Now });
                            }
                        });
                        //here
                        root.Inflectedforms.Elements.ForEach(sekani =>
                        {
                            var sekaniWord = unitOfWork.SekaniWords.Find(x => x.Word == sekani.Inflectedform).FirstOrDefault();
                            if (sekaniWord == null)
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
                                        var aud = Directory.GetFiles(path + "\\content", au, SearchOption.AllDirectories).SingleOrDefault();
                                        if (aud != null)
                                        {
                                            var theFile = System.IO.File.ReadAllBytes(aud);
                                            var audio = new SekaniWordAudio { Format = au.Split(".")[1], Content = theFile, UpdateTime = DateTime.Now, Notes = au };
                                            sw.SekaniWordAudios.Add(audio);
                                        }
                                    }
                                });
                                sekaniRoot.SekaniWords.Add(sw);
                            }
                            else
                            {
                                sekaniRoot.SekaniWords.Add(sekaniWord);
                            }
                        });
                        unitOfWork.SekaniRoots.Add(sekaniRoot);
                        unitOfWork.Complete();
                    }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                      
                    }
                });
            }

            return Json(new { Success = true, Message = "Data insertion Succeeded !" });
        }
        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("XmlFileUpload")]
        public JsonResult XmlFileUpload([FromForm]IFormFile xmlFile)
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

            return Json(new { state = 0 });
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("ZipFileUpload")]
        public JsonResult ZipFileUpload([FromForm]IFormFile zipFile)
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

            return Json(new { state = 0 });
        }
    }
}