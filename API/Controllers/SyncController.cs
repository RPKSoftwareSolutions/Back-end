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
            var items = _unitOfWork.SekaniLevels.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniCategories/{timestamp}")]
        public ActionResult GetSekaniCategories(string timestamp)
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
            var items = _unitOfWork.SekaniCategories.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniForms/{timestamp}")]
        public ActionResult GetSekaniForms(string timestamp)
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
            var items = _unitOfWork.SekaniForms.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("englishWords/{timestamp}")]
        public ActionResult GetEnglishWords(string timestamp)
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
            var items = _unitOfWork.EnglishWords.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniRootImages/{timestamp}")]
        public ActionResult GetSekaniRootImages(string timestamp)
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
            var items = _unitOfWork.SekaniRootImages.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniRoots/{timestamp}")]
        public ActionResult GetSekaniRoots(string timestamp)
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
            var items = _unitOfWork.SekaniRoots.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniRoots_EnglishWords/{timestamp}")]
        public ActionResult GetSekaniRoot_EnglishWords(string timestamp)
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
            var items = _unitOfWork.SekaniRoots_EnglishWords.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniRoots_Topics/{timestamp}")]
        public ActionResult GetSekaniRoots_Topics(string timestamp)
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
            var items = _unitOfWork.SekaniRoots_Topics.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniWordAttributes/{timestamp}")]
        public ActionResult GetSekaniWordAttributes(string timestamp)
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
            var items = _unitOfWork.SekaniWordAttributes.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniWordAudios/{timestamp}")]
        public ActionResult GetSekaniWordAudios(string timestamp)
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
            var items = _unitOfWork.SekaniWordAudios.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniWordExampleAudios/{timestamp}")]
        public ActionResult GetSekaniWordExampleAudios(string timestamp)
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
            var items = _unitOfWork.SekaniWordExampleAudios.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("sekaniWordExamples/{timestamp}")]
        public ActionResult GetSekaniWordExamples(string timestamp)
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
            var items = _unitOfWork.SekaniWordExamples.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

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
            var items = _unitOfWork.SekaniWords.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
            return Ok(items);
        }

        [HttpGet("topics/{timestamp}")]
        public ActionResult GetTopics(string timestamp)
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
            var items = _unitOfWork.Topics.Find(x => DateTime.Compare(x.UpdateTime, time) > 0);
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

            var items = _unitOfWork.SekaniLevels.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
               extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("englishWordsDeleted")]
        public ActionResult GetEnglishWordsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.EnglishWords.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniCategoriesDeleted")]
        public ActionResult GetSekaniCategoriesDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniCategories.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniFormsDeleted")]
        public ActionResult GetSekaniFormsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniForms.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniRootImagesDeleted")]
        public ActionResult GetSekaniRootImagesDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniRootImages.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniRootsDeleted")]
        public ActionResult GetSekaniRootsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniRoots.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniRoots_EnglishWordsDeleted")]
        public ActionResult GetSekaniRoots_EnglishWordsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniRoots_EnglishWords.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniRoots_TopicsDeleted")]
        public ActionResult GetSekaniRoots_TopicsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniRoots_Topics.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniWordAttributesDeleted")]
        public ActionResult GetSekaniWordAttributesDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniWordAttributes.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniWordAudiosDeleted")]
        public ActionResult GetSekaniWordAudiosDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniWordAudios.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniWordExampleAudiosDeleted")]
        public ActionResult GetSekaniWordExampleAudiosDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniWordExampleAudios.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("sekaniWordExamplesDeleted")]
        public ActionResult GetSekaniWordExamplesDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.SekaniWordExamples.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("topicsDeleted")]
        public ActionResult GetTopicsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
                return StatusCode(400);

            var items = _unitOfWork.Topics.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
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




        public SyncController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


    }
}
