'use strict';

angular.module('Posao')
.controller('PosaoController',
    ['$scope', '$rootScope', '$location', 'PosaoService',
    function ($scope, $rootScope, $location, PosaoService) {

        $scope.dajPosao = function () {
            $scope.dataLoading = true;
            PosaoService.dajPosao(1, function (response) {
                if (response.success) {
                    $scope['data'] = { posao: response.posao };
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $scope.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        }
    }])

.controller('PosaoController',
    ['$scope', '$rootScope', '$location', 'PosaoService',
    function ($scope, $rootScope, $location, PosaoService) {
        $scope.dodajDTP = function () {
            PosaoService.dodajDTP($scope.t3c1, $scope.t3c2, $scope.t3c4, $scope.t3c5, $scope.t3c6, $scope.t3c7, function (response) {
                if (response.success) {
                    if ($scope.data !== undefined && $scope.data !== null)
                    {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                        {
                            if ($scope.data.posao.DTP_ID !== undefined && $scope.data.posao.DTP_ID !== null)
                            {
                                $scope.data.posao.DTP_ID = response.data.DTP_ID;
                            }
                            else
                            {
                                $scope.data.posao['DTP_ID'] = response.data.DTP_ID;
                            }
                        }
                        else
                        {
                            $scope.data['posao'] = { DTP_ID: response.data.DTP_ID };
                        }
                    }
                    else
                    {
                        $scope['data'] = { posao: { DTP_ID: response.data.DTP_ID } };
                    }
                    $scope.data['DTP'] = response.data;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.pokaziDTP = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.DTP_ID !== undefined && $scope.data.posao.DTP_ID !== null)
                        return $scope.data.posao.DTP_ID == 0;
            return true;
        };

        $scope.dodajMontazu = function () {
            PosaoService.dodajMontazu($scope.t4c1, $scope.t4c2, $scope.t4c4, $scope.t4c5, $scope.t4c6, $scope.t4c7, function (response) {
                if (response.success) {                    
                    if ($scope.data !== undefined && $scope.data !== null) {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                            if ($scope.data.posao.Montaza_ID !== undefined && $scope.data.posao.Montaza_ID !== null) {
                                $scope.data.posao.Montaza_ID = response.data.ID;
                            }
                            else {
                                $scope.data.posao['Montaza_ID'] = response.data.ID;
                            }
                        }
                        else {
                            $scope.data['posao'] = { Montaza_ID: response.data.ID };
                        }
                    }
                    else {
                        $scope['data'] = { posao: { Montaza_ID: response.data.ID } };
                    }
                    $scope.data['Montaza'] = response.data;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.pokaziMontaza = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.Montaza_ID !== undefined && $scope.data.posao.Montaza_ID !== null)
                        return $scope.data.posao.Montaza_ID == 0;
            return true;
        };
    }])