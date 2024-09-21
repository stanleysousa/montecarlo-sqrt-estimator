namespace MCSqrtEstimator

module Program =

    open System
    open Plot
    open MMCSqrtEstimator.MonteCarlo

    let plotRelativeErrors (results : MonteCarlo.Simulation.Output array) = 
        if results |> Seq.length > 0 then
            let v = (results |> Seq.head) .runParameters.value
            let title = sprintf "Relative error for v=%f and n samples" v
            let data =
                results
                |> Seq.map (fun o -> o.runParameters.samples, o.relativeError)
            Line.plot title data

    let handleSqrtResult  =
        function
            | MonteCarlo.Simulation.Result.Success output ->
                McSqrt.print output
                Some output
            | MonteCarlo.Simulation.Result.Failure errorMessage ->
                printfn "Simulation failed. Reason: %s" errorMessage
                None
                
    let runSqrtSimulations v p =
        McSqrt.runSimulations v p
        |> Array.choose handleSqrtResult
        |> plotRelativeErrors
        printfn "Simulation complete."

    let fail message =
            let fgColor = Console.ForegroundColor
            Console.ForegroundColor <- ConsoleColor.Red
            printfn message
            Console.ForegroundColor <- fgColor
            1 // Exit code

    [<EntryPoint>]
    let main argv =
        match argv.Length with
        | 0
        | 1 ->
            fail $"Missing arguments.\n{McSqrt.inputMessage}" 
        | 2 ->
            try 
                let v = argv.[0] |> float
                let p = argv.[1] |> int
                if v >= 1.0 then
                    runSqrtSimulations v p
                    0
                else
                    fail $"Invalid argument 'v={argv.[0]}'.\n{McSqrt.inputMessage}" 
            with
                | :? FormatException as e ->
                    fail $"{e.Message}\n{McSqrt.inputMessage}" 
        | _ ->
            fail $"Too many arguments.\n{McSqrt.inputMessage}" 
