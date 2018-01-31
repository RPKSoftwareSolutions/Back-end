using API.Helpers;
using AuthServer.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniSoundsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniSoundsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
    }
}
