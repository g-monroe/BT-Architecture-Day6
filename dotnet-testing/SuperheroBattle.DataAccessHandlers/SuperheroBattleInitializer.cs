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
                        Name = "Fly",
                        StrengthLevel = 12
                    },
                    new Ability
                    {
                        Name = "Superhuman Strength",
                        StrengthLevel = 70
                    },
                    new Ability
                    {
                        Name = "Energy Absorption",
                        StrengthLevel = 30
                    },
                    new Ability
                    {
                        Name = "Superhuman Speed",
                        StrengthLevel = 66
                    },
                    new Ability
                    {
                        Name = "Superhuman Stamina",
                        StrengthLevel = 75
                    },
                    new Ability
                    {
                        Name = "Superhuman Durability",
                        StrengthLevel = 80
                    },
                    new Ability
                    {
                        Name = "Photographic Memory",
                        StrengthLevel = 20
                    },
                    new Ability
                    {
                        Name = "Superhuman Agility",                        ,
                        StrengthLevel = 50
                    },
                    new Ability
                    {
                        Name = "Speed Reading",
                        StrengthLevel = 2
                    },
                    new Ability
                    {
                        Name = "Regenerative Healing",
                        StrengthLevel = 90
                    },
                    new Ability
                    {
                        Name = "Telepathy",
                        StrengthLevel = 33
                    },
                    new Ability
                    {
                        Name = "Terrible Singing",
                        StrengthLevel = 0
                    },
                    new Ability
                    {
                        Name = "Object/Money",
                        StrengthLevel = 5
                    },
                    new Ability
                    {
                        Name = "CSI Zoom Focus",
                        StrengthLevel = 16
                    },
                    new Ability
                    {
                        Name = "Telekinesis",
                        StrengthLevel = 88
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
                        AbilityModifier = 20
                    },
                    new Superhero
                    {
                        SuperheroName = "Batman",
                        SecretIdentity = "Bruce Wayne",
                        YearOfAppearance = 1939,
                        IsAlien = false,
                        Universe = Universes.DC,
                        PlanetOfOrigin = Planets.Earth,
                        AbilityModifier = 0
                    },
                    new Superhero
                    {
                        SuperheroName = "Kick-Ass",
                        SecretIdentity = "Dave Lizewski",
                        YearOfAppearance = 2008,
                        IsAlien = false,
                        Universe = Universes.MillarWorld,
                        PlanetOfOrigin = Planets.Earth,
                        AbilityModifier = -15
                    },
                    new Superhero
                    {
                        SuperheroName = "Invincible",
                        SecretIdentity = "Mark Grayson",
                        YearOfAppearance = 2002,
                        IsAlien = true,
                        Universe = Universes.Image,
                        PlanetOfOrigin = Planets.Viltrumite,
                        AbilityModifier = 50
                    },
                    new Superhero
                    {
                        SuperheroName = "Phoenix",
                        SecretIdentity = "Jean Gray",
                        YearOfAppearance = 1963,
                        IsAlien = false,
                        Universe = Universes.Marvel,
                        PlanetOfOrigin = Planets.Earth,
                        AbilityModifier = 70
                    },
                    new Superhero
                    {
                        SuperheroName = "Captain Marvel",
                        SecretIdentity = "Mar-vell",
                        YearOfAppearance = 1967,
                        IsAlien = true,
                        Universe = Universes.Marvel,
                        PlanetOfOrigin = Planets.Hala,
                        AbilityModifier = 30
                    }
                };

            context.Abilities.AddRange(abilities);
            context.Superheroes.AddRange(superheroes);
            context.SaveChanges();
        }
    }
}