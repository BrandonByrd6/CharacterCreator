using CC.Models.Character;

namespace CC.Services.Character;
public interface ICharacterService
{
    Task<bool> CreateCharacterAsync(CreateCharacter request);

    Task<IEnumerable<CharacterDetail>> getAllCharactersAsync();
    
}
