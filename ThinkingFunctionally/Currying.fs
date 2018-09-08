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

