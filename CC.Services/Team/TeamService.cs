using CC.Data;
using CC.Data.Entities;
using CC.Models.Team;
using Microsoft.AspNetCore.Identity;

namespace CC.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        private readonly int _userId;

        public TeamService(ApplicationDbContext context,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {   //! code below causes 500 internal server error when executing. Try again with authenticated user
            // var currentUser = signInManager.Context.User;
            // var userIdClaim = userManager.GetUserId(currentUser);
            // var hasValidId = int.TryParse(userIdClaim, out _userId);
        
            // if(hasValidId == false) 
            // {
            //     throw new Exception("Attempted to create team with out Id Claim");
            // }

            _context = context;            
        }

        public async Task<bool> CreateTeamAsync(TeamCreate model)
        {
            TeamEntity entity = new()
            {
                Name = model.Name
            };

            _context.Teams.Add(entity);
            var changes = await _context.SaveChangesAsync();
            if(changes != 1) return false;
                return true;
        }
    }
}