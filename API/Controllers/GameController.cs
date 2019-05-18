using API.Helpers;
using API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using TKD.Contracts;
using TKD.Framework.Core;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class GameController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetGameInit")]
        public GameInitialDataDto GetGameInit()
        {
            var userId = UserHelper.GetCurrentUserId(User);
            GameInitialDataDto result = new GameInitialDataDto();
            var user = _unitOfWork.UserActivityStats
                .Find(a => a.UserId == userId)
                .ToList();
            int userLevel = int.Parse(user.Single(a => a.Variable == UserActivity.Level).Value);
            result.Life = int.Parse(user.Single(a => a.Variable == UserActivity.Life).Value);
            result.Score = int.Parse(user.Single(a => a.Variable == UserActivity.Score).Value);
            result.TotalRoundCount = int.Parse(user.Single(a => a.Variable == UserActivity.TotalRoundCount).Value);
            result.CorrectAnswersCount = int.Parse(user.Single(a => a.Variable == UserActivity.CorrectAnswersCount).Value);
            result.FailedRoundCount = int.Parse(user.Single(a => a.Variable == UserActivity.FailAnswersCount).Value);

            if (result.TotalRoundCount == (result.CorrectAnswersCount + result.FailedRoundCount))
            {
                throw new DomainException(502, "User Finished Rounds");
            }

            if (result.Life == 0)
            {
                throw new DomainException(502, "User Life IS Finished");
            }

            result.GameType = 1;
            result.GameData = JsonConvert.SerializeObject(GetGame1Data(userId, userLevel));

            return result;
        }

        [HttpPost("CorrectAnswer")]
        public void CorrectAnswer(int sekaniWordId)
        {
            Ok();
        }
        [HttpPost("FailAnswer")]
        public void FailAnswer(int sekaniWordId)
        {
            Ok();
        }

        private Game1Data GetGame1Data(int userId, int userLevel)
        {
            Game1Data data = new Game1Data();
            var sekaniWord = _unitOfWork.GameRepository.GetRandomSekaniWord(userId, userLevel);
            data.SekaniWordId = sekaniWord.Id;
            data.CurrentEnglishWord = sekaniWord.SekaniRoot.SekaniRootsEnglishWords.First().EnglishWord.Id;
            data.EnglishWords.Add(data.CurrentEnglishWord);
            var otherEnglishWords = _unitOfWork.GameRepository.GetDifferentEnglishWords(sekaniWord.SekaniRootId)
                .Select(a => a.Id).ToList();
            data.EnglishWords.AddRange(otherEnglishWords);
            return data;
        }
    }
}