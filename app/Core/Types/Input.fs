namespace MCSqrtEstimator.Core.Types

type Input =
     {
          EstimatorFunc : float -> int -> Estimate<float, string>
          Value : float
          Samples : int
          ExpectedValue: float
     }