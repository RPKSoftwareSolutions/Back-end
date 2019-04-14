using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniWordAudioRepository: Repository<SekaniWordAudio>, ISekaniWordAudioRepository
    {
        public SekaniWordAudioRepository(AppDbContext context) : base(context) { }




        public AppDbContext AppContext => Context as AppDbContext;
    }
}
