﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DomainModel.AuthenticateModels;

namespace DomainModel
{
    public class UserLearnedWord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int SekaniWordId { get; set; }
        [Required]
        public int TryCount { get; set; }
        [Required]
        public DateTime AnswerDateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("SekaniWordId")]
        public virtual SekaniWord SekaniWord { get; set; }      

    }
}