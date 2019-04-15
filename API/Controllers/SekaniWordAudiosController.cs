using API.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniWordAudiosController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordAudiosController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("post")]
        public ActionResult PostAudio([FromForm] IFormFile soundFile, [FromForm] int sekaniWordId, [FromForm] string notes)
        {
            if (soundFile.Length > 505000)
                return BadRequest("The file exceeds maximum allowed size.");

            byte[] soundBytes = new byte[0];
            if (soundFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    soundFile.CopyTo(ms);
                    soundBytes = ms.ToArray();
                }
            }

            SekaniWordAudio swa = new SekaniWordAudio()
            {
                SekaniWordId = sekaniWordId,
                Content = soundBytes,
                Notes = notes,
                Format = "NA",
                UpdateTime = DateTime.Now
            };

            this._unitOfWork.SekaniWordAudios.Add(swa);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("get/{sekaniWordId}")]
        public ActionResult Get(int sekaniWordId)
        {
            var sound = this._unitOfWork.SekaniWordAudios.GetAll().Where(i => i.SekaniWordId == sekaniWordId).FirstOrDefault();
            return Ok(sound);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniWordAudios.Get(id);
            _unitOfWork.SekaniWordAudios.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
