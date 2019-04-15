using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniWordAttributeDto
    {
        public int Id { get; set; }

        public int SekaniWordId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime UpdateTime { get; set; }

       
    }
}
