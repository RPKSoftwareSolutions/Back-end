using API.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Infrastructure;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniWordExamplesController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordExamplesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, int sekaniWordId = 0)
        {
            var items = this._unitOfWork.SekaniWordExamples.GetAll().Where(i => i.SekaniWordId == sekaniWordId);
            var count = items.Count();

            var subset = items
                .OrderBy(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(subset, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniWordExamples.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniWordExample item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniWordExamples.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniWordExample item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniWordExamples.Get(id);
            l.Sekani = item.Sekani;
            l.English = item.English;
            l.SekaniWordId = item.SekaniWordId;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniWordExamples.Get(id);
            _unitOfWork.SekaniWordExamples.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
