namespace MCSqrtEstimator.Core.Models

//For more information see the [documentation](./docs/mc_sqrt.pdf)
module McSqrt =

     open MCSqrtEstimator.Core.Types
     open MCSqrtEstimator.Core.Utils.Logging
     open MCSqrtEstimator.Core.Utils.Math

     [<Literal>]
     let private name =  "sqrt"

     // Active pattern for the indicator function for learning reasons
     // Could be an Enum
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
     ///<param name="oneOverN">Sanitized value for 1/n.</param>
     ///<returns>Estimated value for sqrt(v).</returns>
     let private estimate v n oneOverN =
          let trace = new LoggingBuilder()
          trace {
               // Y -> iid sequence continuous in [0,1]
               let y = createContinuousUniformSamples n 0 1
               
               // SUM{1_n}[g(Yi)]
               let! sumG = // Tracing sumG to facilitate debugging in case of failure when computing the estimated value
                    y
                    |> Seq.map (indicator v)
                    |> Seq.sum
                    |>  float
               
               // Mn = 1/n * sumG
               let mn = oneOverN * sumG
               
               // sqrt(v) = 1 / Mn
               let sqrtv = mn |> invert
               return 
                    match sqrtv with
                    | Ok sqrtv ->
                         Ok sqrtv
                    | Error message ->
                         Error "The estimator failed to generate non-zero values for the indicator function"
          }
 
     ///<summary>Calculates the expected value for square root of 'v'.</summary>
     let expectedValue = sqrt

     ///<summary>Estimates the square root of 'v' using the Monte Carlo method.</summary>
     ///<param name="v">The value for which the square root will be estimated.</param>
     ///<param name="n">Number of samples.</param>
     ///<param name="oneOverN">Sanitized value for 1/n.</param>
     ///<returns>Estimated value for sqrt(v).</returns>
     let tryEstimate v n =
          if n = 0 then
               Error("The number of samples must not be 0.")
          else
               // 1/n
               let oneOverN =
                    n
                    |> float
                    |> invert
               match oneOverN with
               | Ok oneOverN ->
                    estimate v n oneOverN
               | Error message ->
                    Error message

     let getModel =
          {
               ModelName = name
               EstimatorFunc = tryEstimate
               ExpectedValueFunc = expectedValue
          }
