using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class Translation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniWordId { get; set; }

        public string Translationx { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        // v
        [ForeignKey("SekaniWordId")]
        public virtual SekaniWord SekaniWord { get; set; }
        
        public virtual ICollection<Translation_Topic> Translations_Topics { get; set; }
        public virtual ICollection<TranslationPhoto> TranslationPhotos { get; set; }
        public virtual ICollection<TranslationExample> TranslationExamples { get; set; }

        public Translation()
        {
            this.Translations_Topics = new Collection<Translation_Topic>();
            this.TranslationPhotos = new Collection<TranslationPhoto>();
            this.TranslationExamples = new Collection<TranslationExample>();
        }

    }
}
