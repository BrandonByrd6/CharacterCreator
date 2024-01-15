using System.ComponentModel.DataAnnotations;

namespace CC.Models.Character;
public class CharacterFeatureAdd
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int FeatureId { get; set; }
}
