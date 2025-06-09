using Microsoft.EntityFrameworkCore;
using TestAPBD.Model;

namespace TestAPBD.Data;

public class DatabaseContext : DbContext
{
    
    public DbSet<Race> Race { get; set; }
    public DbSet<Racer> Racer { get; set; }
    public DbSet<RaceParticipation> RaceParticipation { get; set; }
    public DbSet<TrackRace> TrackRace { get; set; }
    public DbSet<Track> Track { get; set; }
    
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer() { RacerId = 1, FirstName = "Sam", LastName = "Smith" },
            new Racer() { RacerId = 2, FirstName = "John", LastName = "Snow" },
            new Racer() { RacerId = 3, FirstName = "William", LastName = "Ice" },
        });
        
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race() {RaceId = 1, Location = "London", Name = "London ATT", Date = DateTime.Parse("2025-05-01")},
            new Race() {RaceId = 2, Location = "Poznan", Name = "Poznan ATT", Date = DateTime.Parse("2022-05-01")},
            new Race() {RaceId = 3, Location = "Warsaw", Name = "Warsaw ATT", Date = DateTime.Parse("2023-05-01")},
        });
        
        
        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track() { TrackId = 1, Name = "Longh", LengthInKm = 15.5m},
            new Track() { TrackId = 2, Name = "Smal", LengthInKm = 10.5m},
            new Track() { TrackId = 3, Name = "Short", LengthInKm = 5.5m},
        });
        
        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace() {TrackRaceId = 1, RaceId = 1, TrackId = 1, Laps = 2, BestTimeInSeconds = 241111},
            new TrackRace() {TrackRaceId = 2, RaceId = 2, TrackId = 2, Laps = 4, BestTimeInSeconds = 23334},
            new TrackRace() {TrackRaceId = 3, RaceId = 3, TrackId = 3, Laps = 12, BestTimeInSeconds = 13334},
        });

        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation() { TrackRaceId = 1, RacerId = 1, FinishTimeInSeconds = 50000, Position = 5},
            new RaceParticipation() { TrackRaceId = 2, RacerId = 2, FinishTimeInSeconds = 3000, Position = 2},
            new RaceParticipation() { TrackRaceId = 3, RacerId = 3, FinishTimeInSeconds = 2000, Position = 1},
        });


    }
}
