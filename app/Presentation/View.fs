namespace MCSqrtEstimator.Presentation

module View =

    open MCSqrtEstimator.Core.Types
    open MCSqrtEstimator.Presentation.Plot
    
    let writeSummary model output= 
        printfn "%s for (%f): expected=%f estimated=%f e_n=%f for %d samples" model output.Value output.ExpectedValue output.EstimatedValue output.RelativeError output.Samples
    
    let plotRelativeErrors (results : SimulationResult array) = 
        if results .Length > 0 then
            let v = results.[0].Value
            let title = sprintf "Relative error for v=%f and n samples" v
            results
            |> Seq.map (fun o -> o.Samples, o.RelativeError)
            |> Line.plot title