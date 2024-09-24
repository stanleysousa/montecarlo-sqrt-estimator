# montecarlo-sqrt-estimator
Estimates the square root of the number `v` using the Monte Carlo method with 10^`p` samples.

For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) sdk
- On a terminal go to the [\app](/app) folder and execute "dotnet run \<`v`:float\> \<`p`:int\>"
# Example

```
PS ...\app> dotnet run 3.5 8
trace: value = 51.0
trace: value = 5281.0
trace: value = 53483.0
trace: value = 553.0
trace: value = 8.0
trace: value = 534392.0
trace: value = 5346721.0
trace: value = 53461839.0
sqrt for (3.500000): expected=1.870829 estimated=1.250000 e_n=0.331847 for 10 samples
sqrt for (3.500000): expected=1.870829 estimated=1.960784 e_n=0.048083 for 100 samples
sqrt for (3.500000): expected=1.870829 estimated=1.808318 e_n=0.033413 for 1000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.893581 e_n=0.012161 for 10000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.869753 e_n=0.000575 for 100000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.871285 e_n=0.000244 for 1000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.870305 e_n=0.000280 for 10000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.870493 e_n=0.000179 for 100000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.5](/docs/error-3_5_8.JPG)
