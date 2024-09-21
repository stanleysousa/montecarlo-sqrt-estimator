namespace MMCSqrtEstimator.MonteCarlo

//For more information see the [documentation](./docs/mc_sqrt.pdf)
module McSqrt =

     open MCSqrtEstimator.MonteCarlo.MathHelpers
     open MCSqrtEstimator.MonteCarlo.Simulation

     [<Literal>]
     let modelName = "sqrt"

     [<Literal>]
     let inputMessage =  "Please provide 'v>=1.0 :float' and 'p :int' \n  v = a value for the square root to be estimated \n  p = the order of magnitude for the max number of samples"
  
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
     let runSimulations v p =
          runManySimulations estimate v p
     let print output = 
          print modelName output