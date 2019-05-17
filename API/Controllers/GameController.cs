using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Responses;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class GameController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public GameController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public GameInitialDataDto GetGameInit()
        {
            GameInitialDataDto resault=new GameInitialDataDto();
               var uyser = _unitofwork.UserActivityStats.Find(
                 a => a.UserId == UserHelper.GetCurrentUserId(User));

            return resault;
        }
    }
}