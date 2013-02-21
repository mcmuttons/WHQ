namespace DataReaderTests

open DataStorage
open FsUnit
open NUnit.Framework

[<TestFixture>]
type DataReaderTests() =

    let reader = DataReader()

    [<Test>]
    member this.``When reading dungeon rooms from database, the rooms are returned.``() =
        reader.readDungeonRooms |> should haveLength 16 

    [<Test>]
    member this.``When reading objective rooms from database, the rooms are returned.``() =
        reader.readObjectiveRooms |> should haveLength 7 
