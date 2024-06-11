using APBD_Kolos2.Database;
using APBD_Kolos2.DTOs;
using APBD_Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolos2.Services;

public class CharacterServices : ICharacterServices
{
    private readonly CharacterDBContext _context;

    public CharacterServices(CharacterDBContext context)
    {
        _context = context;
    }

    public async Task<GetCharacterDTO> GetCharacter(int characterId)
    {
        var query = await _context.Characters.Include(b => b.Backpacks).ThenInclude(i => i.Items)
            .Include(ct => ct.CharacterTitles).ThenInclude(t => t.Titles)
            .SingleOrDefaultAsync(c => c.Id == characterId);

        if (query == null)
        {
            return null;
        }

        var result = new GetCharacterDTO
        {
            FirstName = query.FirstName,
            LastName = query.LastName,
            CurrentWeight = query.CurrentWeight,
            MaxWeight = query.MaxWeight,
            Items = query.Backpacks.Select(b => new GetBackpackDTO
            {
                ItemName = b.Items.Name,
                Amount = b.Amount,
                ItemWeight = b.Items.Weight
            }).ToList(),
            Titles = query.CharacterTitles.Select(ct => new GetTitlesDTO
            {
                Title = ct.Titles.Name,
                AcquiredAt = ct.AcquiredAt
            }).ToList()
        };

        return result;
    }

    public async Task<List<BackpackDTO>> AddItemsToBackpack(int characterId, List<int> itemIds)
    {
        var character = await _context.Characters.Include(c => c.Backpacks)
            .SingleOrDefaultAsync(c => c.Id == characterId);
        if (character == null)
        {
            return null;
        } //Character nie istnieje

        var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();
        if (items.Count != itemIds.Count)
        {
            return null;
        } // Przedmioty nie istnieją

        var totalWeight = items.Sum(i => i.Weight);
        if (character.CurrentWeight + totalWeight > character.MaxWeight)
        {
            return null;
        } // Przekroczona maksymalna waga

        foreach (var item in items)
        {
            var backpack = character.Backpacks.SingleOrDefault(b => b.ItemId == item.Id);
            if (backpack != null)
            {
                backpack.Amount++;
            }
            else
            {
                character.Backpacks.Add(new Backpacks() { CharacterId = characterId, ItemId = item.Id, Amount = 1 });
            }

            character.CurrentWeight += item.Weight;
        }

        await _context.SaveChangesAsync();

        return character.Backpacks.Select(b => new BackpackDTO
        {
            Amount = b.Amount,
            ItemId = b.ItemId,
            CharacterId = b.CharacterId
        }).ToList();
    }
}