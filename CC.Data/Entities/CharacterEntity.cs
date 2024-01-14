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

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }
    TeamEntity Team { get; set; } = null;


    [ForeignKey(nameof(Feature))]
    public int FeatureId { get; set; }
    FeatureEntity Feature { get; set; } = null;
}
