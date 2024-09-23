namespace MCSqrtEstimator.Core

module MathUtils =

    open MathNet.Numerics

    ///<summary>Calculates the square of a number.</summary>
    ///<param name="x">Number to be squared.</param>
    ///<returns>n squared.</returns>
    let square x =
        x ** 2.
        
    ///<summary>Inverts a number.</summary>
    ///<param name="x">Number to be inverted.</param>
    ///<returns>x to the power of -1.</returns>
    let invert x =
        // There is a chance for x to be zero when the number of samples is small, particularly when n<10
        if x = 0. then
            Error "Cannot divide by 0"
        else
            Ok (1./x)
    
    ///<summary>Creates samples from a continuous uniform distribution.</summary>
    ///<param name="n">Number of samples.</param>
    ///<param name="lower">Lower value.</param>
    ///<param name="upper">Upper value.</param>
    ///<returns>Samples generated using Mersenne Twister number generator.</returns>
    let createContinuousUniformSamples n lower upper =
          let y = n |> Array.zeroCreate
          Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), y, lower, upper)
          y

    let bind switchFunction twoTrackInput =
        match twoTrackInput with
        | Ok s -> switchFunction s
        | Error e -> Failure e

