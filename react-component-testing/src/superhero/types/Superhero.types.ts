export interface ISuperhero {
    SuperheroID?: number;
    SuperheroName: string;
    SecretIdentity?: string;
    AgeAtOrigin?: number | null;
    YearOfAppearance?: number;
    IsAlien?: boolean;
    PlanetOfOrigin?: string | null;
    OriginStory?: string;
    Universe?: string;
    Abilities?: Ability[];
}

interface Ability {
    AbilityID: number;
    Name: string;
}

