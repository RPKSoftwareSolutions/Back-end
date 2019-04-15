
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniWordAudioRepository: Repository<SekaniWordAudio>, ISekaniWordAudioRepository
    {
        public SekaniWordAudioRepository(AppDbContext context) : base(context) { }




        public AppDbContext AppContext => Context as AppDbContext;
    }
}
