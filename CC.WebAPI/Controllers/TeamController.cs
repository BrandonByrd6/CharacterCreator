using CC.Models.Team;
using CC.Services.Team;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebAPI.Controllers
{
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