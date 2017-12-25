using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Auth
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Core Infrastructure
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<EmailVerificationToken> EmailVerificationTokens { get; set; }
        public DbSet<Setting> Settings { get; set; }

        // Words & Translations 
        public DbSet<Level> Levels { get; set; }
        public DbSet<SekaniWord> SekaniWords { get; set; }
        public DbSet<SekaniWordType> SekaniWordTypes { get; set; }
        public DbSet<SekaniWWT> SekaniWWTs { get; set; }
        public DbSet<TranslationOfSekani> TranslationsOfSekani { get; set; }
        public DbSet<SekaniPhoto> SekaniPhotos { get; set; }
        public DbSet<SekaniSound> SekaniSound { get; set; }
    }
}
