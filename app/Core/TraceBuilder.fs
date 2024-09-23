namespace MCSqrtEstimator.Core

type TraceBuilder() =
    let trace v = printfn "trace: value = %A" v

    member this.Bind(v, f) =
        trace v
        f v

    member this.Return(v) = 
        v