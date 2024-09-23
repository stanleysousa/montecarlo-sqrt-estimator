namespace MCSqrtEstimator.Core

//For more information see the [documentation](./docs/mc_sqrt.pdf)
module McSqrt =

     open MCSqrtEstimator.Core.MathUtils
     open MCSqrtEstimator.Core.Types

     [<Literal>]
     let ModelName =  "sqrt"

     [<Literal>]
     let InputMessage =  "Please provide 'v>=1.0 :float' and 'p :int' \n  v = a value for the square root to be estimated \n  p = the order of magnitude for the max number of samples"

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
     ///<returns>Estimated value for sqrt(v).</returns>
     let estimate v n =
          if n = 0 then
               let message = "The number of samples must not be 0."
               EstimateFailure message
          else
               // Y -> iid sequence continuous in [0,1]
               let y = createContinuousUniformSamples n 0 1
               // 1/n
               let oneOverN =
                    n
                    |> float
                    |> invert
                    |> Option.defaultValue 0. // Only to satisfy the compiler, should never default since 'n' is validated above
               // SUM{1_n}[g(Yi)]
               let sumG =
                    y
                    |> Seq.map (indicator v)
                    |> Seq.sum
                    |>  float
               // Mn = 1/n * sumG
               let mn = oneOverN * sumG
               // sqrt(v) = 1 / Mn
               let sqrtv = mn |> invert
               match sqrtv with
               | Some value ->
                    EstimateSuccess value
               | None ->
                    EstimateFailure "The estimator failed to generate non-zero values for the indicator function"

     ///<summary>Calculates the expected value for square root of 'v'.</summary>
     let expectedValueFunc = sqrt