namespace MCSqrtEstimator

module Program =

    open System
    open MCSqrtEstimator.Core
    open MCSqrtEstimator.Core.MathUtils
    open MCSqrtEstimator.Presentation.View

    // Model parameters
    let inputErrorMessage = McSqrt.InputMessage

    let estimatorFunc = McSqrt.tryEstimate

    let expectedValueFunc = McSqrt.expectedValueFunc

    // Results handler functions
    let successFunc output = writeSummary McSqrt.ModelName output

    let failureFunc message = printfn "Simulation failed. Reason: %s" message

    // Input validation functions
    let validateFewArgs (args : string array) = 
        if args.Length < 2 then Error $"Missing arguments.\n{inputErrorMessage}"
        else Ok args

    let validateManyArgs (args : string array) = 
        if args.Length > 2 then Error $"Too many arguments.\n{inputErrorMessage}"
        else Ok args

    let validateArgsConstraints (args : string array) = 
        try 
            let v = args.[0] |> float
            do args.[1] |> int |> ignore
            if v >= 1.0 then
                Ok args
            else
                Error $"Invalid argument 'v={args.[0]}'.\n{inputErrorMessage}" 
        with
            | :? FormatException as e ->
                Error $"{e.Message}\n{inputErrorMessage}"

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
        printfn "%s" message
        Console.ForegroundColor <- fgColor
        1 // Exit code

    // Program EntyPoint
    [<EntryPoint>]
    let main argv =
        let validateInput = 
                validateFewArgs
                >> bind validateManyArgs
                >> bind validateArgsConstraints
                
        let inputValidationResult = validateInput argv
        
        match inputValidationResult with
        | Ok args ->
            let v = args.[0] |> float
            let p = args.[1] |> int
            execute v p
        | Error message ->
            fail message