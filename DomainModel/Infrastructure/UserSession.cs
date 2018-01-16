using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class UserSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public string Browser { get; set; }
        public string OperatingSystem { get; set; }
        public string DeviceId { get; set; }
        public DateTime? UpdateTime { get; set; } 
        public string RefreshToken { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
