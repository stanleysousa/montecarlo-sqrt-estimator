namespace MCSqrtEstimator

module Program =

    open System
    open MCSqrtEstimator.Core.MonteCarlo.Models
    open MCSqrtEstimator.Core.Simulation
    open MCSqrtEstimator.Presentation.View

    // Model parameters
    let inputValidationMessage = McSqrt.InputMessage

    let estimatorFunc = McSqrt.estimate

    let expectedValueFunc = McSqrt.expectedValueFunc

    // Results handler functions
    let successFunc output = writeSummary McSqrt.ModelName output

    let failureFunc errorMessage = printfn "Simulation failed. Reason: %s" errorMessage

    // Program auxiliary functions
    let execute v p =
        Runner.runManySimulations v p estimatorFunc expectedValueFunc
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

    // Program EntyPoint
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
