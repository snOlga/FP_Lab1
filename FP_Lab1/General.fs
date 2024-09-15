module General

open System

let allNumbers = IO.File.ReadAllLines("input.txt")

let parseStringToIntList (line:string) =
    [
        for iter in [0..(String.length line-1)] do
            yield (Char.ToString line[iter] |> int)
    ]

let findProduct (line:string) =
    List.fold (fun acc elem -> acc * elem) 1 (parseStringToIntList line)
