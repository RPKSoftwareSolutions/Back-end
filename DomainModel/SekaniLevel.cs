using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class SekaniLevel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        // trackers
        public DateTime UpdateTime { get; set; }

        // v
        public virtual ICollection<SekaniRoot> SekaniRoots { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public SekaniLevel()
        {
            this.SekaniRoots = new Collection<SekaniRoot>();
            this.Users = new Collection<User>();
        }
    }
}
