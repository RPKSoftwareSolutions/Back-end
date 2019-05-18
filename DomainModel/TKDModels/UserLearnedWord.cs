﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TKD.Domain.AuthenticateModels;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Domain.TKDModels
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
