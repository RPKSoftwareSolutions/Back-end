using API.Helpers;
using API.ParamModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TKD.Infrastructure;
using TKD.ReadModel.Contract;
using TKD.ReadModel.Contract.DomainDto;

namespace API.Controllers
{
    [Route("[controller]")]
    public class SyncController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SyncController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Returns all of the levels that are created or modified after a certain timestamp
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        [HttpGet("sekaniLevels/{timestamp}")]
        public IList<SekaniLevelDto> GetSekaniLevels(DateTime timestamp)
        {
            var items = _unitOfWork.SekaniLevels.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniLevelDto>>(items);
        }

        [HttpGet("sekaniCategories/{timestamp}")]
        public IList<SekaniCategoryDto> GetSekaniCategories(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniCategories.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniCategoryDto>>(items);
        }

        [HttpGet("sekaniForms/{timestamp}")]
        public IList<SekaniFormDto> GetSekaniForms(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniForms.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniFormDto>>(items);
        }

        [HttpGet("englishWords/{timestamp}")]
        public IList<EnglishWordDto> GetEnglishWords(DateTime timestamp)
        {

            var items = _unitOfWork.EnglishWords.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<EnglishWordDto>>(items);
        }

        [HttpGet("sekaniRootImages/{timestamp}")]
        public IList<SekaniRootImageDto> GetSekaniRootImages(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniRootImages.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniRootImageDto>>(items);
        }

        [HttpGet("sekaniRoots/{timestamp}")]
        public IList<SekaniRootDto> GetSekaniRoots(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniRoots.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniRootDto>>(items);
        }

        [HttpGet("sekaniRoots_EnglishWords/{timestamp}")]
        public IList<SekaniRootEnglishWordDto> GetSekaniRootEnglishWords(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniRootsEnglishWords.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniRootEnglishWordDto>>(items);
        }

        [HttpGet("sekaniRoots_Topics/{timestamp}")]
        public IList<SekaniRootTopicDto> GetSekaniRootsTopics(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniRootsTopics.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniRootTopicDto>>(items);
        }

        [HttpGet("sekaniWordAttributes/{timestamp}")]
        public IList<SekaniWordAttributeDto> GetSekaniWordAttributes(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniWordAttributes.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniWordAttributeDto>>(items);
        }

        [HttpGet("sekaniWordAudios/{timestamp}")]
        public IList<SekaniWordAudioDto> GetSekaniWordAudios(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniWordAudios.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniWordAudioDto>>(items);
        }

        [HttpGet("sekaniWordExampleAudios/{timestamp}")]
        public IList<SekaniWordExampleAudioDto> GetSekaniWordExampleAudios(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniWordExampleAudios.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniWordExampleAudioDto>>(items);
        }

        [HttpGet("sekaniWordExamples/{timestamp}")]
        public IList<SekaniWordExampleDto> GetSekaniWordExamples(DateTime timestamp)
        {
            var items = _unitOfWork.SekaniWordExamples.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniWordExampleDto>>(items);
        }

        [HttpGet("sekaniWords/{timestamp}")]
        public IList<SekaniWordDto> GetSekaniWords(DateTime timestamp)
        {

            var items = _unitOfWork.SekaniWords.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<SekaniWordDto>>(items);
        }

        [HttpGet("topics/{timestamp}")]
        public IList<TopicDto> GetTopics(DateTime timestamp)
        {

            var items = _unitOfWork.Topics.Find(x => DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<TopicDto>>(items);
        }

        [Authorize]
        [HttpGet("userActivityStats/{timestamp}")]
        public IList<UserActivityStatDto> GetUserActivityStats(DateTime timestamp)
        {

            var items = _unitOfWork.UserActivityStats
                    .Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<UserActivityStatDto>>(items);
        }

        [Authorize]
        [HttpGet("UserLearnedWords/{timestamp}")]
        public IList<UserLearnedWordDto> GetUserLearnedWords(DateTime timestamp)
        {

            var items = _unitOfWork.UserLearnedWords.Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<UserLearnedWordDto>>(items);
        }

        [Authorize]
        [HttpGet("userFailedWords/{timestamp}")]
        public IList<UserFailedWordDto> GetUserFailedWords(DateTime timestamp)
        {

            var items = _unitOfWork.UserFailedWords.Find(x => x.UserId == UserHelper.GetCurrentUserId(User) && DateTime.Compare(x.UpdateTime, timestamp) > 0);
            return _mapper.Map<IList<UserFailedWordDto>>(items);
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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

            var items = _unitOfWork.SekaniRootsEnglishWords.GetAll().Select(x => x.Id);
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
            {
                return StatusCode(400);
            }

            var items = _unitOfWork.SekaniRootsTopics.GetAll().Select(x => x.Id);
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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

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
            {
                return StatusCode(400);
            }

            var items = _unitOfWork.SekaniWords.GetAll().Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("userActivityStatsDeleted")]
        public ActionResult GetUserActivityStatsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
            {
                return StatusCode(400);
            }

            var items = _unitOfWork.UserActivityStats.GetAll().Where(x => x.UserId == UserHelper.GetCurrentUserId(User)).Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("UserLearnedWordsDeleted")]
        public ActionResult GetUserLearnedWordsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
            {
                return StatusCode(400);
            }

            var items = _unitOfWork.UserLearnedWords.GetAll().Where(x => x.UserId == UserHelper.GetCurrentUserId(User)).Select(x => x.Id);
            var deletedIds = ids.Ids.Except(items);
            var obj = new
            {
                extras = deletedIds
            };
            return Ok(obj);
        }

        [HttpPost("userFailedWordsDeleted")]
        public ActionResult GetUserFailedWordsDeleted([FromBody] IdArray ids)
        {
            if (ids.Ids.Length == 0)
            {
                return StatusCode(400);
            }

            var items = _unitOfWork.UserFailedWords.GetAll().Where(x => x.UserId == UserHelper.GetCurrentUserId(User)).Select(x => x.Id);
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






        /*private int GetCurrentUserId(ClaimsPrincipal User)
        {
            return int.Parse(User.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "sub").Value);
        }*/


    }
}
