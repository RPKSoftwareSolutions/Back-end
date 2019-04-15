using System;

namespace TKD.ReadModel.Contract
{
    public class SekaniWordExampleAudioDto
    {

        public int Id { get; set; }

        public int SekaniWordExampleId { get; set; }

        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

       
    }
}
