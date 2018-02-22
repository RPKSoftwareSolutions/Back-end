using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class Translation_Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TranslationId { get; set; }

        [Required]
        public int TopicId { get; set; }

        public DateTime UpdateTime { get; set; }

        // v
        [ForeignKey("TranslationId")]
        public virtual Translation Translation { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

    }
}
