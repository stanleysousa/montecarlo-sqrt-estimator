namespace MCSqrtEstimator

module Program =

    open System
    open MCSqrtEstimator.Core
    open MCSqrtEstimator.Presentation.View

    let model = McSqrt.getModel

    // Results handler functions
    let successFunc output = writeSummary model.ModelName output

    let failureFunc message = printfn "Simulation failed. Reason: %s" message

    // Program auxiliary functions
    let execute model args =
        Runner.runManySimulations model args
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
        let inputValidationResult = Runner.validateInputs argv
        match inputValidationResult with
        | Ok args ->
            execute model args
        | Error message ->
            fail message