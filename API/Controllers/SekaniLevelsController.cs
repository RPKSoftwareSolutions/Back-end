using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniLevelsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniLevelsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            var items = this._unitOfWork.SekaniLevels.GetAll()
                .OrderBy(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniLevels.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniLevel level)
        {
            level.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniLevels.Add(level);
            _unitOfWork.Complete();
            return Ok(level.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniLevel level)
        {
            if (id != level.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniLevels.Get(id);
            l.Title = level.Title;
            l.Notes = level.Notes;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniLevels.Get(id);
            _unitOfWork.SekaniLevels.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }

        
    }
}
