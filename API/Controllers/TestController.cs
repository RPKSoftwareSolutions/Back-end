using IdentityServer4.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using TKD.Infrastructure;

namespace API.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IConfiguration _configuration;
        public TestController(IUnitOfWork unitOfWork/*, IConfiguration config*/)
        {
            this._unitOfWork = unitOfWork;
            //this._configuration = config;
        }

        [Authorize]
        [HttpGet("test/{param}")]
        public ActionResult test(string param)
        {
            var s = param.Sha256();
            var bil = CryptoHelper.Crypto.VerifyHashedPassword(s, "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=");

            return Ok(bil);
        }

        [HttpGet("client")]
        public ActionResult client(string param)
        {
            //this._unitOfWork.Clients.Add(new DomainModel.Client)

            var i = this._unitOfWork.SekaniCategories.GetAll();

            var items = this._unitOfWork.Clients.GetAll();
            return Ok(items);
        }
    }


}
