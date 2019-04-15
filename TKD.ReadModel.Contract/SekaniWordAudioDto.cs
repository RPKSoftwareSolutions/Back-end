using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.ReadModel.Contract
{
    public class SekaniWordAudioDto
    {

        public int Id { get; set; }

        public int SekaniWordId { get; set; }

        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

       
    }
}
