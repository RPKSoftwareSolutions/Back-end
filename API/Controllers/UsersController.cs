using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;

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
            var count = items.Count();

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
            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex, count);
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

        [HttpGet("getSessions/{pageSize}/{pageIndex}")]
        public ActionResult GetSessions(int pageSize = 20, int pageIndex = 1)
        {
            var items = this._unitOfWork.PersistedGrants.GetAll()
                    .GroupBy(i => i.SubjectId)
                    .Select(i => new
                    {
                        Username = this._unitOfWork.Users.GetAll().Where(u => u.Id == int.Parse(i.FirstOrDefault().SubjectId)).FirstOrDefault().Username,
                        Count = i.Count()
                    });

            var count = items.Count();
            var records = items.OrderBy(i => i.Username)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize);

            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpDelete("killSessions/{username}")]
        public ActionResult KillSessions(string username)
        {
            var subj = this._unitOfWork.Users.GetAll().Where(u => u.Username == username && u.Email == username).FirstOrDefault();
            if (subj == null)
                return BadRequest("User was not found");

            var id = subj.Id.ToString();
            var persistedGrants = this._unitOfWork.PersistedGrants.GetAll().Where(p => String.Equals(p.SubjectId, id));
            this._unitOfWork.PersistedGrants.RemoveRange(persistedGrants);
            this._unitOfWork.Complete();

            return Ok(persistedGrants.Count());
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] User item)
        {
            //item.UpdateTime = DateTime.Now;
            if (String.IsNullOrEmpty(item.Email) || String.IsNullOrEmpty(item.Password))
                return StatusCode(400, Json("Provide Email and Password"));

            var exists = _unitOfWork.Users.Find(u => u.Email == item.Email).Count() > 0;
            if (exists)
                return StatusCode(400, Json("Email is already taken"));


            item.Username = item.Email;
            item.Active = true;
            item.EmailVerified = true;
            item.SekaniLevelId = _unitOfWork.SekaniLevels.Find(x => x.Id > 0).FirstOrDefault().Id;

            item.Password = Crypto.HashPassword(item.Password);
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
