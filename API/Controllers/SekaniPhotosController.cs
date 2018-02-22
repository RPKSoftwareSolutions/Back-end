using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class SekaniPhotosController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniPhotosController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /*
        [HttpPost("post")]
        public ActionResult PostImage([FromForm] IFormFile photoFile, [FromForm] int sekaniWwtId, [FromForm] string notes)
        {
            if (photoFile.Length > 505000)
                return BadRequest("The file exceeds the maximum allowed size.");

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
                SekaniWwtId = sekaniWwtId,
                Notes = notes,
                Content = photoBytes,
                UpdateTime = DateTime.Now
            };

            this._unitOfWork.SekaniPhotos.Add(sp);
            _unitOfWork.Complete();
            return Ok(sp.Id);
        }

        [HttpGet("getBySekaniWwtId/{sekaniWwtId}/{pageSize}/{pageIndex}")]
        public ActionResult GetBySekaniWwtId(int sekaniWwtId, int pageSize, int pageIndex)
        {
            var items = _unitOfWork.SekaniPhotos
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
            var item = this._unitOfWork.SekaniPhotos.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var item = _unitOfWork.SekaniPhotos.Get(id);
            _unitOfWork.SekaniPhotos.Remove(item);
            _unitOfWork.Complete();
            return Ok();
        }

        */
    }
}
