open System
open General

[<EntryPoint>]
let main (args : string[]) =
    IO.File.WriteAllText("output1.txt", (FoldFilter.findMaxProduct (allNumbers[1].Split[|'0'|]) (allNumbers[0] |> int) |> string) )
    IO.File.WriteAllText("output2.txt", (Recursions.findMaxProduct (allNumbers[1].Split[|'0'|]) (allNumbers[0] |> int) |> string) )
    printf "%A" (Task2Normal.findAmicables 0 10000)
    0