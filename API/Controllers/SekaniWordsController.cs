using API.Helpers;
using AuthServer.Generic;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniWordsController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        /*
        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1, int? levelId=null)
        {
            var items = _unitOfWork.SekaniWords.GetAll();
            if (levelId != null)
                items = items.Where(i => i.LevelId == levelId);

            var records = items
                   .OrderBy(s => s.Id)
                   .Skip((pageIndex - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => new
                   {
                       x.Id,
                       x.Word,
                       x.Phonetic,
                       x.UpdateTime,
                       x.LevelId,
                       Level = _unitOfWork.Levels.Get(x.LevelId).Title
                   });
            var R = PageRecordsSelector.GetPageRecords(records, pageSize, pageIndex);

            return Ok(R);
        }

        [HttpGet("getAll")]
        public ActionResult GetALL()
        {
            var items = _unitOfWork.SekaniWords.GetAll();
            var records = items.OrderBy(s => s.Word);
            return Ok(records);
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var item = this._unitOfWork.SekaniWords.Get(id);
            if (item == null) return new NotFoundResult();
            return Ok(item);
        }

        [HttpGet("getWordInFull/{id}")]
        public ActionResult GetFull(int id)
        {
            var wwtIds = _unitOfWork.SekaniWWTs.Find(w => w.SekaniWordId == id).Select(w => w.Id).ToList();

            var item = this._unitOfWork.SekaniWords.Find(i => i.Id == id)
                 .Select(s => new
                 {
                     s.Id,
                     Level = _unitOfWork.Levels.Get(s.LevelId).Title,
                     Translations = _unitOfWork.TranslationsOfSekani.Find(t => wwtIds.Contains(t.SekaniWwtId)).Select(t => new
                     {
                         t.Id,
                         t.Translation,
                         t.Example1,
                         t.Example2,
                         t.Example3,
                         t.UpdateTime
                     }).ToList()
            ,
            Photos = _unitOfWork.SekaniPhotos.Find(p => wwtIds.Contains(p.SekaniWwtId)).Select(p => new
            {
                p.Id,
                p.Content,
                p.Notes,
                p.UpdateTime
            }).ToList(),
            Sounds = _unitOfWork.SekaniSounds.Find(so => wwtIds.Contains(so.SekaniWwtId)).Select(so => new
            {
                so.Id,
                so.Content,
                so.Notes,
                so.UpdateTime
            }).ToList()
        });
            return Ok(item);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var item = _unitOfWork.SekaniWords.Get(id);
            _unitOfWork.SekaniWords.Remove(item);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] SekaniWord item)
        {
            item.UpdateTime = DateTime.Now;
            _unitOfWork.SekaniWords.Add(item);
            _unitOfWork.Complete();
            return Ok(item.Id);
        }

        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] SekaniWord item)
        {
            if (id != item.Id)
                return StatusCode(400);

            var l = _unitOfWork.SekaniWords.Get(id);
            l.LevelId = item.LevelId;
            l.Word = item.Word;
            l.Phonetic = item.Phonetic;
            l.UpdateTime = DateTime.Now;
            _unitOfWork.Complete();
            return Ok();
        }

        */
    }
}
