namespace DailyCodingProblem


module EntryPoint =

    open System
    open Expecto
    open Hopac
    open Logary
    open Logary.Configuration
    open Logary.Adapters.Facade
    open Logary.Targets

    let (|Int|_|) (str:string) =
       match Int32.TryParse(str) with
       | (true,int) -> Some(int)
       | _ -> None


    [<Tests>]
    let tests =
        testSequenced <| testList "Daily coding problem" [
            Problem1.tests
            Problem2.tests
            Problem3.tests
          ]

    [<EntryPoint>]
    let main args =

        //Problem3.serialize Problem3.node |> printfn "%s"
        //Problem3.deserialize (Problem3.serialize Problem3.node) |> printfn "%A"
        //0
        Tests.runTestsWithArgs {defaultConfig with verbosity  = Logging.Verbose }   args tests