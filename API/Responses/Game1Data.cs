using System.Collections.Generic;

namespace API.Responses
{
    public class Game1Data
    {
        public int SekaniWordId { get; set; }
        public List<int> EnglishWords { get; set; }=new List<int>();
        public int CurrentEnglishWord { get; set; }
    }
}
