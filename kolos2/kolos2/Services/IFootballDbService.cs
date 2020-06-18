using kolos2.DTOs.Requests;
using kolos2.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IFootballDbService
    {
        public GetTeamsResponse GetTeams(int id);
        public void AddPlayer(int id, AddPlayerRequest request);
    }
}
