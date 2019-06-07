using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _dbContext;

        public GameRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<SekaniWord> GetRandomSekaniWord(int userId, int userLevel,int takeWords, int topicId)
        {
            var sekaniWord = _dbContext.SekaniWords
                .Include(a => a.SekaniRoot)
                 .ThenInclude(a => a.SekaniRootsEnglishWords)
                  .ThenInclude(a => a.EnglishWord)
                .Where(a => !_dbContext.UserLearnedWords.Any(b => b.SekaniWordId == a.Id && b.UserId == userId)
                 && a.SekaniRoot.SekaniRootsEnglishWords.Count > 0
                 && a.SekaniRoot.SekaniRootImages.Count > 0).ToList()              
                .OrderBy(r => Guid.NewGuid())
                .Take(takeWords)
                .ToList();
            return sekaniWord;
        }
        public IList<EnglishWord> GetDifferentEnglishWords(int sekaniRootId)
        {
            var englishWords = _dbContext.SekaniRootsEnglishWords.Where(a => a.SekaniRootId != sekaniRootId && a.SekaniRoot.SekaniRootImages.Count > 0)
               .Select(a => a.EnglishWord)
                .OrderBy(r => Guid.NewGuid())
                .Take(3)
                .ToList();
            return englishWords;
        }

    }
}
