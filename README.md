# montecarlo-sqrt-estimator
Estimates the square root of the number `v` using the Monte Carlo method with 10^`p` samples.

For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) sdk
- On a terminal go to the [\app](/app) folder and execute "dotnet run \<`v`:float\> \<`p`:int\>"
# Example

```
PS ...\app> dotnet run 3.5 8
sqrt for (3.500000): expected=1.870829 estimated=3.333333 e_n=0.781742 for 10 samples
sqrt for (3.500000): expected=1.870829 estimated=1.694915 e_n=0.094030 for 100 samples
sqrt for (3.500000): expected=1.870829 estimated=1.828154 e_n=0.022811 for 1000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.892506 e_n=0.011587 for 10000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.860534 e_n=0.005503 for 100000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.869386 e_n=0.000771 for 1000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.870675 e_n=0.000082 for 10000000 samples
sqrt for (3.500000): expected=1.870829 estimated=1.870902 e_n=0.000039 for 100000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.5](/docs/error-3_5_8.JPG)
