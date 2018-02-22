using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        //v
        public virtual ICollection<SekaniWord> SekaniWords { get; set; }

        public Category()
        {
            this.SekaniWords = new Collection<SekaniWord>();
        }
    }
}
