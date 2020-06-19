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
The reference value for sqrt(2.000000) is: 1.414214\
The estimated value for sqrt(2.000000) using Monte Carlo is:\
  1.455604 e=0.041391 from 1000 samples\
  1.420656 e=0.006443 from 10000 samples\
  1.411353 e=0.002861 from 100000 samples\
  1.414597 e=0.000384 from 1000000 samples