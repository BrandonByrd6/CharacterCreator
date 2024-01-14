using CC.Models.Character;

namespace CC.Services.Character;
public interface ICharacterService
{
    Task<bool> CreateCharacterAsync(CreateCharacter request);

    Task<IEnumerable<CharacterDetail>> getAllCharactersAsync();
    
    Task<CharacterDetail?> getCharacterById(int characterId);

    Task<bool> UpdateCharacterAsync(CharacterUpdate request);

    Task<bool> DeleteCharacterAsync(int id);

    Task<bool> AddFeatureToCharacterAsync(CharacterFeatureAdd request);

    Task<bool> AddCharacterToTeamAsync(CharacterTeamAdd request); 

}
