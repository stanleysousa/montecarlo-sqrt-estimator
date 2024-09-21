namespace MCSqrtEstimator.MonteCarlo

module Simulation =

     type Input =
          {
               estimationFunc : float -> int -> float
               value : float
               samples : int
               expectedValue: float
          }

     type Output =
          {
               runParameters : Input
               estimatedValue : float
               relativeError : float
          }

     type Result<'TSuccess,'TFailure> =
     | Success of Output
     | Failure of string

     ///<summary>Calculates the relative error of the estimated value.</summary>
     ///<param name="est">Estimated value.</param>
     ///<param name="est">Reference value.</param>
     ///<returns>Relative error.</returns>
     let calculateRelativeError est ref =
          abs (est-ref) / ref

     ///<summary>Runs the Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="input">Simulation input containing the estimation function, value and number of samples.</param>
     ///<returns>Simulation output.</returns>
     let tryRunSimulation input =
          try 
               let reference = sqrt input.value
               let estimate = input.estimationFunc input.value input.samples
               let error = calculateRelativeError estimate reference
               let result =
                    {
                         runParameters = input
                         estimatedValue = estimate
                         relativeError = error
                    }
               Success result
          with
               | _ as e->
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