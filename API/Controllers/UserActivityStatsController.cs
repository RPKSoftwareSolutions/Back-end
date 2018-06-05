using API.Helpers;
using AuthServer.Generic;
using DomainModel;
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
    public class UserActivityStatsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserActivityStatsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{variable}")]
        public ActionResult GetAll(string variable)
        {
            var items = this._unitOfWork.UserActivityStats
                            .GetAll()
                            .Where(x => x.UserId == UserHelper.GetCurrentUserId(User))
                            .Where(x => String.Equals(variable, x.Variable));
                    
            /*var count = items.Count();
            var subset = this._unitOfWork.UserActivityStats.GetAll().Where(x => x.UserId == UserHelper.GetCurrentUserId(User))
                .OrderBy(i => i.Id);
            var R = PageRecordsSelector.GetPageRecords(subset, 1000, 1, count);
            return Ok(R);*/
            return Ok(items);
        }

        [HttpPut("put")]
        public ActionResult Put([FromBody] UserActivityStatPutVm model)
        {
            var record = this._unitOfWork.UserActivityStats
                              .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && String.Equals(x.Variable, model.Variable))
                              .FirstOrDefault();

            if (record != null)
            {
                record.Value = model.Value;
                record.UpdateTime = DateTime.Now;
                _unitOfWork.Complete();
                return Ok(record);
            }
            else
            {
                var newRecord = new UserActivityStat()
                {
                    UserId = UserHelper.GetCurrentUserId(User),
                    Variable = model.Variable,
                    Value = model.Value,
                    UpdateTime = DateTime.Now
                };
                _unitOfWork.UserActivityStats.Add(newRecord);
                _unitOfWork.Complete();
                return Ok(newRecord);
            }
        }

        [HttpGet("learntWords/{pageSize}/{pageIndex}")]
        public ActionResult GetLearntWords(int pageSize = 20, int pageIndex = 1)
        {
            int userId = UserHelper.GetCurrentUserId(User);
            var items = _unitOfWork.UserLearntWords.Find(x => x.UserId == userId);
           
            var count = items.Count();

            var records = items
                   .OrderBy(s => s.Id)
                   .Skip((pageIndex - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => new
                   {
                       x.Id,
                       x.SekaniWordId,
                       x.UserId,
                       SekaniWord = _unitOfWork.SekaniWords.Find(i => i.Id == x.Id).Select(i => i.Word),
                       x.UpdateTime
                   });
            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("failedWords/{pageSize}/{pageIndex}")]
        public ActionResult GetFailedWords(int pageSize = 20, int pageIndex = 1)
        {
            int userId = UserHelper.GetCurrentUserId(User);
            var items = _unitOfWork.UserFailedWords.Find(x => x.UserId == userId);

            var count = items.Count();

            var records = items
                   .OrderBy(s => s.Id)
                   .Skip((pageIndex - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => new
                   {
                       x.Id,
                       x.SekaniWordId,
                       x.UserId,
                       SekaniWord = _unitOfWork.SekaniWords.Find(i => i.Id == x.Id).Select(i => i.Word),
                       x.UpdateTime
                   });
            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex, count);
            return Ok(R);
        }
    }

    

    public class UserActivityStatPutVm
    {
        public string Variable { get; set; }
        public string Value { get; set; }
    }
}
