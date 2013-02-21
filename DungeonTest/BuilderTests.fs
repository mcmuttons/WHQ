module BuilderTests

open Builder
open Room
open FsUnit
open NUnit.Framework
open System

[<TestFixture>]
type BuilderTests() =

    [<Test>]
    member this.``When pulling a random item, the correct item is returned.``() =
        let randomizer = Random(2) // first .Next(5) gives 3
        [1..5] |> pullRandomItem randomizer |> should equal 4

    [<Test>]
    member this.``When shuffling a list with a given randomizer, list is shuffled correctly.``() =
        let randomizer = Random(2) // .Next(5) gives 3, 2, 0, 4, 0
        [1..5] |> shuffle randomizer |> should equal [3; 5; 2; 1; 4] 

    [<Test>]
    member this.``When pulling items off a list, the cards pulled and the remainder of the list are returned.``() =
        [1..10] |> splitAt 6 |> should equal ([1..6], [7..10])

    [<Test>]
    member this.``When calling with item that needs several copies, number of copies is returned.``() =
        expandItem 4 5 |> should equal [4; 4; 4; 4; 4]

    [<Test>]
    member this.``When sending a list with counters, items should occur the right number of times.``() =
        [(1,2);(2,1);(3,1)] |> expand |> should equal [1;1;2;3]

    [<Test>]
    member this.``When splitting to size, two lists of correct size are returned.``() =
        [1;2;3;4;5;6;7] |> splitList 5 3 |> should equal ([1;2;3],[4;5])    