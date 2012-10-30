module DieRollerTest

open Mechanics
open NUnit.Framework
open System

    [<Test>]
    let ``When rolling a D6, a number between 1 and 6 is returned.`` ()=
        let roller = new DieRoller()
        let roll = roller.rollD6()
        Assert.That(roll >= 1  && roll <= 6)

    [<Test>]
    let ``When rolling a D6 with a fixed seed, correct value is returned.`` ()=
        let roller = new DieRoller(new Random(1))
        let roll = roller.rollD6()
        Assert.AreEqual(1, roll)