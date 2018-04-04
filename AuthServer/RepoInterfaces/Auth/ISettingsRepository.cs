using AuthServer.Generic;
using DomainModel;
using DomainModel.OfflineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.RepoInterfaces
{
    public interface ISettingsRepository: IRepository<Setting>
    {
        SmtpSettings GetSmtpSettings();
    }
}
