using TKD.DomainModel.AuthenticateModels;
using TKD.DomainModel.OfflineModels;
using TKD.Infrastructure.RepoInterfaces.Auth;

namespace TKD.Infrastructure.Repositories.Auth
{
    public class SettingsRepository : Repository<Setting>, ISettingsRepository
    {
        public SettingsRepository(AppDbContext _context) : base(_context) { }

        public SmtpSettings GetSmtpSettings()
        {
            var smtpSettings = new SmtpSettings
            {
                Server = "smtp.sendgrid.net",// AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Server").Value,
                Port = 587,// int.Parse(AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Port").Value),
                SenderAddress = "sender@test.com",// AppContext.Settings.SingleOrDefault(s => s.Key == "Email_SenderAddress").Value,
                Username = "azure_460f5c8d6f560f8c2ac43e45cbddeabc@azure.com",// AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Username").Value,
                Password = "TKDEmailServer123"// AppContext.Settings.SingleOrDefault(s => s.Key == "Email_Password").Value
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
