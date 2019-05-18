using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.Domain.TKDModels
{
    public class SekaniRootEnglishWord
    {
        [Key]
        public int Id { get; set; }

        public int EnglishWordId { get; set; }

        public int SekaniRootId { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("EnglishWordId")]
        public virtual EnglishWord EnglishWord { get; set; }

        [ForeignKey("SekaniRootId")]
        public virtual SekaniRoot SekaniRoot { get; set; }

        public SekaniRootEnglishWord()
        {

        }
    }
}
