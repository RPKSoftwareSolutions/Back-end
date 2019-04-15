using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.ReadModel.Contract
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
