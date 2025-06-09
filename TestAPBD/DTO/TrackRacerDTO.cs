namespace TestAPBD.DTO;

public class TrackRacerDTO
{
    public string raceName { get; set; }
    public string trackName  { get; set; }
    public List<ParticiaptionsDTO> Particiaptions { get; set; }
    
}

public class ParticiaptionsDTO
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public  int FinishingTimeInSeconds { get; set; }
}
