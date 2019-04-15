using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TKD.DomainModel.TKDModels
{
    public class SekaniWord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniRootId { get; set; }

        public string Word { get; set; }

        public string  Phonetic { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        
        // virtuals     

        [ForeignKey("SekaniRootId")]
        public virtual SekaniRoot SekaniRoot { get; set; }

        
        public virtual ICollection<SekaniWordAudio> SekaniWordAudios { get; set; }
        public virtual ICollection<SekaniWordExample> SekaniWordExamples { get; set; }
        public virtual ICollection<SekaniWordAttribute> SekaniWordAttributes { get; set; }
        public virtual ICollection<UserLearnedWord> UsersLearnt { get; set; }
        public virtual ICollection<UserFailedWord> UsersFailed { get; set; }


        public SekaniWord()
        {
            this.SekaniWordAudios = new Collection<SekaniWordAudio>();
            this.SekaniWordAttributes = new Collection<SekaniWordAttribute>();
            this.SekaniWordExamples = new Collection<SekaniWordExample>();
            this.UsersLearnt = new Collection<UserLearnedWord>();
            this.UsersFailed = new Collection<UserFailedWord>();
        }

    }
}
