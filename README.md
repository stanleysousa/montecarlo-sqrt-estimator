# montecarlo-sqrt-estimator
Estimates the square root of the number `v` using the Monte Carlo method with 10^`p` samples.

For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) sdk
- On a terminal go to the [\app](/app) folder and execute "dotnet run \<`v`:float\> \<`p`:int\>"
# Example

```
PS ...\app> dotnet run 3.5 8
trace: value = 5.0
trace: value = 59.0
trace: value = 542.0
trace: value = 5316.0
trace: value = 53317.0
trace: value = 534910.0
trace: value = 5342906.0
trace: value = 53453304.0
sqrt for (3.500000): expected=1.870829 estimated=2.000000 e_n=0.069045 for 10 samples
sqrt for (3.500000): expected=1.870829 estimated=1.694915 e_n=0.094030 for 100 samples
sqrt for (3.500000): expected=1.870829 estimated=1.845018 e_n=0.013796 for 1000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.881114 e_n=0.005498 for 10000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.875574 e_n=0.002537 for 100000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.869473 e_n=0.000724 for 1000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.871641 e_n=0.000434 for 10000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.870792 e_n=0.000020 for 100000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.5](/docs/error-3_5_8.JPG)
