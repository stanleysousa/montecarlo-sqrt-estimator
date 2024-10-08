namespace MCSqrtEstimator.Presentation

module Plot =

    module Line =
        open XPlot.GoogleCharts

        let plot title data  =
            let xy: (int * float) seq = data

            let options =
                Options
                    ( title = title,// curveType = "function",
                    width = 600,
                    height = 400,
                    vAxis = Axis(logScale = true, format="scientific", title="e_n"),
                    hAxis = Axis(logScale = true, format="scientific", title="n") )

            data
            |> Chart.Line
            |> Chart.WithOptions options
            |> Chart.Show