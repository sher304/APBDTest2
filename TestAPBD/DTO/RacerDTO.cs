namespace TestAPBD.DTO;

public class RacerDTO
{
    public int RacerID { get; set; }
    public string FirstName { get; set; }
    public string  LastName { get; set; }
    public List<ParticiaptionDTO> Particiaptions { get; set; }
    
}

public class ParticiaptionDTO
{
    public RaceDTO Race { get; set; }
    public TrackDTO Track { get; set; }
    public int Laps { get; set; }
    public int FinishingTimeinKM { get; set; }

}

public class RaceDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
}

public class TrackDTO
{
    public string Name { get; set; }
    public decimal LengthInKm { get; set; }
}

