using Microsoft.EntityFrameworkCore;
using TestAPBD.Data;
using TestAPBD.DTO;

namespace TestAPBD.Service;

public class TrackRacerService : TrackRacerInterfcae
{
    
    private readonly DatabaseContext _context;

    public TrackRacerService(DatabaseContext dbContext)
    {
        _context = dbContext;
    }

    public async Task post(TrackRacerDTO trackRacerDTO)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var race = await _context.Race.FirstOrDefaultAsync(r => r.Name.Equals(trackRacerDTO.raceName));
            if (race is null)
                throw new Exception("Race with this name not found.");
            
            var track = await _context.Track.FirstOrDefaultAsync(t => t.Name.Equals(trackRacerDTO.trackName));
            if (track is null)
                throw new Exception("Track with that name not found.");

            var racer = await _context.Racer.FirstOrDefaultAsync(
                e => e.RacerId == trackRacerDTO.Particiaptions.Select(p => p.RacerId).FirstOrDefault());
            if (racer is null)
                throw new Exception("Racer with that name not found.");
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
