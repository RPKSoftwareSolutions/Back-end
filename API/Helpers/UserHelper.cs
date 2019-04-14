using System.Linq;
using System.Security.Claims;

namespace API.Helpers
{
    public static class UserHelper
    {
        public static int GetCurrentUserId(ClaimsPrincipal user)
        {
            return int.Parse(user.Identities.First().Claims.First(c => c.Type == "sub").Value);
        }
    }
}
