using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models.Feature
{
    public class FeatureCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")]
        [MaxLength(250, ErrorMessage = "Name must be no more than 250 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MinLength(1, ErrorMessage = "Description must be at least 1 character")]
        [MaxLength(1000, ErrorMessage = "Description must be no more than 1000 characters")]
        public string Description { get; set; } = string.Empty;
    }
}