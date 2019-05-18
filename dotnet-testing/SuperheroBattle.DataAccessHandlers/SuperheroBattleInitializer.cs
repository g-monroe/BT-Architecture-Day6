using SuperheroBattle.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SuperheroBattle.DataAccessHandlers
{
    public static class SuperheroBattleInitializer
    {
        public static void SeedData()
        {
            using (var context = new SuperheroBattleContext())
            {
                var abilities = new List<Ability>()
            {
                new Ability
                {
                    AbilityID = -1,
                    Name = "Pick All That Apply"
                },
                new Ability
                {
                    AbilityID = 1,
                    Name = "Fly"
                },
                new Ability
                {
                    AbilityID = 2,
                    Name = "Superhuman Strength"
                },
                new Ability
                {
                    AbilityID = 3,
                    Name = "Energy Absorption"
                },
                new Ability
                {
                    AbilityID = 4,
                    Name = "Superhuman Speed"
                },
                new Ability
                {
                    AbilityID = 5,
                    Name = "Superhuman Stamina"
                },
                new Ability
                {
                    AbilityID = 6,
                    Name = "Superhuman Durability"
                },
                new Ability
                {
                    AbilityID = 7,
                    Name = "Photographic Memory"
                },
                new Ability
                {
                    AbilityID = 8,
                    Name = "Superhuman Agility"
                },
                new Ability
                {
                    AbilityID = 9,
                    Name = "Speed Reading"
                },
                new Ability
                {
                    AbilityID = 10,
                    Name = "Regenerative Healing"
                },
                new Ability
                {
                    AbilityID = 11,
                    Name = "Telepathy"
                },
                new Ability
                {
                    AbilityID = 12,
                    Name = "Terrible Singing"
                },
                new Ability
                {
                    AbilityID = 13,
                    Name = "Object/Money"
                },
                new Ability
                {
                    AbilityID = 14,
                    Name = "CSI Zoom Focus"
                },
                new Ability
                {
                    AbilityID = 15,
                    Name = "Telekinesis"
                }
            };

                var superheroes = new List<Superhero>()
            {
                new Superhero
                {
                    SuperheroName = "Spider-Man",
                    SecretIdentity ="Peter Parker",
                    YearOfAppearance = 1962,
                    IsAlien = false,
                    Universe = Universes.Marvel,
                    PlanetOfOrigin = Planets.Earth,
                    AgeAtOrigin = 15,
                    Abilities = new HashSet<Ability>( abilities.Where(a => new int[] { 2,5,6,8 }.Contains(a.AbilityID) ))
                },
                new Superhero
                {
                    SuperheroName = "Batman",
                    SecretIdentity = "Bruce Wayne",
                    YearOfAppearance = 1939,
                    IsAlien = false,
                    Universe = Universes.DC,
                    PlanetOfOrigin = Planets.Earth,
                    Abilities = new HashSet<Ability>( abilities.Where(a => new int[] { 13 }.Contains(a.AbilityID) ))
                },
                new Superhero
                {
                    SuperheroName = "Kick-Ass",
                    SecretIdentity = "Dave Lizewski",
                    YearOfAppearance = 2008,
                    IsAlien = false,
                    Universe = Universes.MillarWorld,
                    PlanetOfOrigin = Planets.Earth
                },
                new Superhero
                {
                    SuperheroName = "Invincible",
                    SecretIdentity = "Mark Grayson",
                    YearOfAppearance = 2002,
                    IsAlien = true,
                    Universe = Universes.Image,
                    PlanetOfOrigin = Planets.Viltrumite,
                    Abilities = new HashSet<Ability>( abilities.Where(a => new int[] { 1,2,4,5,6,10 }.Contains(a.AbilityID) ))
                },
                new Superhero
                {
                    SuperheroName = "Phoenix",
                    SecretIdentity = "Jean Gray",
                    YearOfAppearance = 1963,
                    IsAlien = false,
                    Universe = Universes.Marvel,
                    PlanetOfOrigin = Planets.Earth,
                    Abilities = new HashSet<Ability>( abilities.Where(a => new int[] { 11,15 }.Contains(a.AbilityID) ))
                },
                new Superhero
                {
                    SuperheroName = "Captain Marvel",
                    SecretIdentity = "Mar-vell",
                    YearOfAppearance = 1967,
                    IsAlien = true,
                    Universe = Universes.Marvel,
                    PlanetOfOrigin = Planets.Hala,
                    Abilities = new HashSet<Ability>( abilities.Where(a => new int[] { 1,2,3,4,5,6 }.Contains(a.AbilityID) ))
                }
            };

                // Loop through the ability of each superhero, and make sure that the ability has a reference
                // back to the superhero. This is to enforce the many-to-many relationship that entity framework
                // can implicitly support.
                foreach (var superhero in superheroes)
                {
                    foreach (var ability in superhero.Abilities)
                    {
                        ability.Superheroes.Add(superhero);
                    }
                }

                context.Abilities.AddRange(abilities);
                context.Superheroes.AddRange(superheroes);
                context.SaveChanges();
            }
        }
    }
}