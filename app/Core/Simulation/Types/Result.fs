namespace MCSqrtEstimator.Core.Simulation.Types

type Result<'TCompleted,'TAborted> =
| Success of Output
| Failure of string