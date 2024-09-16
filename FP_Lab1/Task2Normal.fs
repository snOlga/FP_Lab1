module Task2Normal

let getDivisors number =
    [
        for mbDivisor in [0..1..number-1] do
            if mbDivisor <> 0 && number % mbDivisor = 0 then
                yield mbDivisor
    ]

let getOneAmicable number = lazy List.sum (getDivisors number)
    

let getAmicables number = (number, (getOneAmicable number).Value)
    

let isAmicable number =
    number = List.sum (getDivisors ((getOneAmicable number).Force())) && number <> (getOneAmicable number).Value
    

let findAmicables minValue maxValue =
    [
    for number in [minValue..maxValue] do
        if isAmicable number then
            yield getAmicables number
    ]
    