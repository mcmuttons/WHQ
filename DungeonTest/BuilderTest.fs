module BuilderTest

open Builder
open NUnit.Framework

    [<Test>] 
    let ``When building a dungeon, a deck of twelve cards is returned.`` () =
        Assert.AreEqual(12, Builder.build() |> Seq.length)

    

