module General

open System

let allNumbers = IO.File.ReadAllLines("../../../input.txt")

let parseStringToIntList (line:string) =
    List.map (fun chr -> int (chr.ToString())) (Seq.toList line)

let findProduct (line:string) =
    List.fold (fun acc elem -> acc * elem) 1 (parseStringToIntList line)
