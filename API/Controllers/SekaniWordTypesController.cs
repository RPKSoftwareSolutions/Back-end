using AuthServer.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SekaniWordTypesController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SekaniWordTypesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("get/{pageSize}/{pageIndex}")]
        public ActionResult GetAll(int pageSize = 20, int pageIndex = 1)
        {
            var items = _unitOfWork.SekaniWordTypes.GetAll()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderBy(s => s.Id);
            var R = PageRecordsSelector.GetPageRecords(items, pageSize, pageIndex);
            return Ok(R);
        }
    }
}
