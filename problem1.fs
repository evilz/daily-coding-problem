namespace DailyCodingProblem

open System
open Expecto.Tests
open Expecto

(* 

# Problem 1 :
Given a list of numbers, return whether any two sums to k.
For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
Bonus: Can you do this in one pass?
*)

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


    let tests = 
        testList "Problem 1 : find sum of two" [
            test "Find 17 in [10; 15; 3; 7]" {
              Expect.isTrue ( ([10; 15; 3; 7], 17 ) ||> anyTwoSumOf) "[10; 15; 3; 7] find 17"
            }

            test "Not exist" {
              Expect.isFalse ( ([1; 2; 3; 4; 5], 10) ||> anyTwoSumOf) "[1; 2; 3; 4; 5] find 10"
            }

            testAsync "Find 9 in [1; 2; 3; 4; 5]" {
              Expect.isTrue ( ([1; 2; 3; 4; 5], 9) ||> anyTwoSumOf) "[1; 2; 3; 4; 5], 9"
            }
          ] 
