module Currying
// function that prints two numbers
let printTwoParameters x y =
    printfn "x=%i y=%i"

// internally the compiler writes
let printTwoParameters' x =
    let subFunction y =
        printfn "x=%i y=%i" x y
    subFunction


// if you pass in one paramaeter to the function you get back another 
// function not an error
let oneMoreToGo = printTwoParameters 1
oneMoreToGo 2 |> ignore
// going step by step
let x = 5
let y = 99
let intermediateFn = printTwoParameters x
let result = intermediateFn y

// inline version of step by step
let result' = (printTwoParameters x) y

// normal version 
let result'' = printTwoParameters x y


// '+' sign is another example where it has an intermediate function
// this works for all operators and even the `printfn1` function
let x' = 6
let y' = 99
let intermediateFnPlusFn = (+) x
let resultPlus = intermediateFnPlusFn y

let resultPlus' = (+) x y
let resultPlus'' = x + y


