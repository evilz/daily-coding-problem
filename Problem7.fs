namespace DailyCodingProblem
open System
open Expecto.Tests
open Expecto
open System.Collections.Generic
(*
This problem was asked by Facebook.

(decode Ways)
Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.

For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.

*)


module Problem7 = 

    let decode message =

        let uperLimit = 26
        let maxHeadSize = 2

        
        let rec inner (message:string) = 
            
            if message |> String.IsNullOrWhiteSpace then 
                1
            else
                let mutable sum = 0
                for headSize = 1 to maxHeadSize do
                    // check headSize <= message
                    if headSize <= message.Length then
                        let head = message.Substring(0,headSize)
                        let tail = message.Substring(headSize)

                        if (head |> Int32.Parse) <= uperLimit then
                            sum <- sum + inner tail
                        
                sum
            
        inner message

    let tests = 
        testList "Problem 7 : cons car cdr" [
            test "'111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'" {
              Expect.equal (decode "111")  3" should give 'aaa', 'ka', and 'ak'"
            }
          ]