using APBD_Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Kolos2.Controllers;

[Route("api/characters")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterServices _characterServices;

    public CharacterController(ICharacterServices characterServices)
    {
        _characterServices = characterServices;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> getCharacter(int characterId)
    {
        var result = await _characterServices.GetCharacter(characterId);

        if (result == null)
        {
            return NotFound("Character with this ID does not exists");
        }

        return Ok(result);
    }
    
    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, List<int> itemIds)
    {
        var result = await _characterServices.AddItemsToBackpack(characterId, itemIds);

        if (result == null)
        {
            return BadRequest("Bad request. Correct it and try again"); // Nie ma rozbicia na poszczególne błędy bo cienko z czasem :(
        }

        return Ok(result);
    }
}