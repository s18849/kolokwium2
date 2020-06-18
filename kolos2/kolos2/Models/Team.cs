using System.Collections.Generic;

namespace kolos2.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        ICollection<Player_Team> Player_Teams { get; set; }
        ICollection<Championship_Team> Championship_Teams { get; set; }
    }
}