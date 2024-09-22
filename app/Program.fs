namespace MCSqrtEstimator

module Program =

    open System
    open Presentation.View
    open MCSqrtEstimator.MonteCarlo

    let inputValidationMessage = Models.McSqrt.inputMessage

    let successFunc output = writeSummary "sqrt" output

    let failureFunc errorMessage = printfn "Simulation failed. Reason: %s" errorMessage
               
    let execute v p =
        let simulation = MonteCarlo.Simulation(Models.McSqrt.estimate, v)
        simulation.RunMany p
        |> Array.choose (Runner.handleResult successFunc failureFunc)
        |> plotRelativeErrors
        printfn "Simulation complete."
        0 // Exit code

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
            fail $"Missing arguments.\n{inputValidationMessage}" 
        | 2 ->
            try 
                let v = argv.[0] |> float
                let p = argv.[1] |> int
                if v >= 1.0 then
                    execute v p
                else
                    fail $"Invalid argument 'v={argv.[0]}'.\n{inputValidationMessage}" 
            with
                | :? FormatException as e ->
                    fail $"{e.Message}\n{inputValidationMessage}" 
        | _ ->
            fail $"Too many arguments.\n{inputValidationMessage}" 
