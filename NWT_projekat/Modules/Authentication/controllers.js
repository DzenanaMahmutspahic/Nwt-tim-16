'use strict';

angular.module('Authentication')

.controller('LoginController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService',
    function ($scope, $rootScope, $location, AuthenticationService) {
        // reset login status
        AuthenticationService.ClearCredentials();

        $scope.login = function () {
            $scope.dataLoading = true;
            AuthenticationService.Login($scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthenticationService.SetCredentials($scope.username, $scope.password);
                    $location.path('/');
                } else {
                    $scope.error = response.message;
                    $("#errorMessage").val(response.message);
                    $scope.dataLoading = false;
                }
            });
        };
    }])


    ////novi sa rest servisom - proba
    //.controller('LoginController',
    //['$scope', '$rootScope', '$location', 'AuthenticationService',
    //function ($scope, $rootScope, $location, AuthenticationService) {
    //    // reset login status
    //    AuthenticationService.ClearCredentials();

    //    $scope.login = function () {
    //        $scope.dataLoading = true;
    //        AuthenticationService.Login($scope.username, $scope.password, function (response) {
    //            if (response.success) {
    //                AuthenticationService.login($scope.username, $scope.password);
                    
    //                $location.path('/');
    //            } else {
    //                $scope.error = response.message;
    //                $scope.dataLoading = false;
    //            }
    //        });
    //    };
    //}])

.controller('RegistrationController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService',
    function ($scope, $rootScope, $location, AuthenticationService) {
        // reset login status
        AuthenticationService.ClearCredentials();

        $scope.registration = function () {
            $scope.dataLoading = true;
            AuthenticationService.Login($scope.name, $scope.lastname, $scope.email ,$scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthenticationService.SetCredentials($scope.name, $scope.lastname, $scope.email, $scope.username, $scope.password   );
                    $location.path('/');
                } else {
                    $scope.error = response.message;
                    $scope.dataLoading = false;
                }
            });
        };
    }]);