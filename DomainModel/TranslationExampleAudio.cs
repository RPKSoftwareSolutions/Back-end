using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class TranslationExampleAudio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TranslationExampleId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        //v
        [ForeignKey("TranslationExampleId")]
        public virtual TranslationExample TranslationExample { get; set; }

    }
}
