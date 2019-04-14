using DomainModel;
using DomainModel.AuthenticateModels;
using DomainModel.TKDModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients", "auth");
            modelBuilder.Entity<User>().ToTable("Users", "auth");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", "auth");
            modelBuilder.Entity<UserSession>().ToTable("UserSessions", "auth");
            modelBuilder.Entity<PasswordResetToken>().ToTable("PasswordResetTokens", "auth");
            modelBuilder.Entity<EmailVerificationToken>().ToTable("EmailVerificationTokens", "auth");
            modelBuilder.Entity<ClientSecret>().ToTable("ClientSecrets", "auth");
            modelBuilder.Entity<ClientGrantType>().ToTable("ClientGrantTypes", "auth");
            modelBuilder.Entity<ClientCorsOrigin>().ToTable("ClientCorsOrigins", "auth");
            modelBuilder.Entity<ClientScope>().ToTable("ClientScopes", "auth");
            modelBuilder.Entity<PersistedGrant>().ToTable("PersistedGrants", "auth");

        }

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
        public DbSet<SekaniLevel> SekaniLevels { get; set; }
        public DbSet<SekaniWord> SekaniWords { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SekaniCategory> SekaniCategories{ get; set; }
        public DbSet<EnglishWord> EnglishWords { get; set; }
        public DbSet<SekaniWordAudio> SekaniWordAudios { get; set; }
        public DbSet<SekaniRoot> SekaniRoots { get; set; }
        public DbSet<SekaniRootImage> SekaniRootImages { get; set; }
        public DbSet<SekaniForm> SekaniForms { get; set; }
        public DbSet<SekaniWordExample> SekaniWordExamples { get; set; }
        public DbSet<SekaniWordAttribute> SekaniWordAttributes { get; set; }
        public DbSet<SekaniWordExampleAudio> SekaniWordExampleAudios { get; set; }
        public DbSet<SekaniRootEnglishWord> SekaniRoots_EnglishWords { get; set; }
        public DbSet<SekaniRootTopic> SekaniRoots_Topics { get; set; }
        public DbSet<UserActivityStat> UserActivityStats { get; set; }
        public DbSet<UserLearnedWord> UserLearnedWords { get; set; }
        public DbSet<UserFailedWord> UserFailedWords { get; set; }
        
    }
}
