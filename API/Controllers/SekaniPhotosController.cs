using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SekaniPhotosController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniPhotosController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("postImage")]
        public ActionResult PostImage([FromForm] IFormFile photoFile)
        {
            byte[] photoBytes = new byte[0];
            if (photoFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    photoFile.CopyTo(ms);
                    photoBytes = ms.ToArray();
                }
            }
            SekaniPhoto sp = new SekaniPhoto()
            {
                SekaniWwtId = 2,
                Notes = "nothing!",
                Content = photoBytes,
                UpdateTime = DateTime.Now
            };

            this._unitOfWork.SekaniPhotos.Add(sp);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("image")]
        public ActionResult GetImage()
        {
            var p = _unitOfWork.SekaniPhotos.GetAll().FirstOrDefault();
            return Ok(p);
        }
    }
}
