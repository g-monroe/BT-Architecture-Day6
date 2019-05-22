export interface ISuperhero {
    superheroID: number;
    superheroName: string;
    secretIdentity?: string;
    ageAtOrigin?: number | null;
    yearOfAppearance?: number;
    isAlien?: boolean;
    planetOfOrigin?: string | null;
    originStory?: string;
    universe?: string;
    primaryColor?: string;
    secondaryColor?: string;
    abilities?: Ability[];
}

interface Ability {
    abilityID: number;
    name: string;
}

