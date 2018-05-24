namespace DailyCodingProblem

module EntryPoint =

    open System

    let (|Int|_|) (str:string) =
       match Int32.TryParse(str) with
       | (true,int) -> Some(int)
       | _ -> None

    let problems = 
        [ Problem1.problem ] 


    [<EntryPoint>]
    let main argv =

        printfn "Choose a problem from 1 to %i" problems.Length

        let rec getProblemIndex() = 
            Console.ReadLine() 
                    |> function
                    |  Int i when i <= problems.Length && i > 0 -> i
                    | _ -> 
                        printfn "Please choose from 1 to %i !!!" problems.Length
                        getProblemIndex()

        let index = getProblemIndex()

        printfn "PROBLEM %i: \n\r============ \n\r%s" index problems.[index - 1].subject
        printfn "" 
        printfn "Answer:"
        problems.[index - 1].solution()
        
        printfn "" 
        printfn "" 
        0 // return an integer exit code
