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
    public class SekaniWordsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, int? levelId=null)
        {
            var items = _unitOfWork.SekaniWords.GetAll();
            if (levelId != null)
                items = items.Where(i => i.LevelId == levelId);

            var records = items
                   .OrderBy(s => s.Id)
                   .Skip((pageIndex - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => new
                   {
                       x.Id,
                       x.Word,
                       x.Phonetic,
                       x.UpdateTime,
                       x.LevelId,
                       Level = _unitOfWork.Levels.Get(x.LevelId).Title
                   });
            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex);

            return Ok(R);
        }
    }
}
