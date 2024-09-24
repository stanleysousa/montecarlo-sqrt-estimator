namespace MCSqrtEstimator

module Program =

    open System
    open MCSqrtEstimator.Core
    open MCSqrtEstimator.Presentation.View

    let model = McSqrt.getModel

    // Results handler functions
    let successFunc output = writeSummary McSqrt.ModelName output

    let failureFunc message = printfn "Simulation failed. Reason: %s" message

    // Program auxiliary functions
    let execute v p =
        Runner.runManySimulations v p model.estimatorFunc model.expectedValueFunc
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
        let inputValidationResult = model.inputValidatorFunc argv
        match inputValidationResult with
        | Ok args ->
            let v = args.[0] |> float
            let p = args.[1] |> int
            execute v p
        | Error message ->
            fail message