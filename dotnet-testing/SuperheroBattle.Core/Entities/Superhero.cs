namespace SuperheroBattle.Core
{
    public class Superhero
    {
        public int SuperheroID { get; set; }
        public string SuperheroName { get; set; }
        public string SecretIdentity { get; set; }
        public int? AgeAtOrigin { get; set; }
        public int YearOfAppearance { get; set; }
        public bool IsAlien { get; set; }
        public Planets? PlanetOfOrigin { get; set; }
        public string OriginStory { get; set; }
        public Universes Universe { get; set; }
        public Ability[] Abilities { get; set; }
    }

    public class Ability
    {
        public string AbilityID { get; set; }
        public string Label { get; set; }
    }

    public enum Universes
    {
        None = 0,
        Marvel = 1,
        DC = 2,
        Valiant = 3,
        MillarWorld = 4,
        Archie = 5,
        Other = 6
    }

    public enum Planets
    {
        Earth = 0,
        Krypton = 1,
        Hala = 2,
        Ego = 3,
        Oa = 4,
        Titan = 5
    }
}
