using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniWWT
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniWordId { get; set; }

        [Required]
        public int SekaniWordTypeId { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }


        // virtuals
        [ForeignKey("SekaniWordId")]
        public virtual SekaniWord SekaniWord { get; set; }

        [ForeignKey("SekaniWordTypeId")]
        public virtual SekaniWordType SekaniWordType { get; set; }

        public virtual ICollection<TranslationOfSekani> TranslationsOfSekani { get; set; }
        public virtual ICollection<SekaniPhoto> SekaniPhotos { get; set; }
        public virtual ICollection<SekaniSound> SekaniSounds { get; set; }

        public SekaniWWT()
        {
            this.TranslationsOfSekani = new Collection<TranslationOfSekani>();
            this.SekaniPhotos = new Collection<SekaniPhoto>();
            this.SekaniSounds = new Collection<SekaniSound>();
        }

    }
}
