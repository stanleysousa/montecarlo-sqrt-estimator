namespace MCSqrtEstimator.Core.Simulation.Types

open MCSqrtEstimator.Core.MonteCarlo.Types

type Input =
     {
          EstimatorFunc : float -> int -> Estimate<float, string>
          Value : float
          Samples : int
          ExpectedValue: float
     }