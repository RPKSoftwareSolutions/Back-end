using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TKD.Domain.TKDModels
{
    public class EnglishWord
    {
        [Key]
        public int Id { get; set; }

        public string Word { get; set; }

        // determines whether this word should show up in the English side of the dictionary
        public bool Standard { get; set; }

        public DateTime UpdateTime { get; set; }

        public virtual ICollection<SekaniRootEnglishWord> SekaniRootsEnglishWords { get; set; }

        public EnglishWord()
        {
            this.SekaniRootsEnglishWords = new Collection<SekaniRootEnglishWord>();
        }
    }
}
