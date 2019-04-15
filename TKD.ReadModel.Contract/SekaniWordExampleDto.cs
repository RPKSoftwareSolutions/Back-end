using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.ReadModel.Contract
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
