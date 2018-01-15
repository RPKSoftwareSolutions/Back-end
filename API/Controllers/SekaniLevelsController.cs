using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SekaniLevelsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniLevelsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get")]
        public ActionResult GetAll()
        {
            var levels = this._unitOfWork.Levels.GetAll();
            return Ok(levels);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] Level level)
        {
            level.UpdateTime = DateTime.Now;
            _unitOfWork.Levels.Add(level);
            _unitOfWork.Complete();
            return Ok(level.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] Level level)
        {
            if (id != level.Id)
                return StatusCode(400);

            var l = _unitOfWork.Levels.Get(id);
            l.Title = level.Title;
            l.Notes = level.Notes;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.Levels.Get(id);
            _unitOfWork.Levels.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }

        
    }
}
