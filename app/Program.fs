﻿namespace MCSqrtEstimator

module Program =

    open System
    open MCSqrtEstimator.Core
    open MCSqrtEstimator.Presentation.View

    // Model parameters
    let inputErrorMessage = McSqrt.InputMessage

    let estimatorFunc = McSqrt.tryEstimate

    let expectedValueFunc = McSqrt.expectedValueFunc

    // Results handler functions
    let successFunc output = writeSummary McSqrt.ModelName output

    let failureFunc message = printfn "Simulation failed. Reason: %s" message

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
            fail $"Missing arguments.\n{inputErrorMessage}" 
        | 2 ->
            try 
                let v = argv.[0] |> float
                let p = argv.[1] |> int
                if v >= 1.0 then
                    execute v p
                else
                    fail $"Invalid argument 'v={argv.[0]}'.\n{inputErrorMessage}" 
            with
                | :? FormatException as e ->
                    fail $"{e.Message}\n{inputErrorMessage}" 
        | _ ->
            fail $"Too many arguments.\n{inputErrorMessage}" 
