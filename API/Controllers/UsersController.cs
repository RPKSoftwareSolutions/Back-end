using API.Helpers;
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
    public class UsersController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            var items = _unitOfWork.Users.GetAll();

            var records = items
                   .OrderBy(s => s.Id)
                   .Skip((pageIndex - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => new
                   {
                       x.Id,
                       x.FirstName,
                       x.LastName,
                       x.Email,
                       x.PhoneNumber,
                       x.DateOfBirth,
                       x.Active,
                       x.EmailVerified
                   });
            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.Users.Get(id);
            if (item == null) return new NotFoundResult();
            var tmp = item;
            tmp.Password = "******";
            return Ok(tmp);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var item = _unitOfWork.Users.Get(id);
            _unitOfWork.Users.Remove(item);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] User item)
        {
            //item.UpdateTime = DateTime.Now;
            _unitOfWork.Users.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] User item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.Users.Get(id);
            l.FirstName = item.FirstName;
            l.LastName = item.LastName;
            l.DateOfBirth = item.DateOfBirth;
            l.Active = item.Active;
            l.EmailVerified = item.EmailVerified;
            l.PhoneNumber = item.PhoneNumber;
            l.Email = item.Email;
            l.Username = item.Username;
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
