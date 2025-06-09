using System.ComponentModel.DataAnnotations;

namespace TestAPBD.Model;

public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Location { get; set; }
    public DateTime Date { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; } = null!;
}