using System.ComponentModel.DataAnnotations;

namespace CC.Models.Team
{
    public class TeamCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")] 
        [MaxLength(250, ErrorMessage ="Name must be no more than 250 characters")]
        public string Name {get; set;} = string.Empty;
    }
}