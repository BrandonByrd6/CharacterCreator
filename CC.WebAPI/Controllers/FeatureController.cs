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

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featureService.GetAllFeaturesAsync();
            return Ok(features);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureById([FromBody] FeatureUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _featureService.UpdateFeatureAsync(request)
                ? Ok("Feature updates successfully") : BadRequest("Feature could not be updated");
        }

        [HttpDelete("{featureId:int}")]
        public async Task<IActionResult> DeleteFeature([FromRoute] int featureId)
        {
            return await _featureService.DeleteFeatureAsync(featureId)
                ? Ok($"Feature {featureId} was deleted successfully")
                : BadRequest($"Feature {featureId} could not be deleted");
        }
    }
}