using System.Collections.Generic;
using DomainModel.AuthenticateModels;
using Framework.Core;

namespace Infrastructure.RepoInterfaces.Auth
{
    public interface IAuthRepository: IRepository<User>
    {
        bool ValidatePassword(string username, string plainPassword);
        IEnumerable<UserClaim> GetUserClaims(int userId);
    }
}
