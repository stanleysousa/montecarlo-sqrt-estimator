// Learn more about F# at http://fsharp.org

open System
open Estimators.Sqrt

let write v n est ref d e=
    printfn "sqrt(%f): ref=%f est=%f delta=%f epsilon=%f for %d samples" v ref est d e n

let calculate v n=
    let est = estimate v n
    let ref = Math.Sqrt(v)
    let delta = Math.Abs(est-ref)
    let epsilon = Math.Abs(est-ref)/est
    write v n est ref delta epsilon
    est, epsilon

[<EntryPoint>]
let main _ =
    //number to calculate the square root
    let value = 2.0

    //Estimates the values and print the results
    for i in [1..6] do
        let n = 10 * pown 10 i
        calculate value n |> ignore

    0 // return an integer exit code
