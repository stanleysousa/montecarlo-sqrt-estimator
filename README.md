# montecarlo-sqrt-estimator
Estimates the square root of the number `v` using the Monte Carlo method with 10^`p` samples.

For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) sdk
- On a terminal go to the [\app](/app) folder and execute "dotnet run \<`v`:float\> \<`p`:int\>"
# Example

```
PS ...\app> dotnet run 3.5 8
sqrt for (3.500000): expected=1.870829 estimated=5.000000 e_n=1.672612 for 10 samples
sqrt for (3.500000): expected=1.870829 estimated=1.960784 e_n=0.048083 for 100 samples
sqrt for (3.500000): expected=1.870829 estimated=1.845018 e_n=0.013796 for 1000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.875117 e_n=0.002292 for 10000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.881361 e_n=0.005630 for 100000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.867421 e_n=0.001822 for 1000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.870303 e_n=0.000281 for 10000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.871043 e_n=0.000115 for 100000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.5](/docs/error-3_5_8.JPG)
