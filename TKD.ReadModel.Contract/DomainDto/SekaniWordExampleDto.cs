using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniWordExampleDto
    {

        public int Id { get; set; }

        public int SekaniWordId { get; set; }

        public string Sekani { get; set; }

        public string English { get; set; }

        public DateTime UpdateTime { get; set; }

       
    }
}
