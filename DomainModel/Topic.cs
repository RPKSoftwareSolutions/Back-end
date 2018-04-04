﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        public virtual ICollection<SekaniRoot_Topic> SekaniRoots_Topics { get; set; }

        public Topic()
        {
            this.SekaniRoots_Topics = new Collection<SekaniRoot_Topic>();
        }

    }
}
