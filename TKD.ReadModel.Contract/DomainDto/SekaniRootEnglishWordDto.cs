using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniRootEnglishWordDto
    {

        public int Id { get; set; }

        public int EnglishWordId { get; set; }

        public int SekaniRootId { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
