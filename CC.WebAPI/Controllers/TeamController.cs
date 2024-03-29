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
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeamById([FromBody] TeamUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _teamService.UpdateTeamAsync(request)
                ? Ok("Team updated successfully")
                : BadRequest("Team could not be updated");
        }

        [HttpDelete("{teamId:int}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int teamId)
        {
            return await _teamService.DeleteTeamAsync(teamId)
                ? Ok($"Team {teamId} was deleted successfully")
                : BadRequest($"Team {teamId} could not be deleted");
        }
    }
}