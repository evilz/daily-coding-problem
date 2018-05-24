namespace DailyCodingProblem

[<AutoOpen>]
module Types =

    
    type Problem = {
        subject: string
        solution: unit -> unit
    }