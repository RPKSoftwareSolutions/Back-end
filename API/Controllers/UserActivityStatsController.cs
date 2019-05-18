using API.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKD.Domain.TKDModels;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UserActivityStatsController : Controller
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
            var items = _unitOfWork.UserLearnedWords.Find(x => x.UserId == userId);

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

        [HttpPost("learntWords/post/{sekaniWordId}")]
        public ActionResult PostLearntWord(int sekaniWordId)
        {
            // if the word is marked as "failed" before, that has to be removed first.
            var failedRecord = _unitOfWork.UserFailedWords
                                .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && x.SekaniWordId == sekaniWordId).FirstOrDefault();
            if (failedRecord != null)
            {
                _unitOfWork.UserFailedWords.Remove(failedRecord);
            }

            // if a learnt record for this word already exists, we don't need to do anything. 
            var learntRecord = _unitOfWork.UserLearnedWords
                                .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && x.SekaniWordId == sekaniWordId).FirstOrDefault();

            if (learntRecord == null)
            {
                var record = new UserLearnedWord()
                {
                    SekaniWordId = sekaniWordId,
                    UserId = UserHelper.GetCurrentUserId(User),
                    UpdateTime = DateTime.Now
                };
                _unitOfWork.UserLearnedWords.Add(record);
                _unitOfWork.Complete();
                return Ok(record.Id);
            }
            else
            {
                _unitOfWork.Complete();
                return Ok(learntRecord.Id);
            }
        }

        [HttpPost("failedWords/post/{sekaniWordId}")]
        public ActionResult PostFailedWord(int sekaniWordId)
        {
            // if the word is marked as "learnt" before, that has to be removed first.
            var learntRecord = _unitOfWork.UserLearnedWords
                                .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && x.SekaniWordId == sekaniWordId).FirstOrDefault();
            if (learntRecord != null)
            {
                _unitOfWork.UserLearnedWords.Remove(learntRecord);
            }

            // if a failed record for this word already exists, we don't need to do anything. 
            var failedRecord = _unitOfWork.UserFailedWords
                                .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && x.SekaniWordId == sekaniWordId).FirstOrDefault();

            if (failedRecord == null)
            {
                var record = new UserFailedWord()
                {
                    SekaniWordId = sekaniWordId,
                    UserId = UserHelper.GetCurrentUserId(User),
                    UpdateTime = DateTime.Now
                };
                _unitOfWork.UserFailedWords.Add(record);
                _unitOfWork.Complete();
                return Ok(record.Id);
            }
            else
            {
                _unitOfWork.Complete();
                return Ok(failedRecord.Id);
            }
        }

        [HttpDelete("learntWords/delete/{sekaniWordId}")]
        public ActionResult DeleteLearntWord(int sekaniWordId)
        {
            var learntWord = _unitOfWork.UserLearnedWords
                                .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && x.SekaniWordId == sekaniWordId).FirstOrDefault();

            if (learntWord == null)
                return NotFound("Record was not found.");

            _unitOfWork.UserLearnedWords.Remove(learntWord);
            _unitOfWork.Complete();
            return Ok(learntWord.Id);
        }

        [HttpDelete("failedWords/delete/{sekaniWordId}")]
        public ActionResult DeleteFailedWord(int sekaniWordId)
        {
            var failedWord = _unitOfWork.UserFailedWords
                                .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && x.SekaniWordId == sekaniWordId).FirstOrDefault();

            if (failedWord == null)
                return NotFound("Record was not found.");

            _unitOfWork.UserFailedWords.Remove(failedWord);
            _unitOfWork.Complete();
            return Ok(failedWord.Id);
        }


    }

    

    public class UserActivityStatPutVm
    {
        public string Variable { get; set; }
        public string Value { get; set; }
    }
}
