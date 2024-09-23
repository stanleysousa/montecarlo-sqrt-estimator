namespace MCSqrtEstimator.Core.Types

type Input =
     {
          EstimatorFunc : float -> int -> Result<float, string>
          Value : float
          Samples : int
          ExpectedValue: float
     }