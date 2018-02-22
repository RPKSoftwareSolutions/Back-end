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
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<EmailVerificationToken> EmailVerificationTokens { get; set; }
        public DbSet<Setting> Settings { get; set; }
        // extra core
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientSecret> ClientSecrets { get; set; }
        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }
        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public DbSet<ClientScope> ClientScopes { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }


        // Words & Translations 
        public DbSet<Level> Levels { get; set; }
        public DbSet<SekaniWord> SekaniWords { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<EnglishWord> EnglishWords { get; set; }
        public DbSet<SekaniWordAudio> SekaniWordAudios { get; set; }
        public DbSet<Translation_Topic> Translations_Topics { get; set; }
        public DbSet<TranslationExample> TranslationExamples { get; set; }
        public DbSet<TranslationExampleAudio> TranslationExampleAudios { get; set; }
        public DbSet<TranslationPhoto> TranslationPhotos { get; set; }

    }
}
