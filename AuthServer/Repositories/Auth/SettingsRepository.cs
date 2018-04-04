using AuthServer.Generic;
using AuthServer.RepoInterfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.OfflineModels;
using AuthServer.Auth;

namespace AuthServer.Repositories
{
    public class SettingsRepository : Repository<Setting>, ISettingsRepository
    {
        public SettingsRepository(AppDbContext _context) : base(_context) { }

        public SmtpSettings GetSmtpSettings()
        {
            var smtpSettings = new SmtpSettings
            {
                Server = AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Server").Value,
                Port = int.Parse(AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Port").Value),
                SenderAddress = AppContext.Settings.SingleOrDefault(s => s.Key == "Email_SenderAddress").Value,
                Username = AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Username").Value,
                Password = AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Password").Value
            };
            return smtpSettings;
        }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
