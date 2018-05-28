namespace DailyCodingProblem

open System
open Expecto.Tests
open Expecto

(*
   # Problem 2 - This problem was asked by Uber.

    Given an array of integers, return a new array 
    such that each element at index i of the new array is the product 
    of all the numbers in the original array except the one at i.

    For example, if our input was [1, 2, 3, 4, 5], 
    the expected output would be [120, 60, 40, 30, 24]. 
    If our input was [3, 2, 1], the expected output would be [2, 3, 6].

    Follow-up: what if you can't use division?
*)
module Problem2 = 

    let someOfOther (array: int seq) =
        let product = (1, array) ||> Seq.fold ( * )
        array |> Seq.map (fun x -> product / x) 

    let tests = 
        testList "Problem 2 : Product of all other" [
            test "[1, 2, 3, 4, 5]" {
              Expect.sequenceEqual (someOfOther [1; 2; 3; 4; 5])  [120; 60; 40; 30; 24] "[1, 2, 3, 4, 5] =>  [120, 60, 40, 30, 24]"
            }

            test "[3, 2, 1]" {
              Expect.sequenceEqual (someOfOther [3; 2; 1])  [2; 3; 6] "[3; 2; 1] =>  [2; 3; 6]"
            }
          ] 

