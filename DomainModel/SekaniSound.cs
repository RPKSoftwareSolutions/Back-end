using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniSound
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniWwtId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string Notes { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        // v

        [ForeignKey("SekaniWwtId")]
        public virtual SekaniWWT SekaniWWT { get; set; }
    }
}
