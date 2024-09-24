namespace MCSqrtEstimator.Core.Types

type MCModel =
     {
          inputValidatorFunc : array<string> -> Result<array<string>, string>

          estimatorFunc : float -> int -> Result<float, string>

          expectedValueFunc : float -> float
     }