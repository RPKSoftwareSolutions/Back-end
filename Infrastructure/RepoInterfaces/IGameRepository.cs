using System;
using System.Collections.Generic;
using System.Text;
using TKD.Domain.TKDModels;

namespace TKD.Infrastructure.RepoInterfaces
{
   public interface IGameRepository
   {
       SekaniWord GetRandomSekaniWord(int userId, int userLevel);
       IList<EnglishWord> GetDifferentEnglishWords(int englishWordId);
   }
}
