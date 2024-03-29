using CC.Models.Feature;
using CC.Services.Feature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult>  CreateFeature([FromBody] FeatureCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _featureService.CreateFeatureAsync(request);
            if (!response) return BadRequest("Could not create feature");
                return Ok("Feature successfully created");
        }

        [HttpGet("{featureId:int}")]
        public async Task<IActionResult> GetFeatureById([FromRoute] int featureId)
        {
            FeatureDetail? detail = await _featureService.GetFeatureByIdAsync(featureId);
            return detail is not null ? Ok(detail) : NotFound();
        }
    }
}