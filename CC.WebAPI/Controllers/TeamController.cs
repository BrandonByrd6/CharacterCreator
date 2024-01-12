using CC.Models.Team;
using CC.Services.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTeam(TeamCreate request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _teamService.CreateTeamAsync(request);
            if (!response)
                return BadRequest("Could Not Create Team");

            return Ok("Team Successfully Created");
        }

        [HttpGet("{teamId:int}")]
        public async Task<IActionResult> GetTeamById([FromRoute] int teamId)
        {
            TeamDetail? detail = await _teamService.GetTeamByIdAsync(teamId);

            if (detail is null)
            {
                return NotFound();
            }
            return Ok(detail);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams(){
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);

            if (!ModelState.IsValid)    
            {
                return BadRequest(ModelState);
            }
            var response = await _teamService.CreateTeamAsync(request);
            if (!response)
            {
                return BadRequest("Could not create team");
            }
            return Ok("Team created successfully!");

        }
    }
}