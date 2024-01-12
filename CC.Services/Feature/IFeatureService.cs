using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Models.Feature;

namespace CC.Services.Feature
{
    public interface IFeatureService
    {
        Task<bool> CreateFeatureAsync(FeatureCreate request);
        Task<FeatureDetail?> GetFeatureByIdAsync(int featureId);
    }
}