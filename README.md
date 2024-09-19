# montecarlo-sqrt-estimator
Estimates the square root of a number using the Monte Carlo method. For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) runtime
- On a terminal go to the [\app](../app) folder and execute "dotnet run \<v\> \<p\>"
# Example

```
PS ...\app> dotnet run 3.8 6
sqrt(3.800000): ref=1.949359 est=2.000000 e_n=0.025978 for 2 samples
sqrt(3.800000): ref=1.949359 est=1.500000 e_n=0.230516 for 3 samples
sqrt(3.800000): ref=1.949359 est=2.000000 e_n=0.025978 for 4 samples
sqrt(3.800000): ref=1.949359 est=5.000000 e_n=1.564946 for 5 samples
sqrt(3.800000): ref=1.949359 est=2.000000 e_n=0.025978 for 6 samples
sqrt(3.800000): ref=1.949359 est=1.400000 e_n=0.281815 for 7 samples
sqrt(3.800000): ref=1.949359 est=1.142857 e_n=0.413727 for 8 samples
sqrt(3.800000): ref=1.949359 est=3.000000 e_n=0.538968 for 9 samples
sqrt(3.800000): ref=1.949359 est=1.666667 e_n=0.145018 for 10 samples
sqrt(3.800000): ref=1.949359 est=2.222222 e_n=0.139976 for 20 samples
sqrt(3.800000): ref=1.949359 est=1.666667 e_n=0.145018 for 30 samples
sqrt(3.800000): ref=1.949359 est=1.904762 e_n=0.022878 for 40 samples
sqrt(3.800000): ref=1.949359 est=1.851852 e_n=0.050020 for 50 samples
sqrt(3.800000): ref=1.949359 est=1.764706 e_n=0.094725 for 60 samples
sqrt(3.800000): ref=1.949359 est=2.258065 e_n=0.158363 for 70 samples
sqrt(3.800000): ref=1.949359 est=1.904762 e_n=0.022878 for 80 samples
sqrt(3.800000): ref=1.949359 est=1.730769 e_n=0.112134 for 90 samples
sqrt(3.800000): ref=1.949359 est=2.040816 e_n=0.046917 for 100 samples
sqrt(3.800000): ref=1.949359 est=2.272727 e_n=0.165884 for 200 samples
sqrt(3.800000): ref=1.949359 est=2.097902 e_n=0.076201 for 300 samples
sqrt(3.800000): ref=1.949359 est=1.923077 e_n=0.013482 for 400 samples
sqrt(3.800000): ref=1.949359 est=1.953125 e_n=0.001932 for 500 samples
sqrt(3.800000): ref=1.949359 est=1.910828 e_n=0.019766 for 600 samples
sqrt(3.800000): ref=1.949359 est=2.017291 e_n=0.034848 for 700 samples
sqrt(3.800000): ref=1.949359 est=1.913876 e_n=0.018203 for 800 samples
sqrt(3.800000): ref=1.949359 est=1.943844 e_n=0.002829 for 900 samples
sqrt(3.800000): ref=1.949359 est=1.926782 e_n=0.011582 for 1000 samples
sqrt(3.800000): ref=1.949359 est=2.020202 e_n=0.036342 for 2000 samples
sqrt(3.800000): ref=1.949359 est=1.914486 e_n=0.017889 for 3000 samples
sqrt(3.800000): ref=1.949359 est=1.978239 e_n=0.014815 for 4000 samples
sqrt(3.800000): ref=1.949359 est=1.940994 e_n=0.004291 for 5000 samples
sqrt(3.800000): ref=1.949359 est=1.934236 e_n=0.007758 for 6000 samples
sqrt(3.800000): ref=1.949359 est=1.954216 e_n=0.002491 for 7000 samples
sqrt(3.800000): ref=1.949359 est=1.967536 e_n=0.009324 for 8000 samples
sqrt(3.800000): ref=1.949359 est=1.965495 e_n=0.008277 for 9000 samples
sqrt(3.800000): ref=1.949359 est=1.942879 e_n=0.003324 for 10000 samples
sqrt(3.800000): ref=1.949359 est=1.941559 e_n=0.004001 for 20000 samples
sqrt(3.800000): ref=1.949359 est=1.962709 e_n=0.006848 for 30000 samples
sqrt(3.800000): ref=1.949359 est=1.956086 e_n=0.003451 for 40000 samples
sqrt(3.800000): ref=1.949359 est=1.946358 e_n=0.001539 for 50000 samples
sqrt(3.800000): ref=1.949359 est=1.955162 e_n=0.002977 for 60000 samples
sqrt(3.800000): ref=1.949359 est=1.954434 e_n=0.002603 for 70000 samples
sqrt(3.800000): ref=1.949359 est=1.945005 e_n=0.002233 for 80000 samples
sqrt(3.800000): ref=1.949359 est=1.956734 e_n=0.003784 for 90000 samples
sqrt(3.800000): ref=1.949359 est=1.949812 e_n=0.000232 for 100000 samples
sqrt(3.800000): ref=1.949359 est=1.948368 e_n=0.000508 for 200000 samples
sqrt(3.800000): ref=1.949359 est=1.954614 e_n=0.002696 for 300000 samples
sqrt(3.800000): ref=1.949359 est=1.946178 e_n=0.001632 for 400000 samples
sqrt(3.800000): ref=1.949359 est=1.947200 e_n=0.001108 for 500000 samples
sqrt(3.800000): ref=1.949359 est=1.952159 e_n=0.001436 for 600000 samples
sqrt(3.800000): ref=1.949359 est=1.949052 e_n=0.000158 for 700000 samples
sqrt(3.800000): ref=1.949359 est=1.949978 e_n=0.000318 for 800000 samples
sqrt(3.800000): ref=1.949359 est=1.951228 e_n=0.000959 for 900000 samples
sqrt(3.800000): ref=1.949359 est=1.949029 e_n=0.000169 for 1000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.8](/docs/e_n-for-3_8.JPG)