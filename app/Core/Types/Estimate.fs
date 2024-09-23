namespace MCSqrtEstimator.Core.Types

type Estimate<'TEstimateSuccess,'TEstimateFailure> =
| EstimateSuccess of float
| EstimateFailure of string