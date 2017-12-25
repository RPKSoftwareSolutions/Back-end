using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Level
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        // v
        public virtual ICollection<SekaniWord> SekaniWords { get; set; }

        public Level()
        {
            this.SekaniWords = new Collection<SekaniWord>();
        }
    }
}
