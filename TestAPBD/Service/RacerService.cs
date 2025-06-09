using Microsoft.EntityFrameworkCore;
using TestAPBD.Data;
using TestAPBD.DTO;
using TestAPBD.Model;

namespace TestAPBD.Service;

public class RacerService : RacerInterface
{
    
    private readonly DatabaseContext  _context;

    public RacerService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Racer>> GetAllRacers()
    {
        return await _context.Racer.ToListAsync();
    }

    public async Task<List<RacerDTO>> GetRacerById(int id)
    {
        var result = await _context.Racer
            .Where(r => r.RacerId == id)
            .Select(c => new RacerDTO
            {
                RacerID = c.RacerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Particiaptions = c.RaceParticipations.Select(rp => new ParticiaptionDTO
                {
                    FinishingTimeinKM = rp.FinishTimeInSeconds,
                    Laps = rp.TrackRace.Laps,
                    Race = new RaceDTO
                    {
                        Date = rp.TrackRace.Race.Date,
                        Location = rp.TrackRace.Race.Location,
                    },
                    Track = new TrackDTO
                    {
                        LengthInKm = rp.TrackRace.Track.LengthInKm,
                        Name = rp.TrackRace.Track.Name,
                    }
                }).ToList()
            }).ToListAsync();
        
        if (result.Count == 0)
            throw new Exception("No Racers found");
        return result;
    }
}