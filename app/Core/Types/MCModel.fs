namespace MCSqrtEstimator.Core.Types

type MCModel =
     {
          ModelName : string
          InputValidatorFunc : array<string> -> Result<array<string>, string>
          EstimatorFunc : float -> int -> Result<float, string>
          ExpectedValueFunc : float -> float
     }