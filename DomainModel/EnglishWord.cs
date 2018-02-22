using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class EnglishWord
    {
        [Key]
        public int Id { get; set; }

        public string Word { get; set; }

        public DateTime UpdateTime { get; set; }

        //v
        public virtual ICollection<SekaniWord> SekaniWords { get; set; }

        public EnglishWord()
        {
            this.SekaniWords = new Collection<SekaniWord>();
        }
    }
}
