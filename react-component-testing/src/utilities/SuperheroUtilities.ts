import { ISuperhero } from "../superhero/types/Superhero.types";

export class SuperheroUtilities {
    guessWinner(attacker: ISuperhero, defender: ISuperhero): Winner {
        let attackerTotal : number = attacker.abilities!.map(a => a.strengthLevel).reduce((total, x) => { return total+ x});
        let defenderTotal : number = defender.abilities!.map(a => a.strengthLevel).reduce((total, x) => { return total+ x});

        if(attackerTotal > defenderTotal) {
            return Winner.attacker;
        } else if (defenderTotal > attackerTotal){
            return Winner.defender;
        } else {
            return Winner.draw;
        }
    }
}

export enum Winner {
    attacker = 0,
    defender = 1,
    draw = -1
}