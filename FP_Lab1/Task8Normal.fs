module Task8Normal

open System
open General

let filterSubString (line:string) (position:int) (adjacentCount:int) =
    String.filter Char.IsDigit line[position..(position+adjacentCount-1)]

let productsInLine (line:string) (adjacentCount:int) =
    [
        for position in [0..1..(String.length line-1)] do
            if (position + adjacentCount) <= (String.length line) then
                yield findProduct (filterSubString line position adjacentCount)
    ]

let maxProductInLine (line:string) (adjacentCount:int) =
    List.max (productsInLine line adjacentCount)

let generateProductList (lines:string array) (adjacentCount:int) = 
    [
        for line in lines do
            if String.length line >= adjacentCount then
                yield maxProductInLine line adjacentCount
    ]

let findMaxProduct (lines:string array) (adjacentCount:int)  =
    List.max (generateProductList lines adjacentCount)
