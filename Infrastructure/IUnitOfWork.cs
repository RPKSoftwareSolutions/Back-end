using System;
using Infrastructure.RepoInterfaces;
using Infrastructure.RepoInterfaces.Auth;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository Auth { get; set; }
        IAccountRepository Users { get; set; }
        IUserSessionRepository UserSessions { get; set; }
        IClientRepository Clients { get; set; }
        IPersistedGrantRepository PersistedGrants { get; set; }
        ISettingsRepository Settings { get; set; }

        ISekaniLevelRepository SekaniLevels { get; set; }
        ISekaniWordRepository SekaniWords { get; set; }
        ISekaniCategoryRepository SekaniCategories { get; set; }
        ITopicRepository Topics { get; set; }
        IEnglishWordRepository EnglishWords { get; set; }
        ISekaniWordAudioRepository SekaniWordAudios { get; set; }
        ISekaniRootRepository SekaniRoots { get; set; }
        ISekaniRootImageRepository SekaniRootImages { get; set; }
        ISekaniFormRepository SekaniForms { get; set; }
        ISekaniWordExampleRepository SekaniWordExamples { get; set; }
        ISekaniWordAttributeRepository SekaniWordAttributes { get; set; }
        ISekaniWordExampleAudioRepository SekaniWordExampleAudios { get; set; }
        ISekaniRoot_EnglishWordRepository SekaniRoots_EnglishWords { get; set; }
        ISekaniRoot_TopicRepository SekaniRoots_Topics { get; set; }
        IUserActivityStatRepository UserActivityStats { get; set; }
        IUserLearnedWordRepository UserLearnedWords { get; set; }
        IUserFailedWordRepository UserFailedWords { get; set; }

        int Complete();
    }
}
