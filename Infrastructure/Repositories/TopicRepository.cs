﻿using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class TopicRepository: Repository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}