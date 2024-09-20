# montecarlo-sqrt-estimator
Estimates the square root of the number `v` using the Monte Carlo method with 10^`p` samples.

For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) sdk
- On a terminal go to the [\app](/app) folder and execute "dotnet run \<`v`:float\> \<`p`:int\>"
# Example

```
PS ...\app> dotnet run 3.8 8
sqrt for (3.800000): ref=1.949359 est=1.000000 e_n=0.487011 for 1 samples
sqrt for (3.800000): ref=1.949359 est=1.666667 e_n=0.145018 for 10 samples
sqrt for (3.800000): ref=1.949359 est=1.818182 e_n=0.067292 for 100 samples
sqrt for (3.800000): ref=1.949359 est=2.024291 e_n=0.038440 for 1000 samples
sqrt for (3.800000): ref=1.949359 est=1.958097 e_n=0.004482 for 10000 samples
sqrt for (3.800000): ref=1.949359 est=1.957292 e_n=0.004070 for 100000 samples
sqrt for (3.800000): ref=1.949359 est=1.950146 e_n=0.000404 for 1000000 samples
sqrt for (3.800000): ref=1.949359 est=1.950009 e_n=0.000334 for 10000000 samples
sqrt for (3.800000): ref=1.949359 est=1.949425 e_n=0.000034 for 100000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.8](/docs/error-3_8_8.JPG)
