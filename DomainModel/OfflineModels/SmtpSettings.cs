namespace TKD.DomainModel.OfflineModels
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SenderAddress { get; set; }
        public int Port { get; set; }
    }
}
