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
    let x1 =[1..1..(pown 10 2)]
    let x2 =[(pown 10 2)..10..(pown 10 3)]
    let x3 =[(pown 10 3)..100..(pown 10 4)]
    let x4 =[(pown 10 4)..1000..(pown 10 5)]
    let x5 =[(pown 10 5)..10000..(pown 10 6)]
    let x = x1 @ x2 @ x3@ x4@ x5

    //Estimates and generate plot data
    let data = List.init (x |>Seq.length) (fun i -> estimate v (x.[i]))

    //plot result
    let title = "Erro relativo do estimador"
    Line.plot data title

    0 // return an integer exit code
