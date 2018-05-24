namespace DailyCodingProblem


module Problem1 = 

    // Using Set for low space in memory O(n log N)
    // Array of size k maybe better but can take more space
    let private anyTwoSumOf array k =
        
        let items =
            (Set.empty , array) ||> Seq.fold (
                fun s current -> 
                    s |> Set.contains (k-current)                       // O(log N)
                    |> function
                        | true -> Set.empty.Add(current).Add(k-current)  // O(log N) + O(log N) => O(2)
                        | false -> s.Add(current)                       // O(log N)
            )
        match items.Count with
        | 2 -> true
        | _ -> false

    let private printSolution array k = 
        printfn "Array is %A" array
        printfn "k is %i" k
        printfn "Answer is %b" (anyTwoSumOf array k)
        printfn ""

    let private solution() =

        ([10; 15; 3; 7], 17 ) ||> printSolution

        ([1; 2; 3; 4; 5], 10) ||> printSolution

        ([1; 2; 3; 4; 5], 9) ||> printSolution

    let problem =  {
        subject = @"Given a list of numbers, return whether any two sums to k.
For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
Bonus: Can you do this in one pass?"
        solution = solution
    }