using AuthServer.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository Auth { get; set; }
        IAccountRepository Users { get; set; }
        IUserSessionRepository UserSessions { get; set; }
        IClientRepository Clients { get; set; }
        ISettingsRepository Settings { get; set; }
        ILevelRepository Levels { get; set; }
        ISekaniPhotoRepository SekaniPhotos { get; set; }
        ISekaniSoundRepository SekaniSounds { get; set; }
        ISekaniWordRepository SekaniWords { get; set; }
        ISekaniWordTypeRepository SekaniWordTypes { get; set; }
        ISekaniWWTRepository SekaniWWTs { get; set; }
        ITranslationOfSekaniRepository TranslationsOfSekani { get; set; }

        int Complete();
    }
}
