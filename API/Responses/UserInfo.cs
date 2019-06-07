using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Responses
{
    public class UserInfo
    {
        public int Score { get; set; }
        public int Life { get; set; }
        public int TotalRoundCount { get; set; }
        public int FailedRoundCount { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int UserLevel { get; set; }
    }
}
