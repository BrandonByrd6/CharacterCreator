using CC.Data;
using CC.Data.Entities;
using CC.Models.Character;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CC.Services.Character;

public class CharacterService : ICharacterService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;

    public CharacterService(UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        ApplicationDbContext dbContext)
    {
        var currentUser = signInManager.Context.User;
        var userIdClaim = userManager.GetUserId(currentUser);
        var hasValidId = int.TryParse(userIdClaim, out _userId);
        
        if(hasValidId == false) {
            throw new Exception("Attempted to build CharacterService with out Id Claim");
        }

        _dbContext = dbContext;
    }

    public async Task<bool> CreateCharacterAsync(CreateCharacter request)
    {
         CharacterEntity entity = new(){
            Name = request.Name,
            Strength = request.Strength,
            Agility = request.Agility,
            Vitatlity = request.Vitatlity,
            Intelligence = request.Intelligence,
            Perception = request.Perception,
            Wisdom = request.Wisdom,
            TeamId = request.TeamId,
            FeatureId = request.FeatureId,
            OwnerId = _userId
        };

        _dbContext.Characters.Add(entity);
        var changes = await _dbContext.SaveChangesAsync();
        if(changes != 1) return false;

        return true;
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        var characterEntity = await _dbContext.Characters.FindAsync(id);

          if(characterEntity?.OwnerId != _userId) 
            return false;

        _dbContext.Characters.Remove(characterEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<CharacterDetail>> getAllCharactersAsync()
    {
        List<CharacterDetail> characters = 
            await _dbContext.Characters.
            Where(entity => entity.OwnerId == _userId).
            Select(entity => new CharacterDetail{
                Id = entity.Id,
                Name = entity.Name,
                Strength = entity.Strength,
                Agility = entity.Agility,
                Vitatlity = entity.Vitatlity,
                Intelligence = entity.Intelligence,
                Perception = entity.Perception,
                Wisdom = entity.Wisdom,
                TeamId = entity.TeamId,
                FeatureId = entity.FeatureId
        }).ToListAsync();

        return characters;
    }

    public async Task<CharacterDetail?> getCharacterById(int characterId)
    {
        CharacterEntity? entity = await _dbContext.Characters.FindAsync(characterId);

        if(entity == null)
            return null;

        if(entity.OwnerId != _userId)
            return null;


        CharacterDetail character = new(){
            Id = entity.Id,
            Name = entity.Name,
            Strength = entity.Strength,
            Agility = entity.Agility,
            Vitatlity = entity.Vitatlity,
            Intelligence = entity.Intelligence,
            Perception = entity.Perception,
            Wisdom = entity.Wisdom,
            TeamId = entity.TeamId,
            FeatureId = entity.FeatureId
        };

        return character;
    }

    public async Task<bool> UpdateCharacterAsync(CharacterUpdate request)
    {
        CharacterEntity? entity = await _dbContext.Characters.FindAsync(request.Id);

        if(entity?.OwnerId != _userId) 
            return false;
        
        entity.Name = request.Name;
        entity.Strength = request.Strength;
        entity.Agility = request.Agility;
        entity.Vitatlity = request.Vitatlity;
        entity.Intelligence = request.Intelligence;
        entity.Perception = request.Perception;
        entity.Wisdom = request.Wisdom;
        entity.TeamId = request.TeamId;
        entity.FeatureId = request.FeatureId;

        int numOfChanges = await _dbContext.SaveChangesAsync();

        return numOfChanges == 1;
    }
}
