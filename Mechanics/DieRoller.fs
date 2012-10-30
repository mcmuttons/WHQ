namespace Mechanics

open System

type DieRoller(r) =
    let randomizer = r
    
    new() = DieRoller(new Random())
    
        member this.rollD6 ()= randomizer.Next(6)