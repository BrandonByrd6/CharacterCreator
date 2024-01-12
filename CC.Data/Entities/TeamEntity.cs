using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class TeamEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")]
        [MaxLength(250, ErrorMessage = "Name must be no more than 250 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        UserEntity Owner { get; set; } = null!;
    }
}