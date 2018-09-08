// based off of https://fsharpforfunandprofit.com/posts/designing-with-types-intro/

// a namespace in .NET is a way to logically organize code.  You can call types, classes, structures, etc.
// from a certain name space by using it's fully qualified name or by implementing the 'using' directice
namespace WorkingWithTypes

type Contact = {
    Firstname: string;
    MiddleInitial: string;
    LastName: string;

    EmailAddress: string;
    IsEmailVerfied: bool;

    Address1: string;
    Address2: string;
    City: string;
    State: string;
    Zip: string;

    IsAddressValid: bool;
}

type PostalAddress = {
 
    Address1: string;
    Address2: string;
    City: string;
    State: string;
    Zip: string;  
}

type PostalContactInfo = {
    Address: PostalAddress;
    IsAddressValid: bool;
}

type PersonalName = {
    FirstName: string;
    MiddleInitial: string option;
    LastName: string;
}

type EmailContactInfo = {
    EmailAddress: string;
    IsEmailVerified: bool;
}

type Contact2 = {
    Name: PersonalName;
    EmailContactInfo: EmailContactInfo;
    PostalContactInfo: PostalContactInfo;
}