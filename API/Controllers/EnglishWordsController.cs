using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EnglishWordsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EnglishWordsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, string query="", bool? standard = null)
        {
            IEnumerable<EnglishWord> items = this._unitOfWork.EnglishWords.GetAll();

            if (!string.IsNullOrEmpty(query))
                items = items.Where(i => i.Word.ToLower().Contains(query.ToLower()));
            if (standard == true)
                items = items.Where(i => i.Standard == true);

            var count = items.Count();

            IEnumerable<EnglishWord> subset;
            if (pageSize > 0)
            {
                subset = items
                    .OrderBy(i => i.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            }
            else
            {
                subset = items
                    .OrderBy(i => i.Word);
            }
            
            var R = PageRecordsSelector.GetPageRecords(subset, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.EnglishWords.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpGet("getSekaniRoots/{id}")]
        public ActionResult GetSekaniRoots(int id)
        {
            var ids = this._unitOfWork.SekaniRootsEnglishWords.Find(i => i.EnglishWordId == id).Select(i => i.SekaniRootId).ToList();
            var items = this._unitOfWork.SekaniRoots.Find(i => ids.Contains(i.Id))
                        .OrderBy(i => i.Id)
                        .Select(i => new
                        {
                            i.Id,
                            i.RootWord,
                            i.IsNull,
                            i.SekaniCategoryId,
                            i.SekaniLevelId,
                            i.SekaniFormId,
                            Level = _unitOfWork.SekaniLevels.Get(i.SekaniLevelId).Title,
                            Category = _unitOfWork.SekaniCategories.Get(i.SekaniCategoryId).Title,
                            Form = _unitOfWork.SekaniForms.Get(i.SekaniFormId).Title,
                            i.UpdateTime
                        });
            return Ok(items);
        }

        [HttpPost("removeSekaniRoots")]
        public ActionResult RemoveSekaniRoots([FromBody] AddRemoveSekaniRootsModel model)
        {
            var r = this._unitOfWork.SekaniRootsEnglishWords.Find(i => i.EnglishWordId == model.EnglishWordId
                                        && model.SekaniRootIds.Contains(i.SekaniRootId));
            this._unitOfWork.SekaniRootsEnglishWords.RemoveRange(r);
            this._unitOfWork.Complete();
            return Ok(r.Count());
        }

        [HttpPost("addSekaniRoots")]
        public ActionResult AddSekaniRoots([FromBody] AddRemoveSekaniRootsModel model)
        {
            int counter = 0;
            foreach (int eid in model.SekaniRootIds)
            {
                var item = new SekaniRootEnglishWord()
                {
                    SekaniRootId = eid,
                    EnglishWordId = model.EnglishWordId,
                    UpdateTime = DateTime.Now
                };
                this._unitOfWork.SekaniRootsEnglishWords.Add(item);
                try
                {
                    this._unitOfWork.Complete();
                    counter++;
                }
                catch (DbUpdateException x)
                {
                    // ignore
                }
            }
            return Ok(counter);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] EnglishWord item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.EnglishWords.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] EnglishWord item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.EnglishWords.Get(id);
            l.Standard = item.Standard;
            l.Word = item.Word;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var l = _unitOfWork.EnglishWords.Get(id);
            _unitOfWork.EnglishWords.Remove(l);
            _unitOfWork.Complete();
            return Ok();
        }

    }

    public class AddRemoveSekaniRootsModel
    {
        public int EnglishWordId { get; set; }
        public int[] SekaniRootIds { get; set; }
    }
}
