namespace MCSqrtEstimator

open MathHelpers

module MonteCarlo =

     type SimulationResult =
          {
               inputValue : float
               referenceValue: float
               estimatedValue : float
               samples : int
               relativeError : float
          }

     ///<summary>Calculates the relative error of the estimated value.</summary>
     ///<param name="est">Estimated value.</param>
     ///<param name="est">Reference value.</param>
     ///<returns>Relative error.</returns>
     let relativeError est ref =
          abs (est-ref) / ref

     ///<summary>Writes a summary of the simulation to the console.</summary>
     ///<param name="result">Simulation result.</param>
     ///<returns>Unmodified simulation result.</returns>
     let private print model result = 
          printfn "%s for (%f): ref=%f est=%f e_n=%f for %d samples" model result.inputValue result.referenceValue result.estimatedValue result.relativeError result.samples
          result

     //For more information see the [documentation](./docs/mc_sqrt.pdf)
     module Sqrt =

          [<Literal>]
          let modelName = "sqrt"

          type Location = 
               | Out = 0
               | In = 1

          ///<summary>The indicator function based on the y random variable.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="y_i">The value of the i_th random variable.</param>
          ///<returns>Location of the point considering the rectangle of interest.</returns>
          let private indicator v y_i= 
               if v * square y_i <= 1.0 then
                    Location.In |> int
               else 
                    Location.Out |> int

          ///<summary>Estimates the square root of 'v' using the Monte Carlo method.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="n">Number of samples.</param>
          ///<returns>Estimated value for sqrt(v).</returns>
          let estimate v n =
               // Y -> iid sequence continuous in [0,1]
               let y = createContinuousUniformSamples n 0 1
               // SUM{1_n}[g(Yi)]
               let sumG =
                    y
                    |> Seq.map (indicator v)
                    |> Seq.sum
                    |>  float
               // Mn = 1/n * sumG
               let mn =
                    n
                    |> float
                    |> invert
                    |> Operators.(*) sumG
               // Mn = 1 / sqrt (v)
               mn |> invert

          ///<summary>Runs the Monte Carlo simulation to estimate the square root of 'v'.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="n">Number of samples.</param>
          ///<returns>Simulation result for sqrt(v).</returns>
          let simulate v n =
               let reference = sqrt v
               let estimate = estimate v n
               let error = relativeError estimate reference
               
               {
                    inputValue = v
                    referenceValue = reference
                    estimatedValue = estimate
                    samples = n
                    relativeError = error
               }

          let print result = 
               print modelName result