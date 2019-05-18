
using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniWordExampleAudioRepository: Repository<SekaniWordExampleAudio>, ISekaniWordExampleAudioRepository
    {
        public SekaniWordExampleAudioRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
