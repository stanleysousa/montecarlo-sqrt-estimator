# montecarlo-sqrt-estimator
Estimates the square root of a number using the Monte Carlo method. For more information see the [documentation](./doc/mc_sqrt.pdf).

## How to use
- You need [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) runtime
- Change [Program.fs](./app/Program.fs) as you wish, for example:
> open Estimators\
> ...\
> let value, samples = 3.8 10000\
> let sqrt3_8 = Sqrt.estimate value samples\
> printfn "The estimated value for sqrt(%f) is %f:" value sqrt3_8\
- On a terminal go to the [\app](../app) folder and execute "dotnet run .\MCSqrtEstimator.fsproj"

## Result
sqrt(2.000000): ref=1.414214 est=1.470588 delta=0.056375 epsilon=0.038335 for 100 samples\
sqrt(2.000000): ref=1.414214 est=1.371742 delta=0.042471 epsilon=0.030962 for 1000 samples\
sqrt(2.000000): ref=1.414214 est=1.410039 delta=0.004174 epsilon=0.002960 for 10000 samples\
sqrt(2.000000): ref=1.414214 est=1.413128 delta=0.001086 epsilon=0.000768 for 100000 samples\
sqrt(2.000000): ref=1.414214 est=1.414851 delta=0.000638 epsilon=0.000451 for 1000000 samples\
sqrt(2.000000): ref=1.414214 est=1.414651 delta=0.000437 epsilon=0.000309 for 10000000 samples