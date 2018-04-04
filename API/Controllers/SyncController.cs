using API.ParamModels;
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


        /// <summary>
        /// Returns all of the levels that are created or modified after a certain timestamp
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        [HttpGet("sekaniLevels/{timestamp}")]
        public ActionResult GetSekaniLevels(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);

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

        /// <summary>
        /// returns a set of IDs for all of the levels that exist in front-end but have been removed from the back-end.
        /// </summary>
        /// <param name="ids">all of the available level Ids in the front-end.</param>
        /// <returns></returns>
        [HttpPost("sekaniLevelsDeleted")]
        public ActionResult GetSekaniLevelsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.Levels.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
               extras = deletedIds
            };
            return Ok(obj);
        }

        /*
        [HttpGet("sekaniWordTypes/{timestamp}")]
        public ActionResult GetSekaniWordTypes(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);
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

        [HttpPost("sekaniWordTypesDeleted")]
        public ActionResult GetSekaniWordTypesDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);
            var items = _unitOfWork.SekaniWordTypes.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }
        */

        [HttpGet("sekaniWords/{timestamp}")]
        public ActionResult GetSekaniWords(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);

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

        [HttpPost("sekaniWordsDeleted")]
        public ActionResult GetSekaniWordsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);
            var items = _unitOfWork.SekaniWords.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        /*
        [HttpGet("sekaniWWTs/{timestamp}")]
        public ActionResult GetSekaniWWTs(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);

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

        [HttpPost("sekaniWWTsDeleted")]
        public ActionResult GetSekaniWWTsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);
            var items = _unitOfWork.SekaniWWTs.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }
        */

        /*
        [HttpGet("translationsOfSekani/{timestamp}")]
        public ActionResult TranslationsOfSekani(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);

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

        [HttpPost("translationsOfSekaniDeleted")]
        public ActionResult GetTranslationsOfSekaniDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);
            var items = _unitOfWork.TranslationsOfSekani.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }
        */


        /*
        [HttpGet("sekaniPhotos/{timestamp}")]
        public ActionResult SekaniPhotos(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);

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

        [HttpPost("sekaniPhotosDeleted")]
        public ActionResult GetSekaniPhotosDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);
            var items = _unitOfWork.SekaniPhotos.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpGet("sekaniSounds/{timestamp}")]
        public ActionResult SekaniSounds(string timestamp)
        {
            if (String.IsNullOrEmpty(timestamp))
                return StatusCode(400);

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

        [HttpPost("sekaniSoundsDeleted")]
        public ActionResult GetSekaniSoundsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);
            var items = _unitOfWork.SekaniSounds.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        */

        public SyncController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


    }
}
