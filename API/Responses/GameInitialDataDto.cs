namespace API.Responses
{
    public class GameInitialDataDto
    {
        public int Scoure { get; set; }
        public int Life { get; set; }
        public int TotalRoundCount { get; set; }
        public int FailedRoundCount { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int GameType { get; set; }
        public string GameData { get; set; }
    }
}
