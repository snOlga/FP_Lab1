module Task8Recursion

open System
open General

let filterSubString (line: string) (position: int) (adjacentCount: int) =
    String.filter Char.IsDigit line[position .. (position + adjacentCount - 1)]

let rec maxProductInLine (line: string) (adjacentCount: int) (position: int) =
    match (position + adjacentCount) with
    | sum when sum < (String.length line) -> (maxProductInLine line adjacentCount (position + 1))
    | sum when sum = (String.length line) -> findProduct (filterSubString line position adjacentCount)
    | _ -> 0


let generateProductList (lines: string array) (adjacentCount: int) =
    [ for line in lines do
          if String.length line >= adjacentCount then
              yield maxProductInLine line adjacentCount 0 ]

let findMaxProduct (lines: string array) (adjacentCount: int) =
    List.max (generateProductList lines adjacentCount)
