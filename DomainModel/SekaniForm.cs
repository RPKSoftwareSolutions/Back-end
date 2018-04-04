﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class SekaniForm
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        public virtual ICollection<SekaniWord> SekaniWords { get; set; }


        public SekaniForm()
        {
            this.SekaniWords = new Collection<SekaniWord>();
        }
    }
}