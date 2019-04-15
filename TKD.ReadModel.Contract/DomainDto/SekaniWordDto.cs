using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniWordDto
    {
        public int Id { get; set; }
        public int SekaniRootId { get; set; }
        public string Word { get; set; }
        public string  Phonetic { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
