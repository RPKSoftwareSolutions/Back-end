using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class TranslationPhoto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TranslationId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        //v

        [ForeignKey("TranslationId")]
        public virtual Translation Translation { get; set; }
    }
}
