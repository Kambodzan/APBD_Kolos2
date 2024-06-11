using APBD_Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolos2.Database;

public class CharacterDBContext : DbContext
{
    protected CharacterDBContext()
    {
    }

    public CharacterDBContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Characters> Characters { get; set; }
    public DbSet<Titles> Titles { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<CharacterTitles> CharacterTitles { get; set; }
    public DbSet<Backpacks> Backpacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Characters>().HasData(new List<Characters>
        {
            new Characters
            {
                Id = 1,
                FirstName = "Mariusz",
                LastName = "Pudzianowski",
                CurrentWeight = 50,
                MaxWeight = 500
            },
            new Characters
            {
                Id = 2,
                FirstName = "Adam",
                LastName = "Malysz",
                CurrentWeight = 20,
                MaxWeight = 180
            },
            new Characters
            {
                Id = 3,
                FirstName = "Krzysztof",
                LastName = "Nowak",
                CurrentWeight = 35,
                MaxWeight = 120
            }
        });

        modelBuilder.Entity<Titles>().HasData(new List<Titles>
        {
            new Titles
            {
                Id = 1,
                Name = "Pogrmoca Blokow"
            },
            new Titles
            {
                Id = 2,
                Name = "Wielki Czlowiek"
            },
            new Titles
            {
                Id = 3,
                Name = "Najwiekszy z Polakow"
            },
            new Titles
            {
                Id = 4,
                Name = "Zamieszkaly w domu"
            },
            new Titles
            {
                Id = 5,
                Name = "Konsument Ryb"
            }
        });

        modelBuilder.Entity<Items>().HasData(new List<Items>
        {
            new Items
            {
                Id = 1,
                Name = "Wielki Miecz",
                Weight = 25
            },
            new Items
            {
                Id = 2,
                Name = "Giga Kusza",
                Weight = 10
            },
            new Items
            {
                Id = 3,
                Name = "Mikstura Zdrowia",
                Weight = 2
            },
            new Items
            {
                Id = 4,
                Name = "Zapas Piwa",
                Weight = 12
            },
            new Items
            {
                Id = 5,
                Name = "Mikstura Many",
                Weight = 3
            },
            new Items
            {
                Id = 6,
                Name = "Skorzana zbroja",
                Weight = 12
            }
        });

        modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>
        {
            new CharacterTitles
            {
                CharacterId = 1,
                TitleId = 3,
                AcquiredAt = DateTime.Parse("2023-05-01")
            },
            new CharacterTitles
            {
                CharacterId = 1,
                TitleId = 5,
                AcquiredAt = DateTime.Parse("2023-12-15")
            },
            new CharacterTitles
            {
                CharacterId = 1,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2024-02-03")
            },
            new CharacterTitles
            {
                CharacterId = 2,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2022-07-08")
            },
            new CharacterTitles
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2022-11-15")
            },
            new CharacterTitles
            {
                CharacterId = 3,
                TitleId = 4,
                AcquiredAt = DateTime.Parse("2021-08-09")
            },
        });

        modelBuilder.Entity<Backpacks>().HasData(new List<Backpacks>
        {
            new Backpacks
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 2
            },
            new Backpacks
            {
                CharacterId = 1,
                ItemId = 2,
                Amount = 5
            },
            new Backpacks
            {
                CharacterId = 1,
                ItemId = 5,
                Amount = 12
            },
            new Backpacks
            {
                CharacterId = 1,
                ItemId = 6,
                Amount = 1
            },
            new Backpacks
            {
                CharacterId = 2,
                ItemId = 1,
                Amount = 1
            },
            new Backpacks
            {
                CharacterId = 2,
                ItemId = 4,
                Amount = 7
            },
            new Backpacks
            {
                CharacterId = 2,
                ItemId = 3,
                Amount = 5
            },
            new Backpacks
            {
                CharacterId = 3,
                ItemId = 6,
                Amount = 2
            },
            new Backpacks
            {
                CharacterId = 3,
                ItemId = 1,
                Amount = 3
            },
            new Backpacks
            {
                CharacterId = 3,
                ItemId = 2,
                Amount = 4
            },
            new Backpacks
            {
                CharacterId = 3,
                ItemId = 3,
                Amount = 3
            },
        });
    }
}