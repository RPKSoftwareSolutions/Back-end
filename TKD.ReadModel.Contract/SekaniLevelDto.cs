using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TKD.ReadModel.Contract
{
    public class SekaniLevelDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public byte[] Image { get; set; }

        public DateTime UpdateTime { get; set; }

 
    }
}
