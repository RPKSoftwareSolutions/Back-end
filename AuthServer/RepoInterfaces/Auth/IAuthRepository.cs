using AuthServer.Generic;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.RepoInterfaces
{
    public interface IAuthRepository: IRepository<User>
    {
        bool ValidatePassword(string username, string plainPassword);
        IEnumerable<UserClaim> GetUserClaims(int userId);
    }
}
