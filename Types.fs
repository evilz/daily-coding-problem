namespace DailyCodingProblem

[<AutoOpen>]
module Types =

    let cprintf c fmt = 
        Printf.kprintf
            (fun s ->
                let old = System.Console.ForegroundColor
                try
                    System.Console.ForegroundColor <- c;
                    System.Console.Write s
                finally
                    System.Console.ForegroundColor <- old)
            fmt

    let cprintfn c fmt =
        cprintf c fmt
        printfn ""
    
    type Problem = {
        subject: string
        solution: unit -> unit
    }