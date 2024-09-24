namespace MCSqrtEstimator.Core.Types

type SimulationResult =
     {
          Value : float
          Samples : int
          ExpectedValue: float
          EstimatedValue : float
          RelativeError : float
     }