module FP_Lab1

open NUnit.Framework
open General

[<Test>]
let Test1 () =
    Assert.AreEqual(5832, (Task8Normal.findMaxProduct (allNumbers[1].Split [| '0' |]) (allNumbers[0] |> int)))

[<Test>]
let Test2 () =
    Assert.AreEqual(5832, (Task8Recursion.findMaxProduct (allNumbers[1].Split [| '0' |]) (allNumbers[0] |> int)))

let trueAmicables = [ 220, 284; 284, 220 ]

[<Test>]
let Test3 () =
    Assert.AreEqual(trueAmicables, (Task21Normal.findAmicables 0 300))

[<Test>]
let Test4 () =
    Assert.AreEqual(trueAmicables, (Task21Recursion.findAmicables 2 300))
