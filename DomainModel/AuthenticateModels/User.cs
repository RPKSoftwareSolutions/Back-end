﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TKD.Domain.TKDModels;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Domain.AuthenticateModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [DefaultValue(false)]
        public bool EmailVerified { get; set; }

        [DefaultValue(false)]
        public bool PhoneNumberVerified { get; set; }

        
       

        // user's claims...
        public virtual ICollection<UserClaim> Claims { get; set; }

        // user's password reset token
        public virtual ICollection<PasswordResetToken> PasswordResetTokens { get; set; }

        // user's email verification token
        public virtual ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; }

        public virtual ICollection<UserActivityStat> ActivityStats { get; set; }

        public virtual ICollection<UserLearnedWord> UserLearnedWords { get; set; }
        
        public virtual ICollection<UserFailedWord> UserFailedWords { get; set; }

        public User()
        {
            Claims = new Collection<UserClaim>();
            PasswordResetTokens = new Collection<PasswordResetToken>();
            EmailVerificationTokens = new Collection<EmailVerificationToken>();
            ActivityStats = new Collection<UserActivityStat>();
            UserLearnedWords = new Collection<UserLearnedWord>();
            UserFailedWords = new Collection<UserFailedWord>();
        }

    }
}
