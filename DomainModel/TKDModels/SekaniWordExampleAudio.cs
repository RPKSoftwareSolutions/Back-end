﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class SekaniWordExampleAudio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SekaniWordExampleId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("SekaniWordExampleId")]
        public virtual SekaniWordExample SekaniWordExample { get; set; }

        public SekaniWordExampleAudio()
        {

        }
    }
}