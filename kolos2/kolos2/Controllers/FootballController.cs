using kolos2.DTOs.Requests;
using kolos2.Exceptions;
using kolos2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Controllers
{
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFootballDbService _dbService;
        public FootballController(IFootballDbService service)
        {
            _dbService = service;
        }
        [Route("/api/championships/1/teams")]
        [HttpGet("{id:int}")]
        public IActionResult GetTeams(int id)
        {
            try
            {
                var result = _dbService.GetTeams(id);
                return Ok(result);
            }
            catch (NotFoundChampionShipException exc)
            {
                return NotFound(exc.Message);
            }
        }

        [Route("/api/teams/{id}/players")]
        [HttpPost("{id:int}")]
        public IActionResult AddPlayer(int id, AddPlayerRequest request)
        {
            try
            {
                _dbService.AddPlayer(id,request);
                return Ok();
            }
            catch (TeamNotFoundException exc)
            {
                return NotFound(exc.Message);
            }
            catch (PlayerTooOldException exc)
            {
                return BadRequest(exc.Message);
            }
        }

    }
}
