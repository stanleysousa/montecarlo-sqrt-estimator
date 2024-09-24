namespace MCSqrtEstimator.Core

module Runner =

     open System
     open MCSqrtEstimator.Core.Types
     open MCSqrtEstimator.Core.Utils.Math

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
     ///<param name="ref">Reference value.</param>
     ///<returns>Relative error.</returns>
     let private calculateRelativeError est ref =
          if ref = 0. then
               abs (est-ref)
          else
               abs (est-ref) / ref

     ///<summary>Runs Monte Carlo simulation for a given model implementation.</summary>
     /// ///<param name="model">The model implementation.</param>
     ///<param name="value">The value for which the model will be applied.</param>
     ///<param name="samples">Number of samples.</param>
     ///<returns>Simulation result.</returns>
     let private runModel (model : MCModel) (value : float) (samples : int) =
          let expectedValue = model.ExpectedValueFunc value
          let estimate = model.EstimatorFunc value samples
          match estimate with
          | Ok estimate ->
               let relativeError = calculateRelativeError estimate expectedValue
               let result =
                    {
                         Value = value
                         Samples = samples
                         ExpectedValue = expectedValue
                         EstimatedValue = estimate
                         RelativeError = relativeError
                    }
               Ok result
          | Error reason ->
               Error reason

     ///<summary>Validate inputs array</summary>
     let validateInputs = 
             validateFewArgs
             >> bind validateManyArgs
             >> bind validateArgsConstraints

     ///<summary>Runs several parallel Monte Carlo simulations, with different number of samples, for a given model implementation.</summary>
     ///<param name="model">The model implementation.</param>
     ///<param name="args">Input args.</param>
     ///<returns>Simulations outputs.</returns>
     let runSimulations (model : MCModel) (args : string array)  =
          let value = args.[0] |> float
          let power = args.[1] |> int
          [|
               for i in 1..power -> pown 10 i
          |]
          // Could just do |> Array.Parallel.map (fun n ->runSingleSimulation v n estimatorFunc expectedValueFunc)
          // Exploring async computation istead
          |> Array.map (fun samples ->
               async {
                    return runModel model value samples
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