using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestAPBD.Model;

[Table("Racer_Participation")]
[PrimaryKey(nameof(TrackRaceId),  nameof(RacerId))]
public class RaceParticipation
{
    public int TrackRaceId { get; set; }
    public int RacerId { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
    
    [ForeignKey(nameof(RacerId))]
    public Racer Racer { get; set; }  = null!;
    [ForeignKey(nameof(TrackRaceId))]
    public TrackRace TrackRace { get; set; } = null!;
    
}