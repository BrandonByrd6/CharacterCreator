using System.ComponentModel.DataAnnotations;

namespace CC.Models.Character;

public class CreateCharacter
{
    [Required]
    [MinLength(1, ErrorMessage = "Character Name must have at least 1 character")]
    [MaxLength(254, ErrorMessage = "Character Name can not have more than 254 Characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int Strength { get; set; }

    [Required]
    public int Agility { get; set; }

    [Required]
    public int Vitatlity { get; set; }

    [Required]
    public int Intelligence { get; set; }

    [Required]
    public int Perception { get; set; }

    [Required]
    public int Wisdom { get; set; }

    public int TeamId { get; set; }

    public int FeatureId { get; set; }
}
