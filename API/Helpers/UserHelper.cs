using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class UserHelper
    {
        public static int GetCurrentUserId(ClaimsPrincipal User)
        {
            return int.Parse(User.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "sub").Value);
        }
    }
}
