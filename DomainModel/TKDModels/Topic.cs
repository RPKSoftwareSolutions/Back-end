using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TKD.Domain.TKDModels
{

    public class Topic
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }
        public byte[] UnlockImage { get; set; }
        public byte[] LockImage { get; set; }

        public virtual ICollection<SekaniRootTopic> SekaniRootsTopics { get; set; }

        public Topic()
        {
            this.SekaniRootsTopics = new Collection<SekaniRootTopic>();
        }

    }
}
