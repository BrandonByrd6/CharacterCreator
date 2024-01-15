using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Data;
using CC.Data.Entities;
using CC.Models.Feature;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CC.Services.Feature
{
    public class FeatureService : IFeatureService
    {
        private readonly ApplicationDbContext _context;

        private readonly int _userId;

        public FeatureService(ApplicationDbContext context,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if (hasValidId == false)
            {
                throw new Exception("Attempted to create feature with out Id Claim");
            }

            _context = context;
        }

        public async Task<bool> CreateFeatureAsync(FeatureCreate request)
        {
            FeatureEntity feature = new()
            {
                Name = request.Name,
                Description = request.Description,
                OwnerId = _userId
            };
            _context.Features.Add(feature);
            var changes = await _context.SaveChangesAsync();

            if (changes != 1) return false;
                return true;
        }

        public async Task<FeatureDetail?> GetFeatureByIdAsync(int featureId)
        {
            FeatureEntity? feature = await _context.Features
                .FirstOrDefaultAsync(f => 
                f.Id == featureId && f.OwnerId == _userId);

                return feature is null ? null : new FeatureDetail
                {
                    Id = feature.Id,
                    Name = feature.Name,
                    Description = feature.Description
                };
        }

        public async Task<IEnumerable<FeatureListItem>> GetAllFeaturesAsync()
        {
            List<FeatureListItem> features = await _context.Features
                .Where(entity => entity.OwnerId == _userId)
                .Select(entity => new FeatureListItem   
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                }).ToListAsync();

            return features;
        }
             
    }
}