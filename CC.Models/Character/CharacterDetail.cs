namespace CC.Models.Character;

public class CharacterDetail
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Vitatlity { get; set; }
    public int Intelligence { get; set; }
    public int Perception { get; set; }
    public int Wisdom { get; set; }
    public int TeamId { get; set; }
    public int FeatureId { get; set; }
}
