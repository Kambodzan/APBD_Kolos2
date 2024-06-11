namespace APBD_Kolos2.DTOs;

public class GetCharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<GetBackpackDTO> Items { get; set; } = null!;
    public ICollection<GetTitlesDTO> Titles { get; set; } = null!;
    

}