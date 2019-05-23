import { SuperheroUtilities, Winner } from "./SuperheroUtilities";
import { ISuperhero } from "../superhero/types/Superhero.types";

const superheroUtilities: SuperheroUtilities = new SuperheroUtilities();

describe('Math functions', () => {
    test('two plus two is four', () => {
        expect(2 + 2).toBe(4);
      });
});

describe('Superhero Utilities', () => {
  var superheroUtilities: SuperheroUtilities;
  beforeEach(() => {
    superheroUtilities = new SuperheroUtilities();
  })
  test('attacker guess that attacker win', () => {
    const attacker: ISuperhero = {
      superheroName: "here",
      superheroID: 10,
      abilities: [{
        abilityID:1,
        name: 'Speed',
        strengthLevel: 100
      }]
    };
    const defender: ISuperhero = {
      superheroName: "here2",
      superheroID: 20,
      abilities: [{
        abilityID:2,
        name: 'Flight',
        strengthLevel: 0
      }]
    }; 
    const winner = superheroUtilities.guessWinner(attacker, defender);
    expect(winner).toBe(Winner.attacker);
  })
  test('attacker guess that attacker draw', () => {
    const attacker: ISuperhero = {
      superheroName: "here",
      superheroID: 10,
      abilities: [{
        abilityID:1,
        name: 'Speed',
        strengthLevel: 100
      }]
    };
    const defender: ISuperhero = {
      superheroName: "here2",
      superheroID: 20,
      abilities: [{
        abilityID:2,
        name: 'Flight',
        strengthLevel: 100
      }]
    }; 
    const winner = superheroUtilities.guessWinner(attacker, defender);
    expect(winner).toBe(Winner.draw);
  })
  test('attacker guess that defender win', () => {
    const attacker: ISuperhero = {
      superheroName: "here",
      superheroID: 10,
      abilities: [{
        abilityID:1,
        name: 'Speed',
        strengthLevel: 0
      }]
    };
    const defender: ISuperhero = {
      superheroName: "here2",
      superheroID: 20,
      abilities: [{
        abilityID:2,
        name: 'Flight',
        strengthLevel: 100
      }]
    }; 
    const winner = superheroUtilities.guessWinner(attacker, defender);
    expect(winner).toBe(Winner.defender);
  })
})