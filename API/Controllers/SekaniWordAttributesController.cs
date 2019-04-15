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
    public class SekaniWordAttributesController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordAttributesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, int sekaniWordId = 0)
        {
            var items = this._unitOfWork.SekaniWordAttributes.GetAll().Where(i => i.SekaniWordId == sekaniWordId);
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

        [HttpGet("getPossibleAttributes/{sekaniRootId}")]
        public ActionResult GetPossibleAttributes(int sekaniRootId)
        {
            try
            {
                var sekaniFormId = this._unitOfWork.SekaniRoots.Get(sekaniRootId).SekaniFormId;
                var form = this._unitOfWork.SekaniForms.Get(sekaniFormId).Title;
                switch (form)
                {
                    case "General Verb":
                        var x = new[]
                        {
                            new { title = "tense", options = new string[] { "Imperfective", "Perfective", "Future", "Optative" }},
                            new { title = "plurality", options = new string[] { "1p", "2p", "3p" }},
                            new { title = "person", options = new string[] { "1s", "2s", "3s" }}
                        };
                        return Ok(x);
                        break;

                    case "Impersonal Verb":
                        var y = new[]
                        {
                            new { title = "tense", options = new string[] { "Imperfective", "Perfective", "Future", "Optative" }},
                            new { title = "person", options = new string[] { "s1", "s2" }}
                        };
                        return Ok(y);
                        break;

                    case "General Noun":
                        var z = new string[]
                        {
                            
                        };
                        return Ok(z);
                        break;

                    case "Possessive Noun":
                        var w = new[]
                        {
                            new { title = "type", options = new string[] { "1s", "2s", "3s", "1p", "2p", "3p", "refl", "dir", "recip", "pref", "pdjr", "indef" }}
                        };
                        return Ok(w);
                        break;
                    default:
                        return Ok();
                }
            }
            catch(NullReferenceException)
            {
                return BadRequest("Sekani Form Id was not found.");
            }
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
