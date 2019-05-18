using Framework.Core;
using TKD.Domain.AuthenticateModels;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Infrastructure.RepoInterfaces.Auth
{
    public interface IUserSessionRepository: IRepository<UserSession>
    {

    }
}
