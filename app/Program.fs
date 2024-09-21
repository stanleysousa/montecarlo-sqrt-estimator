namespace MCSqrtEstimator

open System
open MCSqrtEstimator.MonteCarlo
open Plot

module Program =

    let plotErrors results = 
        if results |> Seq.length > 0 then
            let v = (results |> Seq.head).runParameters.value
            let title = sprintf "Relative error for v=%f and n samples" v
            let data =
                results
                |> Seq.map (fun o -> o.runParameters.samples, o.relativeError)
            Line.plot title data

    let tryRunSimulations value power =
         try 
              let v = value |> float
              let p = power |> int
              if v >= 1.0 then
                   Sqrt.runSimulations v p
              else
                   printf "%s\n%s" "Invalid argument(s)." Sqrt.inputMessage
                   Array.empty
         with
              | :? FormatException as e ->
                   printf "%s\n%s" e.Message Sqrt.inputMessage
                   Array.empty

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
            tryRunSimulations argv.[0] argv.[1]
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
