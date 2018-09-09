// https://fsharpforfunandprofit.com/posts/function-composition/

// functions are left associative, as can seen with the partial application
// the following function is the same as 'let F w x y z = ((w x) y) z'
let F w x y z = w x y z

// function composition
let f  (x:int) = float x * 3.0
let g (x:float) = x > 4.0

// takes the output of f and uses it as the input of g
let h (x:int) =
    let y = f(x)
    g(y)

// a more compact way to do it.
let h' (x:int) = g(f(x))

// compiler correctly deduces g takes in an input 'b that is returned from f
// this is only possible because functions only have one input and one output
let compose f g x = g(f(x))

// definition of compose uses the ">>" symbol
// let (>>) f g x = g(f(x))

let add1 x = x + 1
let times2 x = x * 2
let add1Times2 x = (>>) add1 times2 x
add1Times2 3 |> ignore

// a more cleaner way is to use partial application and put the operatore between the two functions

// old style
let add1Times2' x = times2(add1 x)
// new style
let add1Times2''  = add1 >> times2
add1Times2'' 3

// the compostion operator has lower precedence than normal function application
// this means that the functions used in composition can have arguments without needing to use parentheses

let add n x = n + x
let times n x = x * n
let add1Times2''' = add 1 >> times 2
let add5Times3 = add 5 >> times 3

// as long as inputs and outputs match functions involved can use any kind of value
let twice f = f >> f
let add1' = (+) 1
let add1Twice = twice add1

// can't do
// signature: val addThenMultiply: int -> (int -> int) -> int -> int
// let addThenMultiply = (+) >> (*)
// because the input to "*" must be and int not 'int -> int'
// but we can tweak it to
let addThenMultiply = (+) 1 >> (*)
// compositon can also be done using the backwards "<<" operator
// this used to make code more English-like
let myList = []
myList |> List.isEmpty |> not
myList |> (not << List.isEmpty)