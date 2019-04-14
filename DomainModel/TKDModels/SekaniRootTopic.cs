using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniRootTopic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniRootId { get; set; }

        [Required]
        public int TopicId { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("SekaniRootId")]
        public virtual SekaniRoot SekaniRoot { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        public SekaniRootTopic()
        {

        }
    }
}
