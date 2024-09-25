module Task21Recursion

let getDivisors number =
    [
        for mbDivisor in [0..1..number-1] do
            if mbDivisor <> 0 && number % mbDivisor = 0 then
                yield mbDivisor
    ]

let rec getOneAmicable number divisor amicableSum = 
    match divisor with
    | 1 -> amicableSum+1
    | divisor when (number % divisor = 0) -> getOneAmicable number (divisor-1)(amicableSum + divisor)
    | _ -> getOneAmicable number (divisor-1) amicableSum
    

let getAmicables number = 
    (number, (getOneAmicable number (number-1) 0))
    

let isAmicable number =
    number = List.sum (getDivisors (getOneAmicable number (number-1) 0)) && number <> (getOneAmicable number (number-1) 0)
    

let findAmicables minValue maxValue =
    [
    for number in [minValue..maxValue] do
        if isAmicable number then
            yield getAmicables number
    ]
    