namespace MCSqrtEstimator.Core.Types

type Result<'TResultSuccess,'TResultFailure> =
| ResultSuccess of Output
| ResultFailure of string