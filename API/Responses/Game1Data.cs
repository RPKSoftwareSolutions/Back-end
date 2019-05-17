using System.Collections.Generic;

namespace API.Responses
{
    public class Game1Data
    {
        public int SekaniWordId { get; set; }
        public List<int> Words { get; set; }
        public int CurrentWordAddress { get; set; }
    }
}
