// Learn more about F# at http://fsharp.org

open System
open Estimators.Sqrt
open XPlot.GoogleCharts

let log v n est ref delta epsilon=
    printfn "sqrt(%f): ref=%f est=%f delta=%f epsilon=%f for %d samples" v ref est delta epsilon n

let plot data=
    let errors: (int * float) list = data

    let options =
        Options
            ( title = "Erro relativo do estimador", curveType = "function",
            width = 600,
            height = 400,
            vAxis = Axis(logScale = true, format="scientific", title="epsilon"),
            hAxis = Axis(logScale = true, format="scientific", title="n") )

    errors
    |> Chart.Line
    |> Chart.WithOptions options
    |> Chart.Show

let calculate v n=
    let est = estimate v n
    let ref = Math.Sqrt(v)
    let delta = Math.Abs(est-ref)
    let epsilon = Math.Abs(est-ref)/ref
    v, n, est, ref, delta, epsilon

[<EntryPoint>]
let main _ =
    //number to calculate the square root
    let value = 2.0

    let mutable errors: (int * float) list = []

    for i in [10..60] do
        //calculate the number on samples, from 10 to 10^6, preparing to plot on a log scale
        let n = Math.Pow(10.0, (float)i/10.0) |> Math.Ceiling |> int
        //estimate and calculate errors
        let v, n, est, ref, delta, epsilon = calculate value n
        //write the result
        log v n est ref delta epsilon
        //add n and epsilon to the error list
        errors <- errors @ [n, epsilon]

    plot errors

    0 // return an integer exit code
