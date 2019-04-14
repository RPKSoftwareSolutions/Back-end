using API.Helpers;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniRootImagesController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniRootImagesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("post")]
        public ActionResult PostImage([FromForm] IFormFile imageFile, [FromForm] int sekaniRootId, [FromForm] string notes)
        {
            if (imageFile.Length > 505000)
                return BadRequest("The file exceeds maximum allowed size.");

            byte[] imageBytes = new byte[0];
            if (imageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
            }

            SekaniRootImage sri = new SekaniRootImage()
            {
                SekaniRootId = sekaniRootId,
                Notes = notes,
                Content = imageBytes,
                Format = "NA",
                UpdateTime = DateTime.Now
            };

            this._unitOfWork.SekaniRootImages.Add(sri);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("get/{sekaniRootId}")]
        public ActionResult Get(int sekaniRootId)
        {
            var image = this._unitOfWork.SekaniRootImages.GetAll().Where(i => i.SekaniRootId == sekaniRootId).FirstOrDefault();
            return Ok(image);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniRootImages.Get(id);
            _unitOfWork.SekaniRootImages.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
