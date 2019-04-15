using Framework.Core;
using TKD.DomainModel.AuthenticateModels;
using TKD.DomainModel.OfflineModels;

namespace TKD.Infrastructure.RepoInterfaces.Auth
{
    public interface ISettingsRepository: IRepository<Setting>
    {
        SmtpSettings GetSmtpSettings();
    }
}
