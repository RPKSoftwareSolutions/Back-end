
using System.Collections.Generic;
using Framework.Core;
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniRootImageRepository: Repository<SekaniRootImage>, ISekaniRootImageRepository
    {
        public SekaniRootImageRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;


    }
}
