namespace MCSqrtEstimator.Core.Types

type MCModel =
     {
          ModelName : string
          EstimatorFunc : float -> int -> Result<float, string>
          ExpectedValueFunc : float -> float
     }