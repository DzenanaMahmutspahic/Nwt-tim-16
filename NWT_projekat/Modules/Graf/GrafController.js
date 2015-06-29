function ucitajGraf(period) {

    period = typeof period !== 'undefined' ? period : 3600;

    var fd = new FormData()
    //fd.append("ID", $rootScope.globals.currentUser.ID);
    //fd.append("authInfo", $rootScope.globals.currentUser.authdata);
    fd.append("vrsta", 'login');
    fd.append('minute', '65536');

    var ajaxRequest = $.get(
        "/api/values/get?vrsta=login&minute=65536&vremenskiPeriod=" + period,
        function (response) {
            var ctx = document.getElementById("myChart").getContext("2d");

            var data = {};
            data.labels = [];
            data.datasets = [];
            var i, j;
            for (i = 0; i < response.length; i++) {
                var dataset =
                {
                    label: response[i].Kljuc,
                    fillColor: "rgba(" + ((23 * (i + 1)) % 255) + "," + ((63 * (i + 1)) % 255) + "," + ((123 * (i + 1)) % 255) + ",0.2)",
                    strokeColor: "rgba(220,220,220,1)",
                    pointColor: "rgba(" + ((23 * (i + 1)) % 255) + "," + ((63 * (i + 1)) % 255) + "," + ((123 * (i + 1)) % 255) + ",1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(" + ((23 * (i + 1)) % 255) + "," + ((63 * (i + 1)) % 255) + "," + ((123 * (i + 1)) % 255) + ",1)",
                    data: []
                };
                for (j = 0; j < response[i].Vrijednost.length; j++) {
                    if (data.labels.indexOf(response[i].Vrijednost[j].Kljuc) < 0)
                        data.labels.push(response[i].Vrijednost[j].Kljuc);
                    dataset.data.push(response[i].Vrijednost[j].Vrijednost);
                }
                data.datasets.push(dataset);
            }

            var options = {
                ///Boolean - Whether grid lines are shown across the chart
                scaleShowGridLines: true,
                //String - Colour of the grid lines
                scaleGridLineColor: "rgba(0,0,0,.05)",
                //Number - Width of the grid lines
                scaleGridLineWidth: 1,
                //Boolean - Whether to show horizontal lines (except X axis)
                scaleShowHorizontalLines: true,
                //Boolean - Whether to show vertical lines (except Y axis)
                scaleShowVerticalLines: true,
                //Boolean - Whether the line is curved between points
                bezierCurve: true,
                //Number - Tension of the bezier curve between points
                bezierCurveTension: 0.4,
                //Boolean - Whether to show a dot for each point
                pointDot: true,
                //Number - Radius of each point dot in pixels
                pointDotRadius: 4,
                //Number - Pixel width of point dot stroke
                pointDotStrokeWidth: 1,
                //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
                pointHitDetectionRadius: 20,
                //Boolean - Whether to show a stroke for datasets
                datasetStroke: true,
                //Number - Pixel width of dataset stroke
                datasetStrokeWidth: 2,
                //Boolean - Whether to fill the dataset with a colour
                datasetFill: true,
                //String - A legend template
                legendTemplate:
    "<ul class=\"<%=name.toLowerCase()%>-legend\">\
    <% for (var i=0; i<datasets.length; i++) \
        {%> \
            <li> \
                <span style=\"background-color:<%=datasets[i].strokeColor%>\"> \
                </span> \
                <%if(datasets[i].label){%> \
                    <%=datasets[i].label%> \
                <%}%> \
            </li> \
    <%}%> \
</ul>"
            };

            var myLineChart = new Chart(ctx).Line(data, options);

        });

}