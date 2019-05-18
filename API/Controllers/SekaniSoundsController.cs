using API.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class SekaniSoundsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniSoundsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /*

        [HttpPost("post")]
        public ActionResult PostImage([FromForm] IFormFile soundFile, [FromForm] int sekaniWwtId, [FromForm] string notes)
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
            SekaniSound sp = new SekaniSound()
            {
                SekaniWwtId = sekaniWwtId,
                Notes = notes,
                Content = soundBytes,
                UpdateTime = DateTime.Now
            };

            this._unitOfWork.SekaniSounds.Add(sp);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("getBySekaniWwtId/{sekaniWwtId}/{pageSize}/{pageIndex}")]
        public ActionResult GetBySekaniWwtId(int sekaniWwtId, int pageSize, int pageIndex)
        {
            var items = _unitOfWork.SekaniSounds
                    .Find(p => p.SekaniWwtId == sekaniWwtId)
                    .OrderBy(p => p.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(i => new
                    {
                        i.Id,
                        i.SekaniWwtId,
                        i.Notes,
                        i.UpdateTime,
                        i.Content,
                        SekaniWord = _unitOfWork.SekaniWords.Get(_unitOfWork.SekaniWWTs.Get(i.SekaniWwtId).SekaniWordId).Word,
                        SekaniWordType = _unitOfWork.SekaniWordTypes.Get(_unitOfWork.SekaniWWTs.Get(i.SekaniWwtId).SekaniWordTypeId).Title,
                    });
            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniSounds.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var item = _unitOfWork.SekaniSounds.Get(id);
            _unitOfWork.SekaniSounds.Remove(item);
            _unitOfWork.Complete();
            return Ok();
        }

        */
    }
}
