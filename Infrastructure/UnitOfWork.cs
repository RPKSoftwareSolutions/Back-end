
using TKD.Infrastructure.RepoInterfaces;
using TKD.Infrastructure.RepoInterfaces.Auth;
using TKD.Infrastructure.Repositories;
using TKD.Infrastructure.Repositories.Auth;

namespace TKD.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext context;

        public IAuthRepository Auth { get; set; }
        public IAccountRepository Users { get; set; }
        public IUserSessionRepository UserSessions { get; set; }
        public ISettingsRepository Settings { get; set; }
        public IClientRepository Clients { get; set; }
        public IPersistedGrantRepository PersistedGrants { get; set; }

        public ISekaniLevelRepository SekaniLevels { get; set; }
        public ISekaniWordRepository SekaniWords { get; set; }
        public ISekaniCategoryRepository SekaniCategories { get; set; }
        public ITopicRepository Topics { get; set; }
        public IEnglishWordRepository EnglishWords { get; set; }
        public ISekaniWordAudioRepository SekaniWordAudios { get; set; }

        public ISekaniRootRepository SekaniRoots { get; set; }
        public ISekaniRootImageRepository SekaniRootImages { get; set; }
        public ISekaniFormRepository SekaniForms { get; set; }
        public ISekaniWordExampleRepository SekaniWordExamples { get; set; }
        public ISekaniWordExampleAudioRepository SekaniWordExampleAudios { get; set; }
        public ISekaniWordAttributeRepository SekaniWordAttributes { get; set; }
        public ISekaniRootEnglishWordRepository SekaniRootsEnglishWords { get; set; }
        public ISekaniRootTopicRepository SekaniRootsTopics { get; set; }
        public IUserActivityStatRepository UserActivityStats { get; set; }
        public IUserLearnedWordRepository UserLearnedWords { get; set; }
        public IUserFailedWordRepository UserFailedWords { get; set; }

        public IGameRepository GameRepository { get; set; }
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Auth = new AuthRepository(this.context);
            Users = new AccountRepository(this.context);
            UserSessions = new UserSessionRepository(this.context);
            Settings = new SettingsRepository(this.context);
            Clients = new ClientRepository(this.context);
            PersistedGrants = new PersistentGrantRepository(this.context);

            SekaniLevels = new SekaniLevelRepository(this.context);
            SekaniWords = new SekaniWordRepository(this.context);
            SekaniCategories = new SekaniCategoryRepository(this.context);
            Topics = new TopicRepository(this.context);
            EnglishWords = new EnglishWordRepository(this.context);
            SekaniWordAudios = new SekaniWordAudioRepository(this.context);
            SekaniRoots = new SekaniRootRepository(this.context);
            SekaniRootImages = new SekaniRootImageRepository(this.context);
            SekaniForms = new SekaniFormRepository(this.context);
            SekaniWordExamples = new SekaniWordExampleRepository(this.context);
            SekaniWordExampleAudios = new SekaniWordExampleAudioRepository(this.context);
            SekaniWordAttributes = new SekaniWordAttributeRepository(this.context);
            SekaniRootsEnglishWords = new SekaniRootEnglishWordRepository(this.context);
            SekaniRootsTopics = new SekaniRootTopicRepository(this.context);
            UserActivityStats = new UserActivityStatRepository(this.context);
            UserLearnedWords = new UserLearnedWordRepository(this.context);
            UserFailedWords = new UserFailedWordRepository(this.context);
             GameRepository =new GameRepository(this.context);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
