using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniWordAudioDto
    {

        public int Id { get; set; }

        public int SekaniWordId { get; set; }


        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

       
    }
}
