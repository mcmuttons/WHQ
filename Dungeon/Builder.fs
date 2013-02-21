module Builder

open Room
open System

let pullRandomItem (randomizer:Random) items =
    List.nth items (randomizer.Next(items |> List.length))

let shuffle (randomizer:Random) items =
    items |> List.sortBy(fun x -> randomizer.Next(items |> List.length))

let splitAt count items =
    let rec splitAt' count items acc =
        match items with
        | []                -> acc |> List.rev, []
        | _ when count = 0  -> acc |> List.rev, items
        | first::rest       -> splitAt' (count-1) rest (first::acc)
    splitAt' count items []
   
let rec expandItem item count =
    if count = 1 then [item]
    else item::expandItem item (count-1)

let rec expand items =
    match items with
    | []                -> []
    | (item, count)::rest -> expand rest |> List.append (expandItem item count)
     
let splitList depth depthBeforeSplit items =
    items
    |> Seq.take depth
    |> Seq.toList
    |> splitAt depthBeforeSplit