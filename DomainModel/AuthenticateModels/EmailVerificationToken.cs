using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TKD.Domain.AuthenticateModels;

namespace TKD.DomainModel.AuthenticateModels
{
    public class EmailVerificationToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Token { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime ExpiryTime { get; set; }

        public bool Used { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
