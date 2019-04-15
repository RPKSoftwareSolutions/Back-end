using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class EnglishWordDto
    {

        public int Id { get; set; }

        public string Word { get; set; }
     
        public bool Standard { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
