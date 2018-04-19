using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, int? sekaniRootId = 0)
        {
            IEnumerable<SekaniWord> items = this._unitOfWork.SekaniWords.GetAll();

            if (sekaniRootId != null && sekaniRootId != 0)
                items = items.Where(i => i.SekaniRootId == sekaniRootId);

            var count = items.Count();

            IEnumerable<SekaniWord> subset = items
                    .OrderBy(i => i.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);

            var _items = subset.Select(i => new
            {
                i.Id,
                i.Phonetic,
                i.SekaniRootId,
                i.UpdateTime,
                i.Word,
                Attributes = this._unitOfWork.SekaniWordAttributes.Find(a => a.SekaniWordId == i.Id).Select(a => new
                {
                    a.Id,
                    a.Key,
                    a.Value,
                    a.UpdateTime
                })
            });

            var R = PageRecordsSelector.GetPageRecords(_items, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniWords.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniWord item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniWords.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniWord item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniWords.Get(id);
            l.Phonetic = item.Phonetic;
            l.SekaniRootId = item.SekaniRootId;
            l.Word = item.Word;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniWords.Get(id);
            _unitOfWork.SekaniWords.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
