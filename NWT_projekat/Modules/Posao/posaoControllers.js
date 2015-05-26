'use strict';

angular.module('BasicHttpAuthExample')
.controller('PosaoController',
    ['$scope', '$rootScope', '$location', 'PosaoService',
    function ($scope, $rootScope, $location, PosaoService) {

        $scope.DajNezavrsenePoslove = function () {
            $scope.dataLoading = true;
            PosaoService.DajNezavrsenePoslove(function (response) {
                if (response.success) {
                    $scope.poslovi = response.poslovi;
                }
            })
        };

        if ($rootScope.globals !== undefined && $rootScope.globals !== null
            && $rootScope.globals.currentUser !== undefined && $rootScope.globals.currentUser !== null
            && $rootScope.globals.currentUser.ID !== undefined && $rootScope.globals.currentUser.ID !== null) {
            if ($rootScope.globals.currentUser.pozicija >= 3) {
                $scope.DajNezavrsenePoslove();
            }
        } else {
            $location.path('/');
        }

        $scope.PokaziPosao = function (id) {
            var i = IndexOf($scope.poslovi, function (posao) { return posao.ID == id });
            if (i >= 0) {
                $scope.data = { posao: $scope.poslovi[i] };
                PosaoService.DajDTP($scope.data.posao.DTP_ID, function (response) {
                    if (response.success) {
                        $scope.data['DTP'] = response.data;
                    }
                });
                PosaoService.DajMontazu($scope.data.posao.Montaza_ID, function (response) {
                    if (response.success) {
                        $scope.data['Montaza'] = response.data;
                    }
                });
                PosaoService.DajStampu($scope.data.posao.Stampa_ID, function (response) {
                    if (response.success) {
                        $scope.data['Stampa'] = response.data;
                    }
                });
            }
        };
        $scope.potvrdiPosao = function () {
            PosaoService.potvrdiPosao($scope.data.posao.ID, function (response) {
                var i = IndexOf($scope.poslovi, function (posao) { return posao.ID == $scope.data.posao.ID });
                if (response.success) {
                    $scope.poslovi.splice(i, 1);
                    $scope.posao = {};
                    $scope.data = {};
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $scope.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
        $scope.dajPosao = function () {
            PosaoService.dajPosao(1, function (response) {
                if (response.success) {
                    $scope['data'] = { posao: response.posao };
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $scope.trustAsHtml(response.message);
                }
                //$scope.dataLoading = false;
            })
        };
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
            PosaoService.dodajStampu($scope.t5c1, $scope.t5c2, $scope.t5c3, $scope.t5c4, $scope.t5c5,
                $scope.t5c6, $scope.t5c7, $scope.t5c8, $scope.t5c9, $scope.t5c10,
                $scope.t5c11, $scope.t5c12, $scope.t5c13, $scope.t5c14, $scope.t5c15, $scope.t5c16, $scope.t5c17, $scope.t5c18,
                $scope.t5c19, $scope.t5c20, $scope.t5c21, $scope.t5c22, $scope.t5c23, $scope.t5c24, $scope.t5c25, $scope.t5c26,
                $scope.t5c27, $scope.t5c28, $scope.t5c29, $scope.t5c30, $scope.t5c31, $scope.t5c32, $scope.t5c33,
                function (response) {
                    if (response.success) {
                        if ($scope.data !== undefined && $scope.data !== null) {
                            if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                                if ($scope.data.posao.Stampa_ID !== undefined && $scope.data.posao.Stampa_ID !== null) {
                                    $scope.data.posao.Stampa_ID = response.data.Stampa_ID;
                                }
                                else {
                                    $scope.data.posao['Stampa_ID'] = response.data.Stampa_ID;
                                }
                            }
                            else {
                                $scope.data['posao'] = { Stampa_ID: response.data.Stampa_ID };
                            }
                        }
                        else {
                            $scope['data'] = { posao: { Stampa_ID: response.data.Stampa_ID } };
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

        $scope.dodajReproMaterijal = function () {
            $scope.dataLoading = true;
            PosaoService.dodajReproMaterijal($scope.t2c1, $scope.t2c2, $scope.t2c3, $scope.t2c4, $scope.t2c5,
                $scope.t2c6, $scope.t2c7, $scope.t2c8, $scope.t2c9, $scope.t2c10,
                $scope.t2c11, $scope.t2c12, $scope.t2c13, $scope.t2c14, $scope.t2c15, $scope.t2c16, $scope.t2c17, $scope.t2c18,
                $scope.t2c19, $scope.t2c20, $scope.t2c21, $scope.t2c22, $scope.t2c23, $scope.t2c24, $scope.t2c25, $scope.t2c26,
                $scope.t2c27, $scope.t2c28, $scope.t2c29, $scope.t2c30, $scope.t2c31, $scope.t2c32, $scope.t2c33, $scope.t2c34,
                $scope.t2c35, $scope.t2c36, $scope.t2c37, $scope.t2c38, $scope.t2c39, $scope.t2c40, $scope.t2c41, $scope.t2c42,
                function (response) {
                    if (response.success) {
                        if ($scope.data !== undefined && $scope.data !== null) {
                            if ($scope.data.posao !== undefined && $scope.data.posao !== null) {
                                if ($scope.data.posao.ReproMaterijal_ID !== undefined && $scope.data.posao.ReproMaterijal_ID !== null) {
                                    $scope.data.posao.ReproMaterijal_ID = response.data.ID;
                                }
                                else {
                                    $scope.data.posao['ReproMaterijal_ID'] = response.data.ID;
                                }
                            }
                            else {
                                $scope.data['posao'] = { ReproMaterijal_ID: response.data.ID };
                            }
                        }
                        else {
                            $scope['data'] = { posao: { ReproMaterijal_ID: response.data.ID } };
                        }
                        $scope.data['ReproMaterijal'] = response.data;
                    } else {
                        $scope.error = response.message;
                        $scope.errorMessage = $sce.trustAsHtml(response.message);
                    }
                    $scope.dataLoading = false;
                })
        };
        $scope.pokaziReproMaterijal = function () {
            if ($scope.data !== undefined && $scope.data !== null)
                if ($scope.data.posao !== undefined && $scope.data.posao !== null)
                    if ($scope.data.posao.ReproMaterijal_ID !== undefined && $scope.data.posao.ReproMaterijal_ID !== null)
                        return $scope.data.posao.ReproMaterijal_ID == 0;
            return true;
        };

        $scope.dodajVanjskuUslugu = function () {
            PosaoService.dodajVanjskuUslugu($scope.t6c1, $scope.t6c2, $scope.t6c3, $scope.t6c5, $scope.t6c6, $scope.t6c7, function (response) {
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
            PosaoService.dodajKnjigovDoradu($scope.t7c1, $scope.t7c2, $scope.t7c3, $scope.t7c4, $scope.t7c5,
                $scope.t7c6, $scope.t7c7, $scope.t7c8, $scope.t7c9, $scope.t7c10,
                $scope.t7c11, $scope.t7c12, $scope.t7c13, $scope.t7c14, $scope.t7c15, $scope.t7c16, $scope.t7c17, $scope.t7c18,
                $scope.t7c19, $scope.t7c20, $scope.t7c21,
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

        $scope.dodajPosao = function () {
            PosaoService.dodajPosao($scope.data.posao.ReproMaterijal_ID, $scope.data.posao.DTP_ID, $scope.data.posao.Montaza_ID,
                 $scope.data.posao.KnjigovDrada_ID, $scope.data.posao.RucniRad_ID, $scope.data.posao.Stampa_ID,
                function (response) {
                    if (response.success) {
                        $location.path('/');
                    } else {
                        $scope.error = response.message;
                        $scope.errorMessage = $sce.trustAsHtml(response.message);
                    }
                    //$scope.dataLoading = false;
                })
        };
    }])