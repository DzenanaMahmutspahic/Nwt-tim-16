//(function (angular) {
//    'use strict';
//    angular.module('BasicHttpAuthExample')
//    .controller('FusionChartsController', function($scope) {
//        $scope.dataSource = {
//            "chart": {
//                "caption": "Monthly revenue for last year",
//                "subCaption": "Harry's SuperMart",
//                "xAxisName": "Month",
//                "yAxisName": "Revenues (In USD)",
//                "numberPrefix": "$",
//                "paletteColors": "#0075c2",
//                "bgColor": "#ffffff",
//                "borderAlpha": "20",
//                "canvasBorderAlpha": "0",
//                "usePlotGradientColor": "0",
//                "plotBorderAlpha": "10",
//                "placevaluesInside": "1",
//                "rotatevalues": "1",
//                "valueFontColor": "#ffffff",
//                "showXAxisLine": "1",
//                "xAxisLineColor": "#999999",
//                "divlineColor": "#999999",
//                "divLineDashed": "1",
//                "showAlternateHGridColor": "0",
//                "subcaptionFontBold": "0",
//                "subcaptionFontSize": "14",
//                "theme": "fint"
//            },
//            "data": [
//              {
//                  "label": "Jan",
//                  "value": "420000"
//              },
//              {
//                  "label": "Feb",
//                  "value": "810000"
//              },
//              {
//                  "label": "Mar",
//                  "value": "720000"
//              },
//              {
//                  "label": "Apr",
//                  "value": "550000"
//              },
//              {
//                  "label": "May",
//                  "value": "910000"
//              },
//              {
//                  "label": "Jun",
//                  "value": "510000"
//              },
//              {
//                  "label": "Jul",
//                  "value": "680000"
//              },
//              {
//                  "label": "Aug",
//                  "value": "620000"
//              },
//              {
//                  "label": "Sep",
//                  "value": "610000"
//              },
//              {
//                  "label": "Oct",
//                  "value": "490000"
//              },
//              {
//                  "label": "Nov",
//                  "value": "900000"
//              },
//              {
//                  "label": "Dec",
//                  "value": "730000"
//              }
//            ],
//            "trendlines": [
//              {
//                  "line": [
//                     {
//                         "startvalue": "700000",
//                         "color": "#1aaf5d",
//                         "valueOnRight": "1",
//                         "displayvalue": "Monthly Target"
//                     }
//                  ]
//              }
//            ]
//        };
//    })
//      .directive('grafoviDirektiva', function ($rootScope) {
//          return {
//              template:
//                '<div ng-controller="FusionChartsController"><fusioncharts \
//                    width="600" \
//                    height="400"\
//                    type="column2d" \
//                    datasource="{{dataSource}}"\
//                > </fusioncharts></div>'
//          };

//      });
//})(window.angular);

app.controller("LineCtrl", function ($scope) {

    $scope.labels = ["January", "February", "March", "April", "May", "June", "July"];
    $scope.series = ['Series A', 'Series B'];
    $scope.data = [
      [65, 59, 80, 81, 56, 55, 40],
      [28, 48, 40, 19, 86, 27, 90]
    ];
    $scope.onClick = function (points, evt) {
        console.log(points, evt);
    };
});

