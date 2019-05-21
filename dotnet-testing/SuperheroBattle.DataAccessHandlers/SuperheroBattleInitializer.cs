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
                        Name = "Fly"
                    },
                    new Ability
                    {
                        Name = "Superhuman Strength"
                    },
                    new Ability
                    {
                        Name = "Energy Absorption"
                    },
                    new Ability
                    {
                        Name = "Superhuman Speed"
                    },
                    new Ability
                    {
                        Name = "Superhuman Stamina"
                    },
                    new Ability
                    {
                        Name = "Superhuman Durability"
                    },
                    new Ability
                    {
                        Name = "Photographic Memory"
                    },
                    new Ability
                    {
                        Name = "Superhuman Agility"
                    },
                    new Ability
                    {
                        Name = "Speed Reading"
                    },
                    new Ability
                    {
                        Name = "Regenerative Healing"
                    },
                    new Ability
                    {
                        Name = "Telepathy"
                    },
                    new Ability
                    {
                        Name = "Terrible Singing"
                    },
                    new Ability
                    {
                        Name = "Object/Money"
                    },
                    new Ability
                    {
                        Name = "CSI Zoom Focus"
                    },
                    new Ability
                    {
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

            context.Abilities.AddRange(abilities);
            context.Superheroes.AddRange(superheroes);
            context.SaveChanges();
        }
    }
}