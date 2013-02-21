module DieRollerTest

open FsUnit
open NUnit.Framework
open System
open Mechanics

// new Random(1) yields 1, 0, 2, 4, 3, 2... when called with .Next(6)
// new Random(1) yields 24, 11, 46, 77, 65, 43... when called with .Next(100)

[<TestFixture>]
type DieRollerTest() =

    [<Test>]
    member this.``When rolling a D6 with a fixed seed, correct value is returned.``() =
        let roller = new DieRoller(new Random(1))
        roller.rollD6 |> should equal 2

    [<Test>]
    member this.``When rolling a D66 with a fixed seed, correct value is returned.``() =
        let roller = new DieRoller(new Random(1))
        roller.rollD66 |> should equal 21

    [<Test>]
    member this.``When rolling a Dn with a fixed seed, correct value is returned.``() =
        let roller = new DieRoller(new Random(1))
        roller.rollDn 100 |> should equal 25