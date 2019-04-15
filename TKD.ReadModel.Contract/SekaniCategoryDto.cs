using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TKD.ReadModel.Contract
{
    public class SekaniCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public byte[] Image { get; set; }
        public DateTime UpdateTime { get; set; }


    }
}
