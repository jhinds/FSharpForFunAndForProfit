// based off of https://fsharpforfunandprofit.com/posts/partial-application/
// parital application: if you fix the first N params o a function you get a function of the remaining parameters

// adder patrial application

let add42 = (+) 42
add42 1 |> ignore
add42 3 |> ignore

let newList = [1;2;3] |> List.map add42

// create a tester application by partial application
let twoIsLessThan = (<) 2
let isFalse = twoIsLessThan 1 
let isTrue = twoIsLessThan 3

// filter each element with the twoIsLessThan function,
[1;2;3] |> List.filter twoIsLessThan |> ignore

// create a "printer" by partial application
let printer = printfn "printing param=%i"

// loop over each element and call the printer function
[1;2;3] |> List.iter printer

// can also be used to fix function parmeters
let add1 = (+) 1
let add1ToEach = List.map add1

let plus1List = add1ToEach [1;2;3;4]

// create an adder that supports a pluggable logging function
let adderWithPluggableLogger logger x y = 
    logger "x" x
    logger "y" y
    let result = x + y
    logger "x+y" result
    result

// create a logging function that writes to the console
let consoleLogger argName argValue =
    printfn "%s=%A" argName argValue

// create an adder with the console logger partially applied
let addWithConsoleLogger = adderWithPluggableLogger consoleLogger
addWithConsoleLogger 1 2 |> ignore
addWithConsoleLogger 42 99 |> ignore

// create a logging function that creates pop up windows
// won't work for unix. Only windows, just here as an example
// let popupLogger argName argValue = 
//     let message = sprintf "%s=%A" argName argValue
//     System.Windows.Forms.MessageBox.Show(text=message,
//                                          caption="Logger")
//     |> ignore

// create an adder with the popup logger partially applied
// let addWithPopupLogger = adderWithPluggableLogger popupLogger
// addWithPopupLogger 1 2 |> ignore
// addWithPopupLogger 42 99 |> ignore

// create another console adder with 42 baked in
let add42WithConsoleLogger = addWithConsoleLogger 42
[1;2;3] |> List.map add42WithConsoleLogger |> ignore 
[1;2;3] |> List.map add42 |> ignore 

// when designing functions for partial application
// the general guidelines are
// 
// 1. Put earlier: parameters more likely to static
// 2. Put last: the data structure or collection (or most varying argument)
// 3. For will-known operations such as "subtract", put in the expected order

let eachadd1 = List.map (fun i -> i+1)
eachadd1 [0;1;2;3]

let excludeOneOrLess = List.filter (fun i -> i>1)
excludeOneOrLess [0;1;2;3]

let sortDesc = List.sortBy (fun i -> -i)
sortDesc [0;1;2;3]

// piping using list functions 
let result =
    [1..10]
    |> List.map (fun i -> i+1)
    |> List.filter (fun i -> i>5)


// composing partially applied functions
let compositeOp = List.map (fun i -> i+1) >> List.filter (fun i -> i>5)
let result' = compositeOp [1..10]


// wrapping .NET base class libraries
// easy to acess in F# but usually take in data 
// as the first parameter so we can create functions
// to make chaining easier

let replace oldStr newStr (s:string) =
    s.Replace(oldValue=oldStr, newValue=newStr)

let startsWith lookFor (s:string) =
    s.StartsWith(lookFor)

let compositeOp' = replace "h" "j" >> startsWith "j"
let result'' = compositeOp' "hello" 

let add x y = x + y
// |> just allows you to put the parameter before the function
// <| the reverse pipe reduces the need for parenteses and can make the code
// cleaner depending on the situation
1+2 |> add <| 3+4 |> ignore