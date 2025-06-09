using TestAPBD.DTO;

namespace TestAPBD.Service;

public interface TrackRacerInterfcae
{
    Task post(TrackRacerDTO trackRacerDTO);
}