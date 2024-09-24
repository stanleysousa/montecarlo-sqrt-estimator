namespace MCSqrtEstimator

module Program =

    open System
    open MCSqrtEstimator.Core
    open MCSqrtEstimator.Core.Models
    open MCSqrtEstimator.Presentation.View

    // Model
    let model = McSqrt.getModel

    let runModel = Runner.runSimulations model

    // Simulation results handler
    let successFunc output = writeSummary model.ModelName output

    let failureFunc message = printfn "Simulation failed. Reason: %s" message

    let handleResult = Runner.handleResult successFunc failureFunc

    // Program auxiliary functions
    let execute args =
        runModel args
        |> Array.choose handleResult
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
            execute args
        | Error message ->
            fail message