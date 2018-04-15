using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, string query="", int? levelId=null, int? categoryId=null, int? formId=null)
        {

            IEnumerable<SekaniRoot> items = this._unitOfWork.SekaniRoots.GetAll();

            if (!string.IsNullOrEmpty(query))
                items = items.Where(i => i.RootWord.ToLower().Contains(query.ToLower()));
            if (levelId != null && levelId != 0)
                items = items.Where(i => i.SekaniLevelId == levelId);
            if (categoryId != null && categoryId != 0)
                items = items.Where(i => i.SekaniCategoryId == categoryId);
            if (formId != null && formId != 0)
                items = items.Where(i => i.SekaniFormId == formId);

            var count = items.Count();
            IEnumerable<SekaniRoot> subset;
            if (pageSize > 0)
                subset = items
                    .OrderBy(i => i.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            else
                subset = items
                    .OrderBy(i => i.Id);

            var _items = subset
                .Select(item => new
                {
                    item.Id,
                    item.IsNull,
                    item.RootWord,
                    item.SekaniCategoryId,
                    item.SekaniFormId,
                    item.SekaniLevelId,
                    item.UpdateTime,
                    Level = pageSize > 0 ? _unitOfWork.SekaniLevels.Get(item.SekaniLevelId).Title : null,
                    Category = pageSize > 0 ? _unitOfWork.SekaniCategories.Get(item.SekaniCategoryId).Title: null,
                    Form = pageSize > 0 ? _unitOfWork.SekaniForms.Get(item.SekaniFormId).Title: null
                });


            var R = PageRecordsSelector.GetPageRecords(_items, pageSize, pageIndex, count);
            return Ok(R);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniRoots.Get(id);
            if (item == null) return new NotFoundResult();

            var r = new
            {
                item.Id,
                item.IsNull,
                item.RootWord,
                item.SekaniCategoryId,
                item.SekaniFormId,
                item.SekaniLevelId,
                item.UpdateTime,
                Level = _unitOfWork.SekaniLevels.Get(item.SekaniLevelId).Title,
                Category = _unitOfWork.SekaniCategories.Get(item.SekaniCategoryId).Title,
                Form = _unitOfWork.SekaniForms.Get(item.SekaniFormId).Title
            };

            return Ok(r);
        }

        [HttpGet("getEnglishWords/{id}")]
        public ActionResult GetEnglishWords(int id)
        {
            var ids = this._unitOfWork.SekaniRoots_EnglishWords.Find(i => i.SekaniRootId == id).Select(i => i.EnglishWordId).ToList();
            var items = this._unitOfWork.EnglishWords.Find(i => ids.Contains(i.Id))
                        .OrderBy(i => i.Id)
                        .Select(i => new
                        {
                            i.Id,
                            i.Word,
                            i.Standard,
                            i.UpdateTime
                        });
            return Ok(items);
        }

        [HttpPost("removeEnglishWords")]
        public ActionResult RemoveEnglishWords([FromBody] AddRemoveEnglishWordsModel model)
        {
            var r = this._unitOfWork.SekaniRoots_EnglishWords.Find(i => i.SekaniRootId == model.SekaniRootId &&
                                                                        model.EnglishWordIds.Contains(i.EnglishWordId)).ToList();
            this._unitOfWork.SekaniRoots_EnglishWords.RemoveRange(r);
            this._unitOfWork.Complete();
            return Ok(r.Count());
        }

        [HttpPost("addEnglishWords")]
        public ActionResult AddEnglishWords([FromBody] AddRemoveEnglishWordsModel model)
        {
            int counter = 0;
            foreach(int eid in model.EnglishWordIds)
            {
                var item = new SekaniRoot_EnglishWord()
                {
                    SekaniRootId = model.SekaniRootId,
                    EnglishWordId = eid,
                    UpdateTime = DateTime.Now
                };
                this._unitOfWork.SekaniRoots_EnglishWords.Add(item);
                try
                {
                    this._unitOfWork.Complete();
                    counter++;
                }
                catch(DbUpdateException x)
                {
                    // ignore
                }
            }
            return Ok(counter);
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

    public class AddRemoveEnglishWordsModel
    {
        public int SekaniRootId { get; set; }
        public int[] EnglishWordIds { get; set; }
    }
}
