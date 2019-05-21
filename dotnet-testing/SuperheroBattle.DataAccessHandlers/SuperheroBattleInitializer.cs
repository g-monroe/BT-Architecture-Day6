using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SuperheroBattle.DataAccessHandlers
{
    public static class SuperheroBattleInitializer
    {
        public static void SeedData(SuperheroBattleContext context)
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
                        AgeAtOrigin = 15
                    },
                    new Superhero
                    {
                        SuperheroName = "Batman",
                        SecretIdentity = "Bruce Wayne",
                        YearOfAppearance = 1939,
                        IsAlien = false,
                        Universe = Universes.DC,
                        PlanetOfOrigin = Planets.Earth
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
                        PlanetOfOrigin = Planets.Viltrumite
                    },
                    new Superhero
                    {
                        SuperheroName = "Phoenix",
                        SecretIdentity = "Jean Gray",
                        YearOfAppearance = 1963,
                        IsAlien = false,
                        Universe = Universes.Marvel,
                        PlanetOfOrigin = Planets.Earth
                    },
                    new Superhero
                    {
                        SuperheroName = "Captain Marvel",
                        SecretIdentity = "Mar-vell",
                        YearOfAppearance = 1967,
                        IsAlien = true,
                        Universe = Universes.Marvel,
                        PlanetOfOrigin = Planets.Hala
                    }
                };

            var superheroAbilityMapper = new Dictionary<string, int[]>()
            {
                { "Spider-Man", new int[] { 2,5,6,8 } },
                { "Batman", new int[] { 13 } },
                { "Invincible", new int[] { 1, 2, 4, 5, 6, 10 } },
                { "Phoenix", new int[] { 11, 15 } },
                { "Captain Marvel", new int[] { 1, 2, 3, 4, 5, 6 } }
            };

            var superheroAbilities = superheroAbilityMapper.SelectMany(sam =>
            {
                var superhero = superheroes.Single(s => s.SuperheroName == sam.Key);
                var sa = abilities.Where(a => sam.Value.Contains(a.AbilityID))
                                                  .Select(a => new SuperheroAbility { AbilityID = a.AbilityID, Ability = a, SuperheroID = superhero.SuperheroID, Superhero = superhero });

                return sa;
            });

            // Loop through the ability of each superhero, and make sure that the ability has a reference
            // back to the superhero. This is to enforce the many-to-many relationship that entity framework
            // can implicitly support.            
            foreach (var sa in superheroAbilities)
            {
                sa.Superhero.SuperheroAbilities.Add(sa);
                sa.Ability.SuperheroAbilities.Add(sa);
            }

            context.Abilities.AddRange(abilities);
            context.Superheroes.AddRange(superheroes);
            context.SaveChanges();
        }
    }
}