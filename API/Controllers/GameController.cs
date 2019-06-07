using API.Helpers;
using API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public GameInitialDataDto GetGameInit(int topicId,bool isPracticeMode)
        {
            var userId = UserHelper.GetCurrentUserId(User);
            var userinfo = GetUserInfo();
            GameInitialDataDto result = new GameInitialDataDto();
            result.UserInfo = userinfo;
            if (!isPracticeMode)
            {
                if (userinfo.TotalRoundCount == (userinfo.CorrectAnswersCount + userinfo.FailedRoundCount))
                {
                    throw new DomainException(502, "User Finished Rounds");
                }

                if (userinfo.Life == 0)
                {
                    throw new DomainException(502, "User Life IS Finished");
                }
            }

            Random random = new Random(DateTime.Now.Millisecond);
            result.GameType = random.Next(1, 3);
            if (result.GameType == 1)
            {
                result.GameData = JsonConvert.SerializeObject(GetGame1Data(userId, userinfo.UserLevel, topicId));
            }
            else if (result.GameType == 2)
            {
                result.GameData = JsonConvert.SerializeObject(GetGame2Data(userId, userinfo.UserLevel, topicId));
            }

            return result;
        }

        [HttpGet("GetGame2Init")]
        public GameInitialDataDto GetGame2Init(int topicId)
        {
            var userId = UserHelper.GetCurrentUserId(User);
            var userinfo = GetUserInfo();
            GameInitialDataDto result = new GameInitialDataDto();
            result.UserInfo = userinfo;
            result.GameType = 2;
            result.GameData = JsonConvert.SerializeObject(GetGame2Data(userId, userinfo.UserLevel, topicId));
            return result;
        }
        [HttpPost("GetUserInformation")]
        public UserInfo GetUserInformation()
        {
            return GetUserInfo();
        }
        [HttpPost("CorrectAnswer")]
        public UserInfo CorrectAnswer(int sekaniWordId)
        {
            return GetUserInfo();
        }

        [HttpPost("FailAnswer")]
        public UserInfo FailAnswer(int sekaniWordId)
        {
            return GetUserInfo();
        }

        private Game1Data GetGame1Data(int userId, int userLevel, int topicId)
        {
            Game1Data data = new Game1Data();
            var sekaniWord = _unitOfWork.GameRepository.GetRandomSekaniWord(userId, userLevel, 1, topicId).First();
            data.SekaniWordId = sekaniWord.Id;
            data.CurrentEnglishWord = sekaniWord.SekaniRoot.SekaniRootsEnglishWords.First().EnglishWord.Id;
            data.EnglishWords.Add(data.CurrentEnglishWord);
            var otherEnglishWords = _unitOfWork.GameRepository.GetDifferentEnglishWords(sekaniWord.SekaniRootId)
                .Select(a => a.Id).ToList();
            data.EnglishWords.AddRange(otherEnglishWords);
            return data;
        }
        private List<Game2Data> GetGame2Data(int userId, int userLevel, int topicId)
        {
            List<Game2Data> Game2data = new List<Game2Data>();
            var sekaniWords = _unitOfWork.GameRepository.GetRandomSekaniWord(userId, userLevel, 3, topicId);
            foreach (var item in sekaniWords)
            {
                Game2Data data = new Game2Data();
                data.SekaniWordId = item.Id;
                data.EnglishWordId = item.SekaniRoot.SekaniRootsEnglishWords.First().EnglishWord.Id;
                Game2data.Add(data);
            }
            return Game2data;
        }
        private UserInfo GetUserInfo()
        {
            var userId = UserHelper.GetCurrentUserId(User);
            UserInfo result = new UserInfo();
            var user = _unitOfWork.UserActivityStats
                .Find(a => a.UserId == userId)
                .ToList();
            result.UserLevel = int.Parse(user.Single(a => a.Variable == UserActivity.Level).Value);
            result.Life = int.Parse(user.Single(a => a.Variable == UserActivity.Life).Value);
            result.Score = int.Parse(user.Single(a => a.Variable == UserActivity.Score).Value);
            result.TotalRoundCount = int.Parse(user.Single(a => a.Variable == UserActivity.TotalRoundCount).Value);
            result.CorrectAnswersCount = int.Parse(user.Single(a => a.Variable == UserActivity.CorrectAnswersCount).Value);
            result.FailedRoundCount = int.Parse(user.Single(a => a.Variable == UserActivity.FailAnswersCount).Value);

            return result;
        }
    }
}