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
    }
}
