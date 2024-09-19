open System
open MCSqrtEstimator
open Plot

[<Literal>]
let defaultMessage = 
    "Please provide 'v:float  >= 1' (a value for the square root to be estimated) and 'p:int' (the order of magnitude for the max number of samples)."

let plotErrors s = 
    let errors =
        s
        |> List.map (fun e -> e.samples, e.error)
    let v = s.Head.baseValue
    let title = sprintf "Relative error for v=%f and n samples" v
    Line.plot errors title

let trySimulate value power =
    try 
        let v = value |> float
        let p = power |> int

        if v >= 1.0 then
            List.init p (fun i -> [0..(pown 10 (i))..(pown 10 (i+1))]) // Create lists with an increasing number of samples
            |> List.collect (fun l -> (l |> List.skip 2)) // Flattens the list skipping the first two items
            |> List.map (fun n -> MonteCarlo.Sqrt.simulate v n) // Runs the simulations
            |> List.map (fun s -> MonteCarlo.print s) // Print results
            |> plotErrors

            true
        else
            false
    with
        | :? FormatException ->
            false

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 0
    | 1 -> 
        printf "Missing arguments. %s" defaultMessage
        1
    | 2 ->
        // Controls the number of samples
        let power = 6
        if trySimulate argv.[0] argv.[1] then
            printfn "Simulation complete."
            0
        else
            printfn "Invalid arguments. %s" defaultMessage
            1
    | _ -> printf "Too many arguments. %s" defaultMessage
           1
