// Learn more about F# at http://fsharp.org

open System
open Estimators
open Plot

let estimate v n =
    let estimated = Sqrt.estimate v n
    let reference = Math.Sqrt(v)
    let e_n = Math.Abs(estimated-reference)/reference
    printfn "sqrt(%f): ref=%f est=%f e_n=%f for %d samples" v reference estimated e_n n
    n, e_n

[<EntryPoint>]
let main _ =
    //number to calculate the square root
    let v = 2.0

    //sampling parameters
    let maxSamples = (int)(pown 10 6)
    let skip = 100
    let iterations = (maxSamples/skip)

    //Estimates and generate plot data
    let data = List.init iterations (fun i -> estimate v (i*skip))

    //plot result
    let title = "Erro relativo do estimador"
    Line.plot data title

    0 // return an integer exit code
