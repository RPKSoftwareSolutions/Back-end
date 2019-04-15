using System.Collections.Generic;
using Framework.Core;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Infrastructure.RepoInterfaces.Auth
{
    public interface IAuthRepository: IRepository<User>
    {
        bool ValidatePassword(string username, string plainPassword);
        IEnumerable<UserClaim> GetUserClaims(int userId);
    }
}
