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
        IPersistedGrantRepository PersistedGrants { get; set; }
        ISettingsRepository Settings { get; set; }

        ILevelRepository Levels { get; set; }
        ISekaniWordRepository SekaniWords { get; set; }
        ITranslationRepository TranslationsOfSekani { get; set; }
        ICategoryRepository Categories { get; set; }
        ITopicRepository Topics { get; set; }
        IEnglishWordRepository EnglishWords { get; set; }
        ITranslation_TopicRepository Translations_Topics { get; set; }
        ISekaniWordAudioRepository SekaniWordAudios { get; set; }
        ITranslationExampleRepository TranslationExamples { get; set; }
        ITranslationPhotoRepository TranslationPhotos { get; set; }
        ITranslationExampleAudioRepository TranslationExampleAudios { get; set; }

        int Complete();
    }
}
