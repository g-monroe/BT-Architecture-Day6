import { ISuperhero } from "../superhero/types/Superhero.types";

export class SuperheroUtilities {
    guessWinner(attacker: ISuperhero, defender: ISuperhero) : Winner{
        let attackerAbilityTotal: number = 0;
        if (attacker.abilities){
            attackerAbilityTotal = attacker.abilities.map(a=>a.strengthLevel)
            .reduce((total, current) =>{
                return total + current;
            })
        }
        let defenderAbilityTotal: number = 0;
        if (defender.abilities){
            defenderAbilityTotal = defender.abilities.map(a=>a.strengthLevel)
            .reduce((total, current) =>{
                return total + current;
            })
        } 
        if (attackerAbilityTotal == defenderAbilityTotal){
            return Winner.draw;
        }
        return (attackerAbilityTotal > defenderAbilityTotal ) ?  Winner.attacker : Winner.defender;
    }

}
export enum Winner{
    attacker = 0,
    defender = 1,
    draw = 3,
}