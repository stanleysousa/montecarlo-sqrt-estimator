namespace Estimators

module Sqrt =
     open MathNet.Numerics;

     ///<summary>The indicator function based on the y random variable.</summary>
     ///<param name="y">The value of the random variable.</param>
     ///<param name="v">The value for which the square root will be estimated.</param>
     ///<returns>True if y is inside the rectangle.</returns>
     let indicator y v=
          if v*y**2.0<=1.0 then 1.0 else 0.0

     ///<summary>Estimates the square root of v the Monte Carlo method.</summary>
     ///<param name="v">The value for which the square root will be estimated.</param>
     ///<param name="n">Number of samples.</param>
     ///<returns>Expected value for sqrt(v).</returns>
     let estimate v n =
          //Generate uniform samples with MersenneTwister
          let Y : double array = Array.zeroCreate n
          Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), Y, 0.0, 1.0)

          //Map Y values to the indicator function and calculates the sum
          let sumG = Y |> Seq.map(fun Yi -> indicator Yi v) |> Seq.sum

          //Calculate the estimated value for sqrt(v) and returns
          (float)n/sumG