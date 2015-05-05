'use strict';

angular.module('Posao')

.controller('PosaoController',
    ['$scope', '$rootScope', '$location', 'PosaoService',
    function ($scope, $rootScope, $location, PosaoService) {
        PosSvc = PosaoService;
        scp = $scope;
        $scope.dajPosao = dajPosao();
    }])
    /*
.controller('PosaoController',
    ['$scope', '$rootScope', '$location', 'PosaoService',
    function ($scope, $rootScope, $location, PosaoService) {
        $scope.dodajPosao = function () {
            $scope.dataLoading = true;
            PosaoService.dajPosao(1, function (response) {
                alert(response);
                if (response.success) {
                    $scope.data.posao = response.posao;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
    }])
    */

var PosSvc;
var scp;

function dajPosao() {
    scp.dataLoading = true;
    PosaoSvc.dajPosao(1, dajPosaoResponse(response, scp))
}

function dajPosaoResponse(response, sc) {
    alert(response);
    if (response.success) {
        sc.data.posao = response.posao;
    } else {
        sc.error = response.message;
        sc.errorMessage = sc.trustAsHtml(response.message);
    }
    //$scope.dataLoading = false;
}