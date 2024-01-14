using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models.Character
{
    public class CharacterTeamAdd
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}