# montecarlo-sqrt-estimator
Estimates the square root of a number using the Monte Carlo method. For more information see the [documentation](./docs/mc_sqrt.pdf).

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
sqrt(2.000000): ref=1.414214 est=1.426534 e_n=0.008712 for 1000 samples\
sqrt(2.000000): ref=1.414214 est=1.432665 e_n=0.013047 for 2000 samples\
sqrt(2.000000): ref=1.414214 est=1.410437 e_n=0.002670 for 3000 samples\
sqrt(2.000000): ref=1.414214 est=1.417937 e_n=0.002633 for 4000 samples\
sqrt(2.000000): ref=1.414214 est=1.419648 e_n=0.003843 for 5000 samples\
sqrt(2.000000): ref=1.414214 est=1.406140 e_n=0.005709 for 6000 samples\
sqrt(2.000000): ref=1.414214 est=1.434426 e_n=0.014293 for 7000 samples\
sqrt(2.000000): ref=1.414214 est=1.408947 e_n=0.003724 for 8000 samples\
sqrt(2.000000): ref=1.414214 est=1.413317 e_n=0.000634 for 9000 samples