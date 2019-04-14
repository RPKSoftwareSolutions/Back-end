using DomainModel.AuthenticateModels;
using Framework.Core;

namespace Infrastructure.RepoInterfaces.Auth
{
    public interface IPersistedGrantRepository: IRepository<PersistedGrant>
    {
    }
}
