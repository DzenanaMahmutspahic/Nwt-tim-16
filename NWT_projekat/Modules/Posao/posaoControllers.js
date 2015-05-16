'use strict';

angular.module('BasicHttpAuthExample')
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
                    if ($scope.data !== undefined && $scope.data !== null) {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                            if ($scope.data.posao.DTP_ID !== undefined && $scope.data.posao.DTP_ID !== null) {
                                $scope.data.posao.DTP_ID = response.data.DTP_ID;
                            }
                            else {
                                $scope.data.posao['DTP_ID'] = response.data.DTP_ID;
                            }
                        }
                        else {
                            $scope.data['posao'] = { DTP_ID: response.data.DTP_ID };
                        }
                    }
                    else {
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
            $scope.loading_Montaza = true;
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
                $scope.loading_Montaza = false;
            })
        };
        $scope.pokaziMontaza = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.Montaza_ID !== undefined && $scope.data.posao.Montaza_ID !== null)
                        return $scope.data.posao.Montaza_ID == 0;
            return true;
        };

        $scope.dodajStampu = function () {
            PosaoService.dodajStampu($scope.t4c1, $scope.t4c2, $scope.t4c3, $scope.t4c4, $scope.t4c5,
                $scope.t4c6, $scope.t4c7, $scope.t4c8, $scope.t4c9, $scope.t4c10,
                $scope.t4c11, $scope.t4c12, $scope.t4c13, $scope.t4c14, $scope.t4c15, $scope.t4c16, $scope.t4c17, $scope.t4c18,
                $scope.t4c19, $scope.t4c20, $scope.t4c21, $scope.t4c22, $scope.t4c23, $scope.t4c24, $scope.t4c25, $scope.t4c26,
                $scope.t4c27, $scope.t4c28, $scope.t4c29, $scope.t4c30, $scope.t4c31, $scope.t4c32, $scope.t4c33,
                function (response) {
                if (response.success) {
                    if ($scope.data !== undefined && $scope.data !== null) {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                            if ($scope.data.posao.Stampa_ID !== undefined && $scope.data.posao.Stampa_ID !== null) {
                                $scope.data.posao.Stampa_ID = response.data.ID;
                            }
                            else {
                                $scope.data.posao['Stampa_ID'] = response.data.ID;
                            }
                        }
                        else {
                            $scope.data['posao'] = { Stampa_ID: response.data.ID };
                        }
                    }
                    else {
                        $scope['data'] = { posao: { Stampa_ID: response.data.ID } };
                    }
                    $scope.data['Stampa'] = response.data;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.pokaziStampu = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.Stampa_ID !== undefined && $scope.data.posao.Stampa_ID !== null)
                        return $scope.data.posao.Stampa_ID == 0;
            return true;
        };

        $scope.dodajVanjskuUslugu = function () {
            PosaoService.dodajVanjskuUslugu($scope.t5c1, $scope.t5c2, $scope.t5c3, $scope.t5c5, $scope.t5c6, $scope.t5c7, function (response) {
                if (response.success) {
                    if ($scope.data !== undefined && $scope.data !== null) {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                            if ($scope.data.posao.VanjskaUsluga_ID !== undefined && $scope.data.posao.VanjskaUsluga_ID !== null) {
                                $scope.data.posao.VanjskaUsluga_ID = response.data.ID;
                            }
                            else {
                                $scope.data.posao['VanjskaUsluga_ID'] = response.data.ID;
                            }
                        }
                        else {
                            $scope.data['posao'] = { VanjskaUsluga_ID: response.data.ID };
                        }
                    }
                    else {
                        $scope['data'] = { posao: { VanjskaUsluga_ID: response.data.ID } };
                    }
                    $scope.data['VanjskaUsluga'] = response.data;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.pokaziVanjskuUslugu = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.VanjskaUsluga_ID !== undefined && $scope.data.posao.VanjskaUsluga_ID !== null)
                        return $scope.data.posao.VanjskaUsluga_ID == 0;
            return true;
        };

        $scope.dodajKnjigovDoradu = function () {
            PosaoService.dodajKnjigovDoradu($scope.t6c1, $scope.t6c2, $scope.t6c3, $scope.t6c4, $scope.t6c5,
                $scope.t6c6, $scope.t6c7, $scope.t6c8, $scope.t6c9, $scope.t6c10,
                $scope.t6c11, $scope.t6c12, $scope.t6c13, $scope.t6c14, $scope.t6c15, $scope.t6c16, $scope.t6c17, $scope.t6c18,
                $scope.t6c19, $scope.t6c20, $scope.t6c21,
                function (response) {
                if (response.success) {
                    if ($scope.data !== undefined && $scope.data !== null) {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                            if ($scope.data.posao.KnjigovDrada_ID !== undefined && $scope.data.posao.KnjigovDrada_ID !== null) {
                                $scope.data.posao.KnjigovDrada_ID = response.data.ID;
                            }
                            else {
                                $scope.data.posao['KnjigovDrada_ID'] = response.data.ID;
                            }
                        }
                        else {
                            $scope.data['posao'] = { KnjigovDrada_ID: response.data.ID };
                        }
                    }
                    else {
                        $scope['data'] = { posao: { KnjigovDrada_ID: response.data.ID } };
                    }
                    $scope.data['KnjigovDrada'] = response.data;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.pokaziKnjigovDoradu = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.KnjigovDrada_ID !== undefined && $scope.data.posao.KnjigovDrada_ID !== null)
                        return $scope.data.posao.KnjigovDrada_ID == 0;
            return true;
        };

        $scope.dodajRucniRad = function () {
            PosaoService.dodajRucniRad($scope.t7c1, $scope.t7c2, $scope.t7c3, $scope.t7c4, $scope.t7c5,
                $scope.t7c6, $scope.t7c7, $scope.t7c8, $scope.t7c9, $scope.t7c10,
                $scope.t7c11, $scope.t7c12, $scope.t7c13, $scope.t7c14, $scope.t7c15,
                function (response) {
                if (response.success) {
                    if ($scope.data !== undefined && $scope.data !== null) {
                        if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                            if ($scope.data.posao.RucniRad_ID !== undefined && $scope.data.posao.RucniRad_ID !== null) {
                                $scope.data.posao.RucniRad_ID = response.data.ID;
                            }
                            else {
                                $scope.data.posao['RucniRad_ID'] = response.data.ID;
                            }
                        }
                        else {
                            $scope.data['posao'] = { RucniRad_ID: response.data.ID };
                        }
                    }
                    else {
                        $scope['data'] = { posao: { RucniRad_ID: response.data.ID } };
                    }
                    $scope.data['RucniRad'] = response.data;
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.pokaziRucniRad = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.RucniRad_ID !== undefined && $scope.data.posao.RucniRad_ID !== null)
                        return $scope.data.posao.RucniRad_ID == 0;
            return true;
        };
    }])