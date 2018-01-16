using AuthServer.Generic;
using IdentityServer4.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IConfiguration _configuration;
        public TestController(IUnitOfWork unitOfWork/*, IConfiguration config*/)
        {
            this._unitOfWork = unitOfWork;
            //this._configuration = config;
        }

        
    }
}
