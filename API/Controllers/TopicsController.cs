using API.Helpers;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TopicsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TopicsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            IEnumerable<Topic> items = this._unitOfWork.Topics.GetAll();
            var count = items.Count();

            IEnumerable<Topic> subset;

            subset = this._unitOfWork.Topics.GetAll()
                .OrderBy(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(subset, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.Topics.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] Topic item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.Topics.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] Topic item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.Topics.Get(id);
            l.Notes = item.Notes;
            l.Title = item.Title;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.Topics.Get(id);
            _unitOfWork.Topics.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
