namespace MCSqrtEstimator

open System
open MathHelpers

type MonteCarlo =
     {
          baseValue : float
          referenceValue: float
          samples : int
          estimate : float
          error : float
     }

module MonteCarlo =

     ///<summary>Writes a summary of the simulation to the console.</summary>
     ///<param name="mc">Simulation result.</param>
     let print mc = 
          printfn "sqrt(%f): ref=%f est=%f e_n=%f for %d samples" mc.baseValue mc.referenceValue mc.estimate mc.error mc.samples

     //For more information see the [documentation](./docs/mc_sqrt.pdf)
     module Sqrt =

          ///<summary>The indicator function based on the y random variable.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="y_i">The value of the i_th random variable.</param>
          ///<returns>True if y is inside the rectangle.</returns>
          let private indicator v y_i= 
               let g_xi_yi =
                    v * square y_i
               if g_xi_yi <= 1.0 then
                    1.0
               else 
                    0.0

          ///<summary>Estimates the square root of 'v' using the Monte Carlo method.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="n">Number of samples.</param>
          ///<returns>Expected value for sqrt(v).</returns>
          let estimate v n =
               // Y -> iid sequence continuous in [0,1]
               let y = generateSamples n

               // SUM_1_n[g(Yi)]
               let sumG =
                    y
                    |> Seq.map(fun y_i -> indicator v y_i)
                    |> Seq.sum

               // E[g(Yi)] = 1 / sqrt (v)
               let m =
                    n
                    |> float
                    |> invert
                    |> (fun a -> a*sumG)

               // Returns the estimated value for sqrt(v)
               m |> invert

          ///<summary>Runs the Monte Carlo simulation to estimate the square root of 'v'.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="n">Number of samples.</param>
          ///<returns>Simulation result for sqrt(v).</returns>
          let simulate v n =
               let estimate = estimate v n
               let reference = Math.Sqrt(v)
               let e_n = Math.Abs(estimate-reference)/reference
               {
                    baseValue = v
                    referenceValue = reference
                    samples = n
                    estimate = estimate
                    error = e_n
               }