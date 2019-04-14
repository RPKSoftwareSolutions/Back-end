using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class SekaniCategory
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }
        public byte[] Image { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        //v
        public virtual ICollection<SekaniRoot> SekaniRoots { get; set; }

        public SekaniCategory()
        {
            this.SekaniRoots = new Collection<SekaniRoot>();
        }
    }
}
