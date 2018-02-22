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

        public ILevelRepository Levels { get; set; }
        public ISekaniWordRepository SekaniWords { get; set; }
        public ITranslationRepository TranslationsOfSekani { get; set; }
        public ICategoryRepository Categories { get; set; }
        public ITopicRepository Topics { get; set; }
        public IEnglishWordRepository EnglishWords { get; set; }
        public ITranslation_TopicRepository Translations_Topics { get; set; }
        public ISekaniWordAudioRepository SekaniWordAudios { get; set; }
        public ITranslationExampleRepository TranslationExamples { get; set; }
        public ITranslationPhotoRepository TranslationPhotos { get; set; }
        public ITranslationExampleAudioRepository TranslationExampleAudios { get; set; }


        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Auth = new AuthRepository(this._context);
            Users = new AccountRepository(this._context);
            UserSessions = new UserSessionRepository(this._context);
            Settings = new SettingsRepository(this._context);
            Clients = new ClientRepository(this._context);
            PersistedGrants = new PersistentGrantRepository(this._context);

            Levels = new LevelRepository(this._context);
            SekaniWords = new SekaniWordRepository(this._context);
            TranslationsOfSekani = new TranslationRepository(this._context);
            Categories = new CategoryRepository(this._context);
            Topics  = new TopicRepository(this._context);
            EnglishWords = new EnglishWordRepository(this._context);
            Translations_Topics = new Translation_TopicRepository(this._context);
            SekaniWordAudios = new SekaniWordAudioRepository(this._context);
            TranslationExamples = new TranslationExampleRepository(this._context);
            TranslationPhotos = new TranslationPhotoRepository(this._context);
            TranslationExampleAudios = new TranslationExampleAudioRepository(this._context);


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
