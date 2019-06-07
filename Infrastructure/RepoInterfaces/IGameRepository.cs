using System;
using System.Collections.Generic;
using System.Text;
using TKD.Domain.TKDModels;

namespace TKD.Infrastructure.RepoInterfaces
{
   public interface IGameRepository
   {
       IList<SekaniWord> GetRandomSekaniWord(int userId, int userLevel,int takeWords, int topicId);
       IList<EnglishWord> GetDifferentEnglishWords(int englishWordId);
   }
}
