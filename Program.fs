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
            Problem4.tests
            Problem5.tests
            Problem7.tests
          ]

    [<EntryPoint>]
    let main args =
        Problem7.decode "111" |> printfn "%A"
        Tests.runTestsWithArgs {defaultConfig with verbosity  = Logging.Verbose }   args tests
        //Tests.runTestsWithArgs defaultConfig args tests