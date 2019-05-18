using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.Domain.TKDModels
{
    public class SekaniRoot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public int SekaniLevelId { get; set; }

        [Required]
        public int SekaniCategoryId { get; set; }

        [Required]
        public int SekaniFormId { get; set; }

        public string RootWord { get; set; }

        public bool IsNull { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("SekaniLevelId")]
        public virtual SekaniLevel SekaniLevel { get; set; }

        [ForeignKey("SekaniCategoryId")]
        public virtual SekaniCategory SekaniCategory { get; set; }

        [ForeignKey("SekaniFormId")]
        public virtual SekaniForm SekaniForm { get; set; }

        public virtual ICollection<SekaniRootEnglishWord> SekaniRootsEnglishWords { get; set; }
        public virtual ICollection<SekaniRootImage> SekaniRootImages { get; set; }
        public virtual ICollection<SekaniWord> SekaniWords { get; set; }
        public virtual ICollection<SekaniRootTopic> SekaniRootsTopics { get; set; }

        public SekaniRoot()
        {
            SekaniRootsEnglishWords = new Collection<SekaniRootEnglishWord>();
            this.SekaniWords = new Collection<SekaniWord>();
            this.SekaniRootImages = new Collection<SekaniRootImage>();
            this.SekaniRootsTopics = new Collection<SekaniRootTopic>();
        }
    }
}
