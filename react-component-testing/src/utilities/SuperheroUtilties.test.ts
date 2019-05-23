import { SuperheroUtilities } from "./SuperheroUtilities";
import { ISuperhero } from "../superhero/types/Superhero.types";
import { Winner } from "../utilities/SuperheroUtilities";

const superheroUtilities: SuperheroUtilities = new SuperheroUtilities();

describe('Math functions', () => {
    test('two plus two is four', () => {
        expect(2 + 2).toBe(4);
      });
});

describe('Superhero Utilities', () => {
  test('guess that attacker wins', () => {
    const attacker: ISuperhero = {
      superheroName:'Zak',
      superheroID: 10,
      abilities: [
        {
          abilityID: 1,
          strengthLevel: 100,
          name: 'Super Speed'
        }
      ]
    };
    const defender: ISuperhero = {
      superheroName: 'Daric',
      superheroID: 10,
      abilities: [
        {
          abilityID: 2,
          strengthLevel: 0,
          name: 'Ability to recite the entire Bee Movie script'
        }
      ]
    };
    const superheroUtilities = new SuperheroUtilities();
    const winner = superheroUtilities.guessWinner(attacker, defender);
    expect(winner).toBe(Winner.attacker);
  })
})