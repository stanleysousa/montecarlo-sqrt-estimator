namespace MCSqrtEstimator

open MathNet.Numerics

module MathHelpers =

  ///<summary>Calculates the square of a number.</summary>
  ///<param name="x">Number to be squared.</param>
  ///<returns>n squared.</returns>
  let square x =
      x ** 2.

  ///<summary>Inverts a number.</summary>
  ///<param name="x">Number to be inverted.</param>
  ///<returns>x to the power of -1.</returns>
  let invert x =
      1./x

  ///<summary>Creates samples from a continuous uniform distribution.</summary>
  ///<param name="n">Number of samples.</param>
  ///<param name="lower">Lower value.</param>
  ///<param name="upper">Upper value.</param>
  ///<returns>Samples generated using Mersenne Twister number generator.</returns>
  let createContinuousUniformSamples n lower upper =
        let y = n |> Array.zeroCreate
        Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), y, lower, upper)
        y


