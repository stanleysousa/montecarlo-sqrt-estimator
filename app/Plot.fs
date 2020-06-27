namespace Plot

module Line =
    open XPlot.GoogleCharts

    let plot data title =
        let xy: (int * float) list = data

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