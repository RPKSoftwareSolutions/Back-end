﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using TKD.Domain.TKDModels;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class SekaniWordExampleAudiosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordExampleAudiosController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("post")]
        public ActionResult PostAudio([FromForm] IFormFile soundFile, [FromForm] int sekaniWordExampleId, [FromForm] string notes)
        {
            if (soundFile.Length > 505000)
            {
                return BadRequest("The file exceeds maximum allowed size.");
            }

            byte[] soundBytes = new byte[0];
            if (soundFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    soundFile.CopyTo(ms);
                    soundBytes = ms.ToArray();
                }
            }

            SekaniWordExampleAudio swa = new SekaniWordExampleAudio()
            {
                SekaniWordExampleId = sekaniWordExampleId,
                Content = soundBytes,
                Notes = notes,
                Format = "NA",
                UpdateTime = DateTime.Now
            };

            this._unitOfWork.SekaniWordExampleAudios.Add(swa);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("get/{sekaniWordExampleId}")]
        public ActionResult Get(int sekaniWordExampleId)
        {
            var sound = this._unitOfWork.SekaniWordExampleAudios.GetAll().Where(i => i.SekaniWordExampleId == sekaniWordExampleId).FirstOrDefault();
            return Ok(sound);
        }
        [HttpGet("GetById/{sekaniWordExampleAudioId}")]
        public SekaniWordExampleAudio GetById(int sekaniWordExampleAudioId)
        {
            var sound = this._unitOfWork.SekaniWordExampleAudios.Get(sekaniWordExampleAudioId);
            return sound;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniWordExampleAudios.Get(id);
            _unitOfWork.SekaniWordExampleAudios.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
