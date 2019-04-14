using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Responses
{
    public class Game1
    {
        public int sekaniWordId { get; set; }
        public List<int> Words { get; set; }
        public int CurrentWordAddress { get; set; }
    }
}
