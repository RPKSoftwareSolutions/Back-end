using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using TKD.Domain.AuthenticateModels;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Domain.TKDModels
{
    public class SekaniLevel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public byte[] Image { get; set; }

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
