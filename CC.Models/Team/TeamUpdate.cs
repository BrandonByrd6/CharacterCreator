using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models.Team
{
    public class TeamUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")]
        [MaxLength(250, ErrorMessage = "Name must be no more than 250 characters")]
        public string Name { get; set; } = string.Empty;
    }
}