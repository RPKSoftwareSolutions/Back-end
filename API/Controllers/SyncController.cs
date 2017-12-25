using AuthServer.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SyncController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [HttpGet("sekaniLevels")]
        public ActionResult GetSekaniLevels(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch(FormatException)
            {
                return StatusCode(400);
            }
            var items = _unitOfWork.Levels.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniWordTypes")]
        public ActionResult GetSekaniWordTypes(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch (FormatException)
            {
                return StatusCode(400);
            }
            var items = _unitOfWork.SekaniWordTypes.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniWords")]
        public ActionResult GetSekaniWords(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch (FormatException)
            {
                return StatusCode(400);
            }
            var levels = _unitOfWork.SekaniWords.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(levels);
        }

        [HttpGet("sekaniWWTs")]
        public ActionResult GetSekaniWWTs(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch (FormatException)
            {
                return StatusCode(400);
            }
            var levels = _unitOfWork.SekaniWWTs.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(levels);
        }

        [HttpGet("translationsOfSekani")]
        public ActionResult TranslationsOfSekani(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch (FormatException)
            {
                return StatusCode(400);
            }
            var levels = _unitOfWork.TranslationsOfSekani.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(levels);
        }

        [HttpGet("sekaniPhotos")]
        public ActionResult SekaniPhotos(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch (FormatException)
            {
                return StatusCode(400);
            }
            var levels = _unitOfWork.SekaniPhotos.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(levels);
        }

        [HttpGet("sekaniSounds")]
        public ActionResult SekaniSounds(string timestamp)
        {
            DateTime time;
            try
            {
                time = Convert.ToDateTime(timestamp);
            }
            catch (FormatException)
            {
                return StatusCode(400);
            }
            var levels = _unitOfWork.SekaniSounds.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(levels);
        }



        public SyncController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


    }
}
