namespace MCSqrtEstimator.MonteCarlo

///<summary>
/// Creates an instace for running a Monte Carlo simulation
/// 'estimatorFunc' is the model implementation
/// 'v' is the input value
/// </summary>
type Simulation(estimatorFunc : float -> int -> float, v : float) =

     ///<summary>Runs the simulation for a given model implementation.</summary>
     ///<param name="n">Number of samples.</param>
     ///<returns>Simulations outputs.</returns>
    member this.RunSingle p = Runner.runSingleSimulation estimatorFunc v p
  
     ///<summary>Runs several simulations, with different number of samples, for the specified model implementation.</summary>
     ///<param name="p">Order of magnitude for the maximum number of samples.</param>
     ///<returns>Simulations outputs.</returns>
    member this.RunMany n = Runner.runManySimulations estimatorFunc v n