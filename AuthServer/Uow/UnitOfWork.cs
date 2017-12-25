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
        public ISettingsRepository Settings { get; set; }

        public ILevelRepository Levels { get; set; }
        public ISekaniWordTypeRepository SekaniWordTypes { get; set; }
        public ISekaniWordRepository SekaniWords { get; set; }
        public ISekaniWWTRepository SekaniWWTs { get; set; }
        public ITranslationOfSekaniRepository TranslationsOfSekani { get; set; }
        public ISekaniPhotoRepository SekaniPhotos { get; set; }
        public ISekaniSoundRepository SekaniSounds { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Auth = new AuthRepository(this._context);
            Users = new AccountRepository(this._context);
            Settings = new SettingsRepository(this._context);
            Levels = new LevelRepository(this._context);
            SekaniWordTypes = new SekaniWordTypeRepository(this._context);
            SekaniWords = new SekaniWordRepository(this._context);
            SekaniWWTs = new SekaniWWTRepository(this._context);
            TranslationsOfSekani = new TranslationOfSekaniRepository(this._context);
            SekaniPhotos = new SekaniPhotoRepository(this._context);
            SekaniSounds = new SekaniSoundRepository(this._context);
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
