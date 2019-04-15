using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.ReadModel.Contract
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
