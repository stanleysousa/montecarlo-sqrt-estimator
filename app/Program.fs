namespace MCSqrtEstimator

open System
open MCSqrtEstimator.MonteCarlo
open Plot

module Program =

    let plotErrors (results : MonteCarlo.SimulationOutput seq) = 
        if results |> Seq.length > 0 then
            let v = results |> Seq.head
            let title = sprintf "Relative error for v=%f and n samples" v.inputValue
            let data =
                results
                |> Seq.map (fun e -> e.samples, e.relativeError)
            Line.plot title data

    [<EntryPoint>]
    let main argv =
        let fgColor = Console.ForegroundColor
        match argv.Length with
        | 0
        | 1 -> 
            Console.ForegroundColor <- ConsoleColor.Red
            printf "Missing arguments.\n%s" Sqrt.inputMessage
            Console.ForegroundColor <- fgColor
            1
        | 2 ->                   
            Sqrt.tryRunSimulations argv.[0] argv.[1]
                |> Array.choose (function
                    | Success output ->
                        MonteCarlo.Sqrt.print output
                        Some output
                    | Failure errorMessage ->
                        printfn "Simulation failed. Reason: %s" errorMessage
                        None)
                |> plotErrors
            printfn "Simulation complete."
            0
        | _ ->
            Console.ForegroundColor <- ConsoleColor.Red
            printfn "Too many arguments.\n%s" Sqrt.inputMessage
            Console.ForegroundColor <- fgColor
            1
