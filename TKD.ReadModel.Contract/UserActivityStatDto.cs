using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.ReadModel.Contract
{
    public class UserActivityStatDto
    {
      
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Variable { get; set; }

        public string Value { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
