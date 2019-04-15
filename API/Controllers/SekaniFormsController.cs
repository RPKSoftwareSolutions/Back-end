using API.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class SekaniFormsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniFormsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            var items = this._unitOfWork.SekaniForms.GetAll();
            var count = items.Count();
            var subset = 
                 this._unitOfWork.SekaniForms.GetAll()
                .OrderBy(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(subset, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniForms.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniForm item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniForms.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniForm item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniForms.Get(id);
            l.Title = item.Title;
            l.Notes = item.Notes;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniForms.Get(id);
            _unitOfWork.SekaniForms.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
