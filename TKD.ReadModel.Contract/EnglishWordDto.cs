using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TKD.ReadModel.Contract
{
    public class EnglishWordDto
    {

        public int Id { get; set; }

        public string Word { get; set; }
     
        public bool Standard { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
