using kolos2.DTOs.Requests;
using kolos2.DTOs.Responses;
using kolos2.Exceptions;
using kolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public class SqlServerFootballDbService : IFootballDbService
    {
        private readonly FootballDbContext _context;
        public SqlServerFootballDbService(FootballDbContext context)
        {
            _context = context;
        }

        public void AddPlayer(int id, AddPlayerRequest request)
        {
            var maxAge = _context.Teams.SingleOrDefault(t => t.IdTeam == id).MaxAge;

            if (maxAge == null)
            {
                throw new TeamNotFoundException("Nie znaleziono druzyny o takim id");
            }

            var playerAge = DateTime.Now.Year - request.birthDate.Year;

            if(playerAge > maxAge)
            {
                throw new PlayerTooOldException("gracz jest za stary");
            }


        }

        public GetTeamsResponse GetTeams(int id)
        {
            Dictionary<string, float> teamScores = new Dictionary<string, float>();
            var championship_Teams = _context.Championship_Teams
                .Where(c => c.IdChampionship == id)
                .OrderBy(c => c.Score)
                .ToList();
            if(championship_Teams == null)
            {
                throw new NotFoundChampionShipException("Nie znaleziono zawodow");
            }

            foreach (var c in championship_Teams)
            {
                var teamName = _context.Teams.SingleOrDefault(t => t.IdTeam == c.IdTeam).TeamName;
                teamScores.Add(teamName, c.Score);
                
            }

            GetTeamsResponse response = new GetTeamsResponse
            {
                IdChampionship = id,
                Score = teamScores
            };
            return response;
        }
    }
}
