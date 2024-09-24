namespace MCSqrtEstimator.Core.Types

type MCModelOutput =
     {
          Value : float
          Samples : int
          ExpectedValue: float
          EstimatedValue : float
          RelativeError : float
     }