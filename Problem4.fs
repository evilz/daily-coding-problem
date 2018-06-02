namespace DailyCodingProblem

open System
open Expecto.Tests
open Expecto

(*
   # Problem 4 - This problem was asked by Stripe.

Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.

For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

You can modify the input array in-place.
*)
module Problem4 = 

    let findFirstMissingPositiveInteger (array: 'a[]) = 
         
        // remove negative and 0
        let array = array |> Array.filter (fun i -> i > 0) // O(N)
        //printfn "%A"array

        // flag all value at index as negative 
        for i = 0 to array.Length - 1 do // O(N)
            let value = array.[i] |> abs
            if value - 1 < array.Length && array.[value - 1] > 0 then
                array.[value - 1] <- -array.[value - 1]

        //printfn "%A"array

        // Return the first index value at 
        // which is positive
        // and add 1 cause index start at 0
        array 
        |> Array.tryFindIndex (fun i -> i > 0) // O(N)
        |> function 
            | None -> array.Length + 1
            | Some i -> i + 1

    let tests = 
        testList "Problem 4 : first missing positive integer" [
            test "[3, 4, -1, 1] should give 2" {
              Expect.equal (findFirstMissingPositiveInteger [|3; 4; -1; 1|])  2 "2 is the first missing positive int"
            }
            test "[1, 2, 0] should give 3" {
              Expect.equal (findFirstMissingPositiveInteger [|1; 2; 0|])  3 "3 is the first missing positive int"
            }
            test "[7,8,9,11,12] should give 1" {
              Expect.equal (findFirstMissingPositiveInteger [|7;8;9;11;12|])  1 "1 is the first missing positive int"
            }
          ]