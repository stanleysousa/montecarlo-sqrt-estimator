namespace MCSqrtEstimator.Core.MonteCarlo.Types

type Estimate<'TSuccess,'TFailure> =
| Success of float
| Failure of string