using DomainModel.AuthenticateModels;
using DomainModel.OfflineModels;
using Framework.Core;

namespace Infrastructure.RepoInterfaces.Auth
{
    public interface ISettingsRepository: IRepository<Setting>
    {
        SmtpSettings GetSmtpSettings();
    }
}
