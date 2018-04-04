using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniWordAttribute
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniWordId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("SekaniWordId")]
        public virtual SekaniWord SekaniWord { get; set; }

        public SekaniWordAttribute()
        {

        }
    }
}
