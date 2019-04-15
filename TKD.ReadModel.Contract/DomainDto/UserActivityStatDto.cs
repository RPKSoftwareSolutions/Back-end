using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class UserActivityStatDto
    {
      
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Variable { get; set; }

        public string Value { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
