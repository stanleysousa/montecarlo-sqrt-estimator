namespace MCSqrtEstimator.Core

module Runner =

     open System
     open MCSqrtEstimator.Core.Types
     open MCSqrtEstimator.Core.MathUtils

     [<Literal>]
     let private InputMessage =  "Please provide 'v>=1.0 :float' and 'p :int' \n  v = a value for the square root to be estimated \n  p = the order of magnitude for the max number of samples"

     // Input validation functions
     let private validateFewArgs (args : string array) = 
          if args.Length < 2 then Error $"Missing arguments.\n{InputMessage}"
          else Ok args

     let private validateManyArgs (args : string array) = 
          if args.Length > 2 then Error $"Too many arguments.\n{InputMessage}"
          else Ok args

     let private validateArgsConstraints (args : string array) = 
          try 
               let v = args.[0] |> float
               do args.[1] |> int |> ignore
               if v >= 1.0 then
                    Ok args
               else
                    Error $"Invalid argument 'v={args.[0]}'.\n{InputMessage}" 
          with
               | :? FormatException as e ->
                    Error $"{e.Message}\n{InputMessage}"

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
     let private runEstimate input =
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

     ///<summary>Validate inputs array according to model constraints</summary>
     let validateInputs = 
             validateFewArgs
             >> bind validateManyArgs
             >> bind validateArgsConstraints

     ///<summary>Runs Monte Carlo simulation for a given model implementation.</summary>
     ///<param name="v">The value for which estimation will be calculated.</param>
     ///<param name="n">Number of samples.</param>
     ///<param name="estimatorFunc">Function that implements the model to be simulated.</param>
     ///<param name="expectedValueFunc">Function which calculates the expected value for the model.</param>
     ///<returns>Simulations outputs.</returns>
     let private runSingleSimulation v n estimatorFunc expectedValueFunc =
          let expectedValue = expectedValueFunc v
          let input =
               {
                    EstimatorFunc = estimatorFunc
                    Value = v
                    Samples = n
                    ExpectedValue = expectedValue
               }
          runEstimate input

     ///<summary>Runs several parallel Monte Carlo simulations, with different number of samples, for a given model implementation.</summary>
     ///<param name="model">The model implementation.</param>
     ///<param name="args">Input args.</param>
     ///<returns>Simulations outputs.</returns>
     let runManySimulations (model : MCModel) (args : string array)  =
          let v = args.[0] |> float
          let p = args.[1] |> int
          [|
               for i in 1..p -> pown 10 i
          |]
          // Could just do |> Array.Parallel.map (fun n ->runSingleSimulation v n estimatorFunc expectedValueFunc)
          // Exploring async computation istead
          |> Array.map (fun n ->
               async {
                    return runSingleSimulation v n model.EstimatorFunc model.ExpectedValueFunc
               })
          |> Async.Parallel
          |> Async.RunSynchronously

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