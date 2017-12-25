﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool Used { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
