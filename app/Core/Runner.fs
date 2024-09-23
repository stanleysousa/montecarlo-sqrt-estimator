namespace MCSqrtEstimator.Core

module Runner =

     open MCSqrtEstimator.Core.Types

     ///<summary>Calculates the relative error of the estimated value.</summary>
     ///<param name="est">Estimated value.</param>
     ///<param name="est">Reference value.</param>
     ///<returns>Relative error.</returns>
     let private calculateRelativeError est ref =
          if ref = 0. then
               abs (est-ref)
          else
               abs (est-ref) / ref

     ///<summary>Runs the Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="input">Simulation input containing the estimation function, value and number of samples.</param>
     ///<returns>Simulation output.</returns>
     let private run input =
          let estimate = input.EstimatorFunc input.Value input.Samples
          match estimate with
          | Ok estimate ->
               let error = calculateRelativeError estimate input.ExpectedValue
               let result =
                    {
                         RunParameters = input
                         EstimatedValue = estimate
                         RelativeError = error
                    }
               Ok result
          | Error reason ->
               Error reason

     ///<summary>Runs Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="v">The value for which estimation will be calculated.</param>
     ///<param name="n">Number of samples.</param>
     ///<param name="estimatorFunc">Function that implements the model to be simulated.</param>
     ///<param name="expectedValueFunc">Function which calculates the expected value for the model.</param>
     ///<returns>Simulations outputs.</returns>
     let runSingleSimulation v n estimatorFunc expectedValueFunc =
          let expectedValue = expectedValueFunc v
          let input =
               {
                    EstimatorFunc = estimatorFunc
                    Value = v
                    Samples = n
                    ExpectedValue = expectedValue
               }
          run input

     ///<summary>Runs several parallel Monte Carlo simulations, with different number of samples, for a given model implementation.</summary>
     ///<param name="v">The value for which estimation will be calculated.</param>
     ///<param name="p">Order of magnitude for the maximum number of samples.</param>
     ///<param name="estimatorFunc">Function that implements the model to be simulated.</param>
     ///<param name="expectedValueFunc">Function which calculates the expected value for the model.</param>
     ///<returns>Simulations outputs.</returns>
     let runManySimulations v p estimatorFunc expectedValueFunc =
          [|
               for i in 1..p -> pown 10 i
          |]
          |> Array.Parallel.map (fun n ->
               runSingleSimulation v n estimatorFunc expectedValueFunc)

     ///<summary>Handles the simulation result.</summary>
     ///<param name="successFunc">Function to be executed for successfull simulations.</param>
     ///<param name="failureFunc">Function to be executed for failed simulations.</param>
     ///<returns>Some output if the simulation was successful, None otherwise.</returns>
     let handleResult successFunc failureFunc =
          function
               | Ok output ->
                    successFunc output
                    Some output
               | Error message ->
                    failureFunc message
                    None