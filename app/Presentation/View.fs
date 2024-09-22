namespace MCSqrtEstimator.Presentation

module View =

    open Plot
    open MCSqrtEstimator.Core.Simulation.Types

    let writeSummary model output= 
        printfn "%s for (%f): expected=%f estimated=%f e_n=%f for %d samples" model output.RunParameters.Value output.RunParameters.ExpectedValue output.EstimatedValue output.RelativeError output.RunParameters.Samples
    
    let plotRelativeErrors (results : Output array) = 
        if results .Length > 0 then
            let v = results.[0].RunParameters.Value
            let title = sprintf "Relative error for v=%f and n samples" v
            results
            |> Seq.map (fun o -> o.RunParameters.Samples, o.RelativeError)
            |> Line.plot title