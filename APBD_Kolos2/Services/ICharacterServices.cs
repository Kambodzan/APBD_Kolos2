using APBD_Kolos2.DTOs;

namespace APBD_Kolos2.Services;

public interface ICharacterServices
{
    public Task<GetCharacterDTO> GetCharacter(int characterId);
    Task<List<BackpackDTO>> AddItemsToBackpack(int characterId, List<int> itemIds);
}