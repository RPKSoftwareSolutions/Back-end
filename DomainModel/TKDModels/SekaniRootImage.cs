using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.DomainModel.TKDModels
{
    public class SekaniRootImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniRootId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("SekaniRootId")]
        public virtual SekaniRoot SekaniRoot { get; set; }

        public SekaniRootImage()
        {

        }

    }
}
