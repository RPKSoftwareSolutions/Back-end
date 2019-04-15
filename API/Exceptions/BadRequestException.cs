using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TKD.Framework.Core;

namespace API.Exceptions
{
    public class BadRequestException:DomainException
    {
        public BadRequestException() : base((int)HttpStatusCode.BadRequest, "Bad Request. Your sent a request that this server could not understand.")
        {
        }
    }
}
