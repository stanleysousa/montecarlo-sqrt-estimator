// Learn more about F# at http://fsharp.org

open System
open Estimators.Sqrt

[<EntryPoint>]
let main _ =
    //number to calculate the square root
    let value = 2.0
    let reference = Math.Sqrt(value)

    //number of samples for each estimation
    let n1, n2, n3, n4 = 1000*1, 1000*10, 1000*100, 1000*1000

    //Estimates the values and print the results
    let est1, est2, est3, est4 = estimate value n1, estimate value n2, estimate value n3, estimate value n4
    printfn "The reference value for sqrt(%f) is: %f" value reference
    printfn "The estimated value for sqrt(%f) using Monte Carlo is:" value
    printfn "  %f e=%f from %i samples" est1 (Math.Abs(est1-reference)) n1
    printfn "  %f e=%f from %i samples" est2 (Math.Abs(est2-reference)) n2
    printfn "  %f e=%f from %i samples" est3 (Math.Abs(est3-reference)) n3
    printfn "  %f e=%f from %i samples" est4 (Math.Abs(est4-reference)) n4
    0 // return an integer exit code
