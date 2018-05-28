namespace DailyCodingProblem

open System
open Expecto.Tests
open Expecto

(*
   # Problem 3 - This problem was asked by Google.

Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.

For example, given the following Node class

class Node:
    def __init__(self, val, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
The following test should pass:

node = Node('root', Node('left', Node('left.left')), Node('right'))
assert deserialize(serialize(node)).left.left.val == 'left.left'
*)
module Problem3 = 

    open System.Text

    type Node = { value:string; left:Node option; right: Node option}

    let separator = '/'
    let nullChar = '#'

    let serialize (n:Node) =
        let rec innerSerialize sb n =
            Printf.bprintf sb "%s%c" n.value separator
            match n.left with
            | None -> Printf.bprintf sb "%c%c" nullChar separator
            | Some l -> innerSerialize sb l
            match n.right with
            | None -> Printf.bprintf sb "%c%c" nullChar separator
            | Some r -> innerSerialize sb r

        let sb = (new StringBuilder())
        innerSerialize sb n
        sb.ToString()

    let leftleft = {value = "left.left"; left=None; right = None}
    let left = { value="left" ; left = Some (leftleft) ; right =None }
    let right = {value ="right"; left= None; right=None }
    
    let node = { value="root"; left = Some (left)  ; right = Some (right) }

    printf "%s" (serialize node)

    let deserialize (s:string) =
        let chunks = s.Split(separator) |> Seq.toList

        let rec innerDeserialize chunks =

            let h,t = match chunks with
                        | h::t -> h,t
                        | _ -> failwith "error !!"


            let value = h
            match value with
            | "#" -> None, t
            | _ -> 
                    let left ,rest = innerDeserialize t
                    let right ,rest = innerDeserialize rest
                    Some {value = value; left = left; right= right}, rest

        let result, _ = innerDeserialize chunks
        result

    //     let product = (1, array) ||> Seq.fold ( * )
    //     array |> Seq.map (fun x -> product / x) 

    let tests = 
        testList "Problem 3 : Serialize/deserialize Binnary Tree" [
            test "S/D node" {
              Expect.equal (serialize node |> deserialize)  (Some node) "serialize and deserialize shoud be node"
            }
          ] 

