using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniWord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LevelId { get; set; }

        public string Word { get; set; }

        public string  Phonetic { get; set; }

       
        // trackers
        public DateTime UpdateTime { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        
        // virtuals

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public virtual ICollection<SekaniWWT> SekaniWWTs { get; set; }

        public SekaniWord()
        {
            this.SekaniWWTs = new Collection<SekaniWWT>();
        }

    }
}
