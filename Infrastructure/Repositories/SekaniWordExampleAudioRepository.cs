using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniWordExampleAudioRepository: Repository<SekaniWordExampleAudio>, ISekaniWordExampleAudioRepository
    {
        public SekaniWordExampleAudioRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
