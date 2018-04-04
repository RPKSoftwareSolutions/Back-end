using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniWordExample
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniWordId { get; set; }

        public string Sekani { get; set; }

        public string English { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("SekaniWordId")]
        public virtual SekaniWord SekaniWord { get; set; }

        public virtual ICollection<SekaniWordExampleAudio> SekaniWordExampleAudios { get; set; }

        public SekaniWordExample()
        {
            this.SekaniWordExampleAudios = new Collection<SekaniWordExampleAudio>();
        }
    }
}
