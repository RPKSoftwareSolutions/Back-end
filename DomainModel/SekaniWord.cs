﻿using System;
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
        public int SekaniFormId { get; set; }

        [Required]
        public int SekaniRootId { get; set; }

        public string Word { get; set; }

        public string  Phonetic { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        
        // virtuals     
   
        [ForeignKey("SekaniFormId")]
        public virtual SekaniForm SekaniForm { get; set; }

        [ForeignKey("SekaniRootId")]
        public virtual SekaniRoot SekaniRoot { get; set; }

        
        public virtual ICollection<SekaniWordAudio> SekaniWordAudios { get; set; }
        public virtual ICollection<SekaniWordExample> SekaniWordExamples { get; set; }
        public virtual ICollection<SekaniWordAttribute> SekaniWordAttributes { get; set; }


        public SekaniWord()
        {
            this.SekaniWordAudios = new Collection<SekaniWordAudio>();
            this.SekaniWordAttributes = new Collection<SekaniWordAttribute>();
            this.SekaniWordExamples = new Collection<SekaniWordExample>();
        }

    }
}
