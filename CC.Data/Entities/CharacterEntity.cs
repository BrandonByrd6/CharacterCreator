using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC.Data.Entities;

public class CharacterEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int strength { get; set; }

    [Required]
    public int agility { get; set; }

    [Required]
    public int vitatlity { get; set; }

    [Required]
    public int intelligence { get; set; }

    [Required]
    public int perception { get; set; }

    [Required]
    public int wisdom { get; set; }

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }
    TeamEntity Team { get; set; } = null;


    [ForeignKey(nameof(Feature))]
    public int FeatureId { get; set; }
    FeatureEntity Feature { get; set; } = null;
}
