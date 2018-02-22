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
    public class TranslationsOfSekaniController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TranslationsOfSekaniController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /*
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

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.TranslationsOfSekani.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var item = _unitOfWork.TranslationsOfSekani.Get(id);
            _unitOfWork.TranslationsOfSekani.Remove(item);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] Translation item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.TranslationsOfSekani.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] Translation item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.TranslationsOfSekani.Get(id);
            l.SekaniWwtId = item.SekaniWwtId;
            l.Translation = item.Translation;
            l.Example1 = item.Example1;
            l.Example2 = item.Example2;
            l.Example3 = item.Example3;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        */

    }
}
