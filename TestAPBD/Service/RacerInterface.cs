using TestAPBD.DTO;
using TestAPBD.Model;

namespace TestAPBD.Service;

public interface RacerInterface
{
    Task<List<Racer>> GetAllRacers();
    Task<List<RacerDTO>> GetRacerById(int id);
}