﻿using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniWordAttributesController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordAttributesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            var items = this._unitOfWork.SekaniWordAttributes.GetAll()
                .OrderBy(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniWordAttributes.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniWordAttribute item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniWordAttributes.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniWordAttribute item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniWordAttributes.Get(id);
            l.Key = item.Key;
            l.SekaniWordId = item.SekaniWordId;
            l.Value = item.Value;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.SekaniWordAttributes.Get(id);
            _unitOfWork.SekaniWordAttributes.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
