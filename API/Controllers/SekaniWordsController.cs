using API.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure;

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
        public ActionResult Post([FromBody] SekaniWordAddVM item)
        {
            /*
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniWords.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);*/
            SekaniWord sw = new SekaniWord()
            {
                Phonetic = item.Phonetic,
                SekaniRootId = item.SekaniRootId,
                Word = item.Word,
                UpdateTime = DateTime.Now
            };
            this._unitOfWork.SekaniWords.Add(sw);
            foreach(SekaniWordAttributeKeyValueVM x in item.Attributes)
            {
                var a = new SekaniWordAttribute()
                {
                    SekaniWordId = sw.Id,
                    Key = x.Key,
                    Value = x.Value,
                    UpdateTime = DateTime.Now
                };
                this._unitOfWork.SekaniWordAttributes.Add(a);
            }
            this._unitOfWork.Complete();
            return Ok(sw.Id);
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

    public class SekaniWordAddVM
    {
        public int SekaniRootId { get; set; }
        public string Word { get; set; }
        public string Phonetic { get; set; }
        public SekaniWordAttributeKeyValueVM[] Attributes { get; set; }
    }

    public class SekaniWordAttributeKeyValueVM
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
