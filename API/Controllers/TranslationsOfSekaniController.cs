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
    public class TranslationsOfSekaniController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TranslationsOfSekaniController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("getBySekaniWWT/{sekaniWwtId}/{pageSize}/{pageIndex}")]
        public ActionResult GetBySekaniWWT(int sekaniWwtId, int pageSize = 20, int pageIndex = 1)
        {
            var items = _unitOfWork.TranslationsOfSekani
                    .Find(i => i.SekaniWwtId == sekaniWwtId)
                    .OrderBy(s => s.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(i => new
                    {
                        i.Id,
                        i.SekaniWwtId,
                        SekaniWord = _unitOfWork.SekaniWords.Get(_unitOfWork.SekaniWWTs.Get(i.SekaniWwtId).SekaniWordId).Word,
                        SekaniWordType = _unitOfWork.SekaniWordTypes.Get(_unitOfWork.SekaniWWTs.Get(i.SekaniWwtId).SekaniWordTypeId).Title,
                        i.Translation,
                        i.Example1,
                        i.Example2,
                        i.Example3,
                        i.UpdateTime
                    });
            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }



    }
}
