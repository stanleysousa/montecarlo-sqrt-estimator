//namespace MCSqrtEstimator

open System
open MCSqrtEstimator
open Plot

let plotErrors mc = 
    let errors =
        mc
        |> List.map (fun e -> e.samples, e.error)

    let v = mc.Head.baseValue

    let title = sprintf "Relative error for v=%f and n samples" v
    Line.plot errors title

let simulate value = 
    // Controls the number of samples
    let steps = 6

    // Create a list with an increasing number of samples
    let numbersOfSamples =
        List.init   steps (fun i -> [0..(pown 10 (i))..(pown 10 (i+1))])
        |> List.collect (fun l -> (l |> List.skip 2))

    // Estimates using the number of samples
    List.init (numbersOfSamples |>Seq.length) (fun i -> MonteCarlo.Sqrt.simulate value (numbersOfSamples.[i]))


let trySimulate  (value : string) =
    try 
        let number =
            value
            |> float

        if number >= 1.0 then
            let estimates =
                simulate number
                
            // Print results
            estimates
            |> List.iter (fun e -> MonteCarlo.print e)

            // Plot errors chart
            plotErrors estimates
            true
        else
            false
    with
        | :? FormatException ->
            false

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 0 -> printf "Missing argument. Please provide a number."
           1
    | 1 -> if trySimulate argv.[0] then
                printfn "Simulation complete."
                0
           else
                printfn "Invalid argument, please provide a number greater or equal to 1."
                1
    | _ -> printf "Too many arguments. Please provide a single number."
           1
