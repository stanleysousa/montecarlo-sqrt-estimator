open System
open MCSqrtEstimator
open Plot

[<Literal>]
let defaultMessage = 
    "Please provide 'v:float  >= 1' (a value for the square root to be estimated) and 'p:int' (the order of magnitude for the max number of samples)."

let plotErrors (results : MonteCarlo.SimulationResult seq) = 
    let v = results |> Seq.head
    let title = sprintf "Relative error for v=%f and n samples" v.inputValue
    let data =
        results
        |> Seq.map (fun e -> e.samples, e.relativeError)
    Line.plot title data

let trySimulate value power =
    try 
        let v = value |> float
        let p = power |> int
        if v >= 1.0 then
            [|
                for i in 0..p -> pown 10 i
            |]
            |> Array.map (fun n -> MonteCarlo.Sqrt.simulate v n)
            |> Array.map (fun s -> MonteCarlo.Sqrt.print s)
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
        if trySimulate argv.[0] argv.[1] then
            printfn "Simulation complete."
            0
        else
            printfn "Invalid arguments. %s" defaultMessage
            1
    | _ -> printf "Too many arguments. %s" defaultMessage
           1
