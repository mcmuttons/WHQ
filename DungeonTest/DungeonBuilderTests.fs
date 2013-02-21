module DungeonBuilderTests

open Room
open Dungeon
open FsUnit
open NUnit.Framework

[<TestFixture>]
type DungeonBuilderTests() =
    
    let rec print (cards:List<Room>) =
        match cards with
            | []    -> ()
            | card::rest ->
                printf "%s %s\n" card.Name (card.IsObjective.ToString())
                print rest
    
    [<Test>]
    member this.``Build dungeon test.``() =
        let builder = DungeonBuilder()
        print builder.BuildDungeon