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
    public class SekaniWWTsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWWTsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("getBySekaniWordId/{sekaniWordId}/{pageSize}/{pageIndex}")]
        public ActionResult GetBySekaniWord(int sekaniWordId, int pageSize = 20, int pageIndex = 1)
        {
            var items = _unitOfWork.SekaniWWTs
                    .Find(s => s.SekaniWordId == sekaniWordId)
                    .OrderBy(s => s.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(i => new
                    {
                        i.Id,
                        i.SekaniWordId,
                        i.SekaniWordTypeId,
                        i.UpdateTime,
                        SekaniWordType = _unitOfWork.SekaniWordTypes.Get(i.SekaniWordTypeId).Title,
                        SekaniWord = _unitOfWork.SekaniWords.Get(i.SekaniWordId).Word
                    });
            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }

        [HttpGet("getBySekaniWordTypeId/{sekaniWordTypeId}/{pageSize}/{pageIndex}")]
        public ActionResult GetBySekaniWordType(int sekaniWordTypeId, int pageSize = 20, int pageIndex = 1)
        {
            var items = _unitOfWork.SekaniWWTs
                    .Find(s => s.SekaniWordTypeId == sekaniWordTypeId)
                    .OrderBy(s => s.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(i => new
                    {
                        i.Id,
                        i.SekaniWordId,
                        i.SekaniWordTypeId,
                        i.UpdateTime,
                        SekaniWordType = _unitOfWork.SekaniWordTypes.Get(i.SekaniWordTypeId).Title,
                        SekaniWord = _unitOfWork.SekaniWords.Get(i.SekaniWordId).Word
                    });

            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }
    }
}
