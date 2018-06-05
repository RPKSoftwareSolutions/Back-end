using AuthServer.Auth;
using AuthServer.Generic;
using AuthServer.RepoInterfaces;
using AuthServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;

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
        public ISekaniRoot_EnglishWordRepository SekaniRoots_EnglishWords { get; set; }
        public ISekaniRoot_TopicRepository SekaniRoots_Topics { get; set; }
        public IUserActivityStatRepository UserActivityStats { get; set; }
        public IUserLearntWordRepository UserLearntWords { get; set; }
        public IUserFailedWordRepository UserFailedWords { get; set; }


        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Auth = new AuthRepository(this._context);
            Users = new AccountRepository(this._context);
            UserSessions = new UserSessionRepository(this._context);
            Settings = new SettingsRepository(this._context);
            Clients = new ClientRepository(this._context);
            PersistedGrants = new PersistentGrantRepository(this._context);

            SekaniLevels = new SekaniLevelRepository(this._context);
            SekaniWords = new SekaniWordRepository(this._context);
            SekaniCategories = new SekaniCategoryRepository(this._context);
            Topics  = new TopicRepository(this._context);
            EnglishWords = new EnglishWordRepository(this._context);
            SekaniWordAudios = new SekaniWordAudioRepository(this._context);
            SekaniRoots = new SekaniRootRepository(this._context);
            SekaniRootImages = new SekaniRootImageRepository(this._context);
            SekaniForms = new SekaniFormRepository(this._context);
            SekaniWordExamples = new SekaniWordExampleRepository(this._context);
            SekaniWordExampleAudios = new SekaniWordExampleAudioRepository(this._context);
            SekaniWordAttributes = new SekaniWordAttributeRepository(this._context);
            SekaniRoots_EnglishWords = new SekaniRoot_EnglishWordRepository(this._context);
            SekaniRoots_Topics = new SekaniRoot_TopicRepository(this._context);
            UserActivityStats = new UserActivityStatRepository(this._context);
            UserLearntWords = new UserLearntWordRepository(this._context);
            UserFailedWords = new UserFailedWordRepository(this._context);
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
