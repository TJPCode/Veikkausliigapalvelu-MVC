using System.Collections.Generic;

namespace Veikkausliigapalvelu.Models
{
    public class ResultsModel
    {
        public List<Match> Matches { get; set; }
        public string SearchResultTxt { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public object Logo { get; set; }
        public string LogoUrl { get; set; }
        public int Ranking { get; set; }
        public string Message { get; set; }
    }

    public class Match
    {
        public int Id { get; set; }
        public object Round { get; set; }
        public int RoundNumber { get; set; }
        public string MatchDate { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int Status { get; set; }
        public int PlayedMinutes { get; set; }
        public object SecondHalfStarted { get; set; }
        public string GameStarted { get; set; }
        public List<Events> MatchEvents { get; set; }
        public List<object> PeriodResults { get; set; }
        public bool OnlyResultAvailable { get; set; }
        public int Season { get; set; }
        public string Country { get; set; }
        public string League { get; set; }
        public string SearchResultTxt { get; set; }
    }

    public class Events
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int EventMinute { get; set; }
        public int ElapsedSeconds { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string EventTypeIcon { get; set; }
        public string EventType { get; set; }
        public int EventTypeEnum { get; set; }
        public int PlayerId { get; set; }
        public string Player { get; set; }
        public string Identifier { get; set; }
        public string AssistPlayers { get; set; }
        public string AssistPlayerNames { get; set; }
        public string Modifier { get; set; }
        public string Score { get; set; }
        public bool IsGoal { get; set; }
    }    
}