// https://fsharpforfunandprofit.com/posts/defining-functions/

// Anonynous functions (aka lambdas)
// defined as "fun param1 param2 etc -> expression"

// lambda that defines addition
let add = fun x y -> x + y
// same as...
let add' x y = x + y

// When are lambdas commonly used
// for short expressions and you don't want to define a function

// 1) list operations
let add1 i = i + 1
[1..10] |> List.map add1
//vs
[1..10] |> List.map (fun i -> i + 1)

// 2) to make clear you are returning a function
let adderGenerator x = (+) x
//vs
let adderGenerator' x = fun y -> x + y

// can aslo nest lambdas. here are some generator examples 
let adderGenerator1 x y = x + y
let adderGenerator2 x   = fun y -> x + y
let adderGenerator3     = fun x -> (fun y -> x + y)

// pattern matching on parameters
// can only match when it is always possible
// this means you cannot patch on Lists or union types
type Name = {first:string; last:string}
let bob = {first="bob"; last="smith"}

let f1 name = 
    let {first=f; last=l} = name
    printfn "first=%s; last=%s" f l

let f2 {first=f; last=l} = 
    printfn "first=%s; last=%s" f l

f1 bob
f2 bob

// tuples vs multiple parameters

// two params separated by spaces
let addTwoParams x y = x + y

// one param that is a tuple
let addTuple aTuple =
    let (x,y) = aTuple
    x + y

// one param that is a tuple as well
let addConfusingTuple (x,y) = x + y

// usually only pass in tuples when they are meaningful in themesleves such as coordinates

// .NET functions are a special case where they aren't a true tuple and all aprams must be passed in
System.String.Compare("a", "b") |> ignore

// but can partiallly apply with a wrapper
let strCompare x y = System.String.Compare(x,y)
let strCompareWithB = strCompare "B"
["A"; "B"; "C"] |> List.map strCompareWithB

// Guidelines for separate vs. grouped parameters
