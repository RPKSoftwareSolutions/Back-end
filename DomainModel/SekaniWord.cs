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

        [Required]
        public int CategoryId { get; set; }

        public int? EnglishWordId { get; set; }

        public string Word { get; set; }

        public string  Phonetic { get; set; }

       
        // trackers
        public DateTime UpdateTime { get; set; }

        
        // virtuals

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("EnglishWordId")]
        public virtual EnglishWord EnglishWord { get; set; }

        public virtual ICollection<Translation> TranslationsOfSekani { get; set; }
        
        public virtual ICollection<SekaniWordAudio> SekaniWordAudios { get; set; }


        public SekaniWord()
        {
            this.TranslationsOfSekani = new Collection<Translation>();
            this.SekaniWordAudios = new Collection<SekaniWordAudio>();
        }

    }
}
