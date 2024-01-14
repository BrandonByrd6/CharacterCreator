using CC.Models.Character;
using CC.Models.Responses;
using CC.Services.Character;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacter request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _characterService.CreateCharacterAsync(request);
            if (!response)
                return BadRequest("Could Not Create Character");

            return Ok("Character Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacter()
        {
            var characters = await _characterService.getAllCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("{characterId:int}")]
        public async Task<IActionResult> GetCharacterById(int characterId) {
            var character = await _characterService.getCharacterById(characterId);

            if(character == null)
                return BadRequest(new TextResponse("Could not Find a Character with that ID"));
            
            return Ok(character);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter([FromBody] CharacterUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _characterService.UpdateCharacterAsync(request) ? Ok("Character Update Successfully") : BadRequest("Character Could not be updated");
        }

        [HttpPut("/Feature")]
        public async Task<IActionResult> AddFeatureToCharacter([FromBody] CharacterFeatureAdd request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _characterService.AddFeatureToCharacterAsync(request) ? Ok("Feature added Successfully") : BadRequest("Feature could not be added");
        }

        [HttpPut("/Team")]
        public async Task<IActionResult> AddTeamToCharacter([FromBody] CharacterTeamAdd request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _characterService.AddCharacterToTeamAsync(request) ? Ok("Team added Successfully") : BadRequest("Team could not be added");
        }

        [HttpDelete("{characterId:int}")]
        public async Task<IActionResult> DeteteCharacter([FromRoute] int characterId)
        {
            return await _characterService.DeleteCharacterAsync(characterId) ? Ok($"Charcter {characterId} was deleted successfully") 
                : BadRequest($"Charcter {characterId} was unable to be deleted!");
        }
    }
}
