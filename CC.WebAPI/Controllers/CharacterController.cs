using CC.Models.Character;
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
    }
}
