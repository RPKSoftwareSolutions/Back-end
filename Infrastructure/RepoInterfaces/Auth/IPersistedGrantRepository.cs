using Framework.Core;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Infrastructure.RepoInterfaces.Auth
{
    public interface IPersistedGrantRepository: IRepository<PersistedGrant>
    {
    }
}
