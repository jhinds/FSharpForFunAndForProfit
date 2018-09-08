type EmailAddress = EmailAddress of string
type ZipCode = ZipCode of string
type StateCode = StateCode of string

// using the constructor as a function

// '|> ignore' will discard this value, probably wouldn't use it for real
// in actual code
let a = "fakeaddress@fakedomain.com" |> EmailAddress |> ignore
["amy@fakedomain.com", "bill@fakedomain.com", "cindy@fakedomain.com"] |> List.map EmailAddress |> ignore

let a = "fakeaddress@fakedomain.com" |> EmailAddress
let (EmailAddress a'') = a

let addresses = 
    ["amy@fakedomain.com", "bill@fakedomain.com", "cindy@fakedomain.com"] 
    |> List.map EmailAddress
