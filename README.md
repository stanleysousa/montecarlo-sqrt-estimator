# montecarlo-sqrt-estimator
Estimates the square root of a number using the Monte Carlo method. For more information see the [documentation](./docs/mc_sqrt.pdf).

## How to use
- You need [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) runtime
- On a terminal go to the [\app](../app) folder and execute "dotnet run \<v:float\> \<p:int\>"
# Example

```
PS ...\app> dotnet run 3.8 6
sqrt for (3.800000): ref=1.949359 est=1.000000 e_n=0.487011 for 2 samples
sqrt for (3.800000): ref=1.949359 est=3.000000 e_n=0.538968 for 3 samples
sqrt for (3.800000): ref=1.949359 est=4.000000 e_n=1.051957 for 4 samples
sqrt for (3.800000): ref=1.949359 est=2.500000 e_n=0.282473 for 5 samples
sqrt for (3.800000): ref=1.949359 est=1.500000 e_n=0.230516 for 6 samples
sqrt for (3.800000): ref=1.949359 est=1.400000 e_n=0.281815 for 7 samples
sqrt for (3.800000): ref=1.949359 est=1.333333 e_n=0.316014 for 8 samples
sqrt for (3.800000): ref=1.949359 est=1.285714 e_n=0.340442 for 9 samples
sqrt for (3.800000): ref=1.949359 est=1.666667 e_n=0.145018 for 10 samples
sqrt for (3.800000): ref=1.949359 est=2.222222 e_n=0.139976 for 20 samples
sqrt for (3.800000): ref=1.949359 est=2.000000 e_n=0.025978 for 30 samples
sqrt for (3.800000): ref=1.949359 est=2.000000 e_n=0.025978 for 40 samples
sqrt for (3.800000): ref=1.949359 est=2.272727 e_n=0.165884 for 50 samples
sqrt for (3.800000): ref=1.949359 est=1.363636 e_n=0.300469 for 60 samples
sqrt for (3.800000): ref=1.949359 est=2.000000 e_n=0.025978 for 70 samples
sqrt for (3.800000): ref=1.949359 est=1.860465 e_n=0.045602 for 80 samples
sqrt for (3.800000): ref=1.949359 est=1.875000 e_n=0.038145 for 90 samples
sqrt for (3.800000): ref=1.949359 est=1.960784 e_n=0.005861 for 100 samples
sqrt for (3.800000): ref=1.949359 est=1.904762 e_n=0.022878 for 200 samples
sqrt for (3.800000): ref=1.949359 est=1.960784 e_n=0.005861 for 300 samples
sqrt for (3.800000): ref=1.949359 est=1.739130 e_n=0.107845 for 400 samples
sqrt for (3.800000): ref=1.949359 est=1.937984 e_n=0.005835 for 500 samples
sqrt for (3.800000): ref=1.949359 est=2.013423 e_n=0.032864 for 600 samples
sqrt for (3.800000): ref=1.949359 est=1.994302 e_n=0.023055 for 700 samples
sqrt for (3.800000): ref=1.949359 est=1.923077 e_n=0.013482 for 800 samples
sqrt for (3.800000): ref=1.949359 est=2.008929 e_n=0.030559 for 900 samples
sqrt for (3.800000): ref=1.949359 est=1.930502 e_n=0.009673 for 1000 samples
sqrt for (3.800000): ref=1.949359 est=1.974334 e_n=0.012812 for 2000 samples
sqrt for (3.800000): ref=1.949359 est=1.977587 e_n=0.014481 for 3000 samples
sqrt for (3.800000): ref=1.949359 est=1.937984 e_n=0.005835 for 4000 samples
sqrt for (3.800000): ref=1.949359 est=1.923077 e_n=0.013482 for 5000 samples
sqrt for (3.800000): ref=1.949359 est=1.975634 e_n=0.013479 for 6000 samples
sqrt for (3.800000): ref=1.949359 est=1.939595 e_n=0.005009 for 7000 samples
sqrt for (3.800000): ref=1.949359 est=1.955034 e_n=0.002911 for 8000 samples
sqrt for (3.800000): ref=1.949359 est=1.932990 e_n=0.008397 for 9000 samples
sqrt for (3.800000): ref=1.949359 est=1.985703 e_n=0.018644 for 10000 samples
sqrt for (3.800000): ref=1.949359 est=1.953507 e_n=0.002128 for 20000 samples
sqrt for (3.800000): ref=1.949359 est=1.945904 e_n=0.001772 for 30000 samples
sqrt for (3.800000): ref=1.949359 est=1.961650 e_n=0.006305 for 40000 samples
sqrt for (3.800000): ref=1.949359 est=1.940316 e_n=0.004639 for 50000 samples
sqrt for (3.800000): ref=1.949359 est=1.953888 e_n=0.002324 for 60000 samples
sqrt for (3.800000): ref=1.949359 est=1.949318 e_n=0.000021 for 70000 samples
sqrt for (3.800000): ref=1.949359 est=1.934376 e_n=0.007686 for 80000 samples
sqrt for (3.800000): ref=1.949359 est=1.952066 e_n=0.001389 for 90000 samples
sqrt for (3.800000): ref=1.949359 est=1.951791 e_n=0.001248 for 100000 samples
sqrt for (3.800000): ref=1.949359 est=1.949508 e_n=0.000076 for 200000 samples
sqrt for (3.800000): ref=1.949359 est=1.947597 e_n=0.000904 for 300000 samples
sqrt for (3.800000): ref=1.949359 est=1.950059 e_n=0.000359 for 400000 samples
sqrt for (3.800000): ref=1.949359 est=1.947344 e_n=0.001034 for 500000 samples
sqrt for (3.800000): ref=1.949359 est=1.949229 e_n=0.000067 for 600000 samples
sqrt for (3.800000): ref=1.949359 est=1.951573 e_n=0.001136 for 700000 samples
sqrt for (3.800000): ref=1.949359 est=1.953068 e_n=0.001903 for 800000 samples
sqrt for (3.800000): ref=1.949359 est=1.945529 e_n=0.001964 for 900000 samples
sqrt for (3.800000): ref=1.949359 est=1.951627 e_n=0.001164 for 1000000 samples
Simulation complete.
PS ...\app>
```
![Relative error for v=3.8](/docs/e_n-for-3_8-6.JPG)