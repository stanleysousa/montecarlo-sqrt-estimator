namespace MCSqrtEstimator

open System
open MathHelpers

module MonteCarlo =

     type SimulationInput =
          {
               estimationFunc : float -> int -> float
               value : float
               samples : int
               expectedValue: float
          }

     type SimulationOutput =
          {
               runParameters : SimulationInput
               estimatedValue : float
               relativeError : float
          }

     type SimulationResult<'TSuccess,'TFailure> =
     | Success of SimulationOutput
     | Failure of string

     ///<summary>Calculates the relative error of the estimated value.</summary>
     ///<param name="est">Estimated value.</param>
     ///<param name="est">Reference value.</param>
     ///<returns>Relative error.</returns>
     let relativeError est ref =
          abs (est-ref) / ref

     ///<summary>Runs the Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="input">Simulation input containing the estimation function, value and number of samples.</param>
     ///<returns>Simulation output.</returns>
     let tryRunSimulation input =
          try 
               let reference = sqrt input.value
               let estimate = input.estimationFunc input.value input.samples
               let error = relativeError estimate reference
               let result =
                    {
                         runParameters = input
                         estimatedValue = estimate
                         relativeError = error
                    }
               Success result
          with
               | :? ArgumentException as e->
                    let message = sprintf "%s\n%s" e.Message e.StackTrace
                    Failure message

     ///<summary>Runs several Monte Carlo simulations, with different number of samples, for a given model implementation.</summary>
     ///<param name="estimationFunc">Function that implements the model to be simulated.</param>
     ///<param name="v">The value for which estimation will be calculated.</param>
     ///<param name="p">Order of magniture for the maximum number of samples.</param>
     ///<returns>Simulations outputs.</returns>
     let runManySimulations estimationFunc v p =
          [|
               for i in 1..p -> pown 10 i
          |]
          |> Array.Parallel.map (fun n -> 
               let input =
                    {
                         estimationFunc = estimationFunc
                         value = v
                         samples = n
                         expectedValue = sqrt v
                    }
               tryRunSimulation input)     

     ///<summary>Writes a summary of the simulation output to the console.</summary>
     ///<param name="output">Simulation output.</param>
     let print model output = 
          printfn "%s for (%f): expected=%f estimated=%f e_n=%f for %d samples" model output.runParameters.value output.runParameters.expectedValue output.estimatedValue output.relativeError output.runParameters.samples

     //For more information see the [documentation](./docs/mc_sqrt.pdf)
     module Sqrt =

          [<Literal>]
          let modelName = "sqrt"

          [<Literal>]
          let inputMessage =  "Please provide 'v:float  >= 1.0' (a value for the square root to be estimated) and 'p:int' (the order of magnitude for the max number of samples)."

          // Active pattern for the indicator function
          let private (|In|Out|) (v, y_i) =
               if v * square y_i <= 1.0 then
                    In 
               else
                    Out

          ///<summary>The indicator function based on the y random variable.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="y_i">The value of the i_th random variable.</param>
          ///<returns>Location of the point considering the rectangle of interest.</returns>          
          let private indicator v y_i =
               match v, y_i with
                    | In -> 1
                    | Out -> 0

          ///<summary>Estimates the square root of 'v' using the Monte Carlo method.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="n">Number of samples.</param>
          ///<returns>Estimated value for sqrt(v).</returns>
          let private estimate v n =
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
                         
          ///<summary>Runs several Monte Carlo simulations, with different number of samples, to estimate the square root of 'v'.</summary>
          ///<param name="v">The value for which the square root will be estimated.</param>
          ///<param name="p">Order of magniture for the maximum number of samples.</param>
          ///<returns>Simulation results for sqrt(v).</returns>
          let tryRunSimulations (value : string) (power : string) =
               try 
                    let v = value |> float
                    let p = power |> int
                    if v >= 1.0 then
                         runManySimulations estimate v p
                    else
                         [| Failure inputMessage |]
               with
                    | :? FormatException as e ->
                         let message = sprintf "%s\n%s" e.Message inputMessage
                         [| Failure message |]
                         
          let print output = 
               print modelName output