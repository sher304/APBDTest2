using System.ComponentModel.DataAnnotations;

namespace TestAPBD.Model;

public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public decimal LengthInKm { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; } = null!;
}