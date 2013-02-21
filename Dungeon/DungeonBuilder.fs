namespace Dungeon

open Builder
open DataStorage
open DungeonParams
open System

type DungeonBuilder (randomizer, parameters) =
    let dataReader = DataReader()

    let getDungeonParts =
        dataReader.readDungeonRooms
        |> expand
        |> shuffle randomizer
        |> splitList parameters.Depth parameters.DepthBeforeObjective

    let joinDungeonParts objectiveRoom firstPart secondPart = 
        (objectiveRoom::secondPart) 
        |> shuffle randomizer
        |> List.append firstPart
    
    new() = DungeonBuilder(new Random(), { Depth = 11; DepthBeforeObjective = 6 }) 

    member this.BuildDungeon =
        let firstPart, secondPart = getDungeonParts
        let objectiveRoom = dataReader.readObjectiveRooms |> pullRandomItem randomizer
        joinDungeonParts objectiveRoom firstPart secondPart