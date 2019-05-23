import { SuperheroUtilities, Winner } from "./SuperheroUtilities";
import { ISuperhero } from "../superhero/types/Superhero.types";

describe('Math functions', () => {
  test('two plus two is four', () => {
    expect(2 + 2).toBe(4);
  });
});

describe('Superhero Utilities', () => {

  let superheroUtilities: SuperheroUtilities;
  beforeEach(() => {
    superheroUtilities = new SuperheroUtilities();
  });

  test('guess that attacker wins', () => {
    const attacker: ISuperhero = {
      superheroID: 10,
      superheroName: 'Batman',
      abilities: [{
        abilityID: 2,
        name: "I'm Batman!!!",
        strengthLevel: 100
      }
      ]
    };
    const defender: ISuperhero = {
      superheroID: 20,
      superheroName: 'The Flash',
      abilities: [{
        abilityID: 1,
        name: 'Speed',
        strengthLevel: 0
      }
      ]
    };

    const winner = superheroUtilities.guessWinner(attacker, defender);

    expect(winner).toBe(Winner.attacker);
  });  
  
  test('guess that there is a draw', () => {
    const attacker: ISuperhero = {
      superheroID: 10,
      superheroName: 'Batman',
      abilities: [{
        abilityID: 2,
        name: "I'm Batman!!!",
        strengthLevel: 50
      },
      {
        abilityID: 3,
        name: "Money",
        strengthLevel: 50
      }
      ]
    };
    const defender: ISuperhero = {
      superheroID: 20,
      superheroName: 'The Flash',
      abilities: [{
        abilityID: 1,
        name: 'Speed',
        strengthLevel: 100
      }
      ]
    };

    const winner = superheroUtilities.guessWinner(attacker, defender);

    expect(winner).toBe(Winner.draw);
  });
});