namespace MCSqrtEstimator

open MathNet.Numerics

module MathHelpers =

  ///<summary>Fills an array with continuous uniform samples.</summary>
  ///<param name="y">array to be filled.</param>
  ///<returns>Array filled with samples generated using Mersenne Twister number generator.</returns>
  let private fillSamples y =
    Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), y, 0.0, 1.0)
    y

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

  ///<summary>Generates samples from a continuous uniform distribution.</summary>
  ///<param name="n">Number of samples.</param>
  ///<returns>Samples generated using Mersenne Twister number generator.</returns>
  let generateSamples n =
      n
      |> Array.zeroCreate
      |> fillSamples


