using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniRootsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniRootsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            var items = this._unitOfWork.SekaniRoots.GetAll()
                .OrderBy(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniRoots.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniRoot item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniRoots.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniRoot item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniRoots.Get(id);
            l.IsNull = item.IsNull;
            l.RootWord = item.RootWord;
            l.SekaniCategoryId = item.SekaniCategoryId;
            l.SekaniFormId = item.SekaniFormId;
            l.SekaniLevelId = item.SekaniLevelId;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniRoots.Get(id);
            _unitOfWork.SekaniRoots.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
