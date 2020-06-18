namespace Estimators

module Sqrt =
     open MathNet.Numerics;

     ///<summary>The indicator function based on the y random variable.</summary>
     ///<param name="y">The value of the random variable.</param>
     ///<param name="v">The value for which the square root will be estimated.</param>
     ///<returns>True if y is inside the rectangle.</returns>
     let indicator y value=
          value*y**2.0<=1.0

     ///<summary>Estimates the square root of a given value using the Monte Carlo method and a uniform distribution.</summary>
     ///<param name="v">The value for which the square root will be estimated.</param>
     ///<param name="n">number of samples.</param>
     ///<returns>Expected value for sqrt(v).</returns>
     let estimate v n =
          //Generate uniform samples with MersenneTwister
          let Y : double array = Array.zeroCreate n
          Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), Y, 0.0, 1.0)    
          
          //Filter the samples outside of the rectangle and count
          let sumG = Y |> Seq.filter(fun y -> indicator y v) |> Seq.length |> float
          
          //Calculate the estimated value    
          let Mn = (1.0/(float)n) * sumG
          1.0/Mn