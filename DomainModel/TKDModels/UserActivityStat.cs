using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TKD.Domain.AuthenticateModels;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Domain.TKDModels
{
    public class UserActivityStat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Variable { get; set; }

        public string Value { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
