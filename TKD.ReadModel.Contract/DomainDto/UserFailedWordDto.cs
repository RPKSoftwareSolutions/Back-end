using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class UserFailedWordDto
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public int SekaniWordId { get; set; }

        public DateTime UpdateTime { get; set; }

      
    }
}
