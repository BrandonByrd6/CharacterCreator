using CC.Data;
using CC.Data.Entities;
using CC.Models.Team;
using CC.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CC.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        private readonly int _userId;

        public TeamService(ApplicationDbContext context,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);
        
            if(hasValidId == false) 
            {
                throw new Exception("Attempted to create team with out Id Claim");
            }
            _context = context;            
        }

        public async Task<bool> CreateTeamAsync(TeamCreate model)
        {
            TeamEntity entity = new()
            {
                Name = model.Name,
                OwnerId = _userId
            };

            _context.Teams.Add(entity);
            var changes = await _context.SaveChangesAsync();
            if(changes != 1) return false;
                return true;
        }

        public async Task<TeamDetail?> GetTeamByIdAsync(int teamId)
        {
            TeamEntity? entity = await _context.Teams.FindAsync(teamId);
            if (entity is null)
            {
                return null;
            }
            if (entity.OwnerId != _userId)
            {
                return null;
            }
            TeamDetail detail = new()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return detail;
        }

        public async Task<IEnumerable<TeamDetail>> GetAllTeamsAsync()
        {
            List<TeamDetail> teams = await _context.Teams.Where(entity => entity.OwnerId == _userId)
            .Select(entity => new TeamDetail{
                Id = entity.Id,
                Name = entity.Name 
            }).ToListAsync();
            return teams;
        }
    }
}