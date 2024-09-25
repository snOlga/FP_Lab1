# FP_Lab1

Сафонова Ольга 368764

---

## Problem 8
The four adjacent digits in the 
1000-digit number that have the greatest product are 9 * 9 * 8 * 9 = 5832.

73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450

Find the thirteen adjacent digits in the 
1000-digit number that have the greatest product. What is the value of this product?

## Problem 21

Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).

If d(a) = b and d(b) = a, where  a <> b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.

## Реализация

[Вариант реализации проблемы 8 - 1](./FP_Lab1/Task8Normal.fs)

[Вывод](./FP_Lab1/output1.txt)

Использовано: 

Генератор списков:
```
let generateProductList (lines:string array) (adjacentCount:int) = 
    [
        for line in lines do
            if String.length line >= adjacentCount then
                yield maxProductInLine line adjacentCount
    ]
```
Фильтр:
```
let filterSubString (line:string) (position:int) (adjacentCount:int) =
    String.filter Char.IsDigit line[position..(position+adjacentCount-1)]
```
Сложение списка: [код здесь](./FP_Lab1/General.fs)
```
let findProduct (line:string) =
    List.fold (fun acc elem -> acc * elem) 1 (parseStringToIntList line)
```
Оператор обратного конвейера: [код здесь](./FP_Lab1/Program.fs)
```
(Task21Normal.findAmicables 0 10000) |> List.iter (fun (num:int, amicable:int) -> writer.WriteLine (sprintf "%d,%d" num amicable))
```
Маппинг: [код здесь](./FP_Lab1/General.fs)
```
    List.map (fun chr -> int (chr.ToString())) (Seq.toList line)
```

---
[Вариант реализации проблемы 8 - 2](./FP_Lab1/Task8Recursion.fs)

[Вывод](./FP_Lab1/output2.txt)

Использовано:

Рекурсия:
```
let rec maxProductInLine (line:string) (adjacentCount:int) (position:int) =
    if (position + adjacentCount) < (String.length line) then
        (maxProductInLine line adjacentCount (position+1))
    elif (position + adjacentCount) = (String.length line) then
        findProduct (filterSubString line position adjacentCount)
    else
        0
```

Сопоставление с образцом 
```
let rec maxProductInLine (line:string) (adjacentCount:int) (position:int) =
    match (position + adjacentCount) with
    | sum when sum < (String.length line) -> (maxProductInLine line adjacentCount (position+1))
    | sum when sum = (String.length line) -> findProduct (filterSubString line position adjacentCount)
    | _ -> 0
```
---
[Вариант реализации проблемы 21 -1](./FP_Lab1/Task21Normal.fs)

[Вывод](./FP_Lab1/output3.txt)

Использовано:

Кортежи:
```
let getAmicables number = (number, getOneAmicable number) // int -> int * int
```
Отложенные вычисления:
```
let getOneAmicable number = lazy List.sum (getDivisors number)
```
---
[Вариант реализации проблемы 21 - 2](./FP_Lab1/Task21Recursion.fs)

[Вывод](./FP_Lab1/output4.txt)

Использовано:

Рекурсия:
```
let rec getOneAmicable number divisor amicableSum = 
    if divisor <> 1 then
        if number % divisor = 0 then
            getOneAmicable number (divisor-1)(amicableSum + divisor)
        else
            getOneAmicable number (divisor-1) amicableSum
    else
        amicableSum+1
```

Сопоставление с образцом 
```
let rec getOneAmicable number divisor amicableSum = 
    match divisor with
    | 1 -> amicableSum+1
    | divisor when (number % divisor = 0) -> getOneAmicable number (divisor-1)(amicableSum + divisor)
    | _ -> getOneAmicable number (divisor-1) amicableSum
```
---

[Версия решения на C#](./CSharp/Program.cs)

[Вывод-1](./CSharp/output1.txt)

[Вывод-2](./CSharp/output2.txt)

## Вывод
Очень сложно было думать в контексте отсутствующией возможности накапливать счётчики, пришлось действительно переосмысливать первое пришедшее в голову решение 