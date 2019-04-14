using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GameController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public GameController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        //public JsonResult GetGameInit()
        //{
        //   var uyser= _unitofwork.UserActivityStats.Find(
        //        a => a.UserId == UserHelper.GetCurrentUserId(User));

        //    return Ok(null);
        //}
    }
}