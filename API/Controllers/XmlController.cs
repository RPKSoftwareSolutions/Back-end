using API.ParamModels;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class XmlController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment hostingEnvironment;

        public XmlController(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [RequestSizeLimit(2147483648)]
        public JsonResult Index(List<IFormFile> files, [FromServices] IHostingEnvironment env)
        {
            if(!files.Any(x => x.ContentType == "text/xml"))
            {
                return Json(new { Success=false, Message = "Please select An XML file with a ZIP file containing images and audios" });
            }
            if (!files.Any(x => x.ContentType == "application/x-zip-compressed"))
            {
                return Json(new { Success = false, Message = "Please select An XML file with a ZIP file containing images and audios" });
            }
            if ((files.Count(x => x.ContentType == "application/x-zip-compressed" || x.ContentType == "text/xml") > 2))
            {
                return Json(new { Success = false, Message = "Please select An XML file with a ZIP file containing images and audios" });
            }

            if (!Directory.Exists($"{env.WebRootPath}\\files\\"))
            {
                Directory.CreateDirectory($"{env.WebRootPath}\\files\\");
            }
            else
            {
                Directory.Delete($"{env.WebRootPath}\\files\\", true);
                Directory.CreateDirectory($"{env.WebRootPath}\\files\\");
            }
            files.ForEach(file =>
            {
                string fileName = $"{env.WebRootPath}\\files\\{file.FileName}";
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                };
            });
            var path = env.WebRootPath + "\\files\\";
            Directory.CreateDirectory($"{env.WebRootPath}\\files\\content");
            var createdFiles = Directory.GetFiles(path);

            var xmlFile = createdFiles.Where(x => x.Contains(".xml"));
            var contentFile = createdFiles.Where(x => x.Contains(".zip")).Single();
            ZipFile.ExtractToDirectory(contentFile, $"{env.WebRootPath}\\files\\content");

            
            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary));
            using (FileStream fileStream = new FileStream(xmlFile.Single(), FileMode.Open))
            {
                Dictionary result = (Dictionary)serializer.Deserialize(fileStream);
                result.Roots.ForEach(root =>
                {
                    var rt = unitOfWork.SekaniRoots.Find(x => x.RootWord == root.Rootword).FirstOrDefault();
                    if(rt == null)
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
                            sekaniRoot.SekaniForm = new SekaniForm { Title = root.Category, UpdateTime = DateTime.Now };
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
                                sekaniRoot.SekaniRoots_EnglishWords.Add(new SekaniRoot_EnglishWord { EnglishWord = new EnglishWord { Word = ew, Standard = true, UpdateTime = DateTime.Now }, UpdateTime = DateTime.Now });
                            }
                            else
                            {
                                sekaniRoot.SekaniRoots_EnglishWords.Add(new SekaniRoot_EnglishWord { EnglishWordId = word.Id, UpdateTime = DateTime.Now });
                            }
                        });

                        root.Topics.Title.ForEach(t =>
                        {
                            var topic = unitOfWork.Topics.Find(x => x.Title == t).FirstOrDefault();
                            if (topic == null)
                            {
                                sekaniRoot.SekaniRoots_Topics.Add(new SekaniRoot_Topic { Topic = new Topic { Title = t, UpdateTime = DateTime.Now }, UpdateTime = DateTime.Now });
                            }
                            else
                            {
                                sekaniRoot.SekaniRoots_Topics.Add(new SekaniRoot_Topic { TopicId = topic.Id, UpdateTime = DateTime.Now});
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
                });
            }

            return Json(new { Success = true, Message = "Data insertion Succeeded !" });
        }


    }

}