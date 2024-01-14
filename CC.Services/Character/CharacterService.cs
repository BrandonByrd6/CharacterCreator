using CC.Data;
using CC.Data.Entities;
using CC.Models.Character;
using Microsoft.AspNetCore.Identity;

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
            FeatureId = request.FeatureId
        };

        _dbContext.Characters.Add(entity);
        var changes = await _dbContext.SaveChangesAsync();
        if(changes != 1) return false;

        return true;
    }
}
