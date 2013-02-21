namespace Mechanics

open System

type DieRoller(r : Random) =
    let randomizer = r
    let roll n = randomizer.Next(n) + 1

    new() = DieRoller(new Random())

    member this.rollD6 = roll 6
    member this.rollD66 = roll 6 * 10 + roll 6
    member this.rollDn n = roll n