open System
open General
open System.IO

[<EntryPoint>]
let main (args : string[]) =
    File.WriteAllText("output1.txt", (Task8Normal.findMaxProduct (allNumbers[1].Split[|'0'|]) (allNumbers[0] |> int) |> string) )
    File.WriteAllText("output2.txt", (Task8Recursion.findMaxProduct (allNumbers[1].Split[|'0'|]) (allNumbers[0] |> int) |> string) )
    use writer = new StreamWriter("output3.txt")
    (Task21Normal.findAmicables 0 10000) |> List.iter (fun (num:int, amicable:int) -> writer.WriteLine (sprintf "%d,%d" num amicable))
    use writer2 = new StreamWriter("output4.txt")
    (Task21Recursion.findAmicables 2 10000) |> List.iter (fun (num:int, amicable:int) -> writer2.WriteLine (sprintf "%d,%d" num amicable))
    0