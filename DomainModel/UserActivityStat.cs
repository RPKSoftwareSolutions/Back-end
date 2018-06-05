using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
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
