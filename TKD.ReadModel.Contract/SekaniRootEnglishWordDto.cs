using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.ReadModel.Contract
{
    public class SekaniRootEnglishWordDto
    {

        public int Id { get; set; }

        public int EnglishWordId { get; set; }

        public int SekaniRootId { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
