module DieRollerTest

open DieRoller
open NUnit.Framework

    [<Test>]
    let ``When rolling a D6, a number between 1 and 6 is returned.`` ()=
        let roll = rollD6()
        Assert.That(roll >= 1  && roll <= 6)