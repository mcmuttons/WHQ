namespace DataStorage

open Room
open DatabaseProvider

type DataReader() =

    member this.readDungeonRooms =
        context.DungeonRooms |> Seq.map (fun room -> { Name = room.Name; IsObjective = false}, room.NumberPossible) |> Seq.toList

    member this.readObjectiveRooms =
        context.ObjectiveRooms |> Seq.map (fun room -> { Name = room.Name; IsObjective = true }) |> Seq.toList

