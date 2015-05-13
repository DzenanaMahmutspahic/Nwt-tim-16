'use strict';

//angular.module('BasicHttpAuthExample')
//.controller('LoginController',
//    ['$scope', '$rootScope', '$location', 'AuthenticationService',
//    function ($scope, $rootScope, $location, AuthenticationService) {
//        // reset login status
//        AuthenticationService.ClearCredentials();

//        $scope.login = function () {
//            $scope.dataLoading = true;
//            AuthenticationService.Login($scope.username, $scope.password, function (response) {
//                if (response.success) {
//                    AuthenticationService.SetCredentials($scope.username, $scope.password);
//                    $location.path('/');
//                } else {
//                    $scope.error = response.message;
//                    $scope.dataLoading = false;
                   
//                }
//            });
//        };
//    }]);
angular.module('BasicHttpAuthExample').directive('logovaniKorisnik', function () {
    return {
        template: 'Trenutni logovani korisnik je: {{username}}'
    };
});
    //novi sa rest servisom - proba
//angular.module('BasicHttpAuthExample')
app.controller('LoginController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService',
    function ($scope, $rootScope, $location, AuthenticationService) {
        // reset login status
        AuthenticationService.ClearCredentials();

        $scope.login = function () {
            $scope.dataLoading = true;
            AuthenticationService.Login($scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthenticationService.login($scope.username, $scope.password);

                    $location.path('/');
                } else {
                    $scope.error = response.message;
                    $scope.dataLoading = false;
                }
            });
        };
    }]);
// prebaceno u app.js
//app.controller('RegistrationController',
//    ['$scope', '$rootScope', '$location', '$sce', 'AuthenticationService',
//    function ($scope, $rootScope, $location, $sce, AuthenticationService) {

//        $scope.registration = function () {
//            $scope.dataLoading = true;
//            AuthenticationService.registracija($scope.name, $scope.lastname, $scope.email ,$scope.username, $scope.password, function (response) {
//                if (response.success) {
//                    AuthenticationService.SetCredentials($scope.name, $scope.lastname);
//                    alert('Email za potvrdu registracije je poslan. Provjerite Vaš inbox!');
//                    $location.path('/login');
//                } else {
//                    $scope.error = response.message;
//                    $scope.errorMessage = $sce.trustAsHtml(response.message);
//                    $scope.dataLoading = false;
//                }
//            });
//        };
//    }]);
//app.controller('RegistrationController',
//    ['$scope', '$rootScope', '$location', '$sce', 'AuthenticationService',
//    function ($scope, $rootScope, $location, $sce, AuthenticationService) {

//        $scope.submitRegistration = function () {
//            $scope.dataLoading = true;
//            if ($scope.password != $scope.password_verify) {
//                $scope.error = "Razlicite vrijednosti lozinke!";
//                $scope.dataLoading = false;
//            } else {
//                AuthenticationService.registracija($scope.name, $scope.lastname, $scope.email, $scope.username, $scope.password, function (response) {
//                    if (response.success) {
//                        AuthenticationService.SetCredentials($scope.name, $scope.lastname);
//                        alert('Email za potvrdu registracije je poslan. Provjerite Vaš inbox!');
//                        $location.path('/login');
//                    } else {
//                        $scope.error = response.message;
//                        $scope.errorMessage = $sce.trustAsHtml(response.message);
//                        $scope.dataLoading = false;
//                    }
//                });
//            }
//        };
//    }]);

//angular.module('BasicHttpAuthExample').controller('ResetPasswordController',
//    ['$scope', '$rootScope', '$location', 'AuthenticationService',
//    function ($scope, $rootScope, $location, AuthenticationService) {
       
//        AuthenticationService.ClearCredentials();

//        $scope.reset = function () {
//            $scope.dataLoading = true;
//            AuthenticationService.Reset($scope.email, function (response) {
//                alert(response.success);
//                if (response.success) {
//                    AuthenticationService.SetCredentials($scope.email);
//                    alert('Vaša šifra je poslana na Email adresu koju ste unijeli. Provjerite poštu!');
//                    $location.path('/login');
//                } else {
//                    alert(response.message);
//                    if (response.message === undefined || response.error === null || response.message == '')
//                        $scope.error = 'Desila se greška u promjeni lozinke. Kontaktirajte Administratora za detalje.';
//                    else
//                        $scope.error = response.message;
//                    $scope.dataLoading = false;
//                }
//            });
//        };
//    }]);

   
