using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class TranslationExample
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TranslationId { get; set; }

        public string Sekani { get; set; }

        public string English { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("TranslationId")]
        public virtual Translation Translation { get; set; }

        public virtual ICollection<TranslationExampleAudio> TranslationExampleAudios { get; set; }

        public TranslationExample()
        {
            this.TranslationExampleAudios = new Collection<TranslationExampleAudio>();
        }

    }
}
