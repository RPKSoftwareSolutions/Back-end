using System;

namespace TKD.ReadModel.Contract
{
    public class UserLearnedWordDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SekaniWordId { get; set; }
        public int TryCount { get; set; }
        public DateTime AnswerDateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
