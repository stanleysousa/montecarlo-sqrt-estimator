namespace MCSqrtEstimator.MonteCarlo

module Runner =

     type Input =
          {
               EstimatorFunc : float -> int -> float
               Value : float
               Samples : int
               ExpectedValue: float
          }

     type Output =
          {
               RunParameters : Input
               EstimatedValue : float
               RelativeError : float
          }

     type Result<'TSuccess,'TFailure> =
     | Success of Output
     | Failure of string

     ///<summary>Calculates the relative error of the estimated value.</summary>
     ///<param name="est">Estimated value.</param>
     ///<param name="est">Reference value.</param>
     ///<returns>Relative error.</returns>
     let private calculateRelativeError est ref =
          abs (est-ref) / ref

     ///<summary>Runs the Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="input">Simulation input containing the estimation function, value and number of samples.</param>
     ///<returns>Simulation output.</returns>
     let private tryRunSimulation input =
          try 
               let estimate = input.EstimatorFunc input.Value input.Samples
               let error = calculateRelativeError estimate input.ExpectedValue
               let result =
                    {
                         RunParameters = input
                         EstimatedValue = estimate
                         RelativeError = error
                    }
               Success result
          with
               | _ as e->
                    let message = sprintf "%s\n%s" e.Message e.StackTrace
                    Failure message

     ///<summary>Runs Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="v">The value for which estimation will be calculated.</param>
     ///<param name="n">Number of samples.</param>
     ///<param name="estimationFunc">Function that implements the model to be simulated.</param>
     ///<param name="expectedValueFunc">Function which calculates the expected value for the model.</param>
     ///<returns>Simulations outputs.</returns>
     let runSingleSimulation v n estimationFunc expectedValueFunc =
          let expectedValue = expectedValueFunc v
          let input =
               {
                    EstimatorFunc = estimationFunc
                    Value = v
                    Samples = n
                    ExpectedValue = expectedValue
               }
          tryRunSimulation input

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
               | Success output ->
                    successFunc output
                    Some output
               | Failure errorMessage ->
                    failureFunc errorMessage
                    None