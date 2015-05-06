'use strict';

// declare modules
angular.module('Authentication', []);
angular.module('Home', []);
angular.module('Posao', []);

angular.module('BasicHttpAuthExample', [
    'Authentication',
    'Home',
    'Posao',
    'ngRoute',
    'ngCookies'
])

.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/login', {
            controller: 'LoginController',
            templateUrl: 'modules/authentication/views/login.html',
            hideMenus: true
        })
        .when('/registration', {
            controller: 'RegistrationController',
            templateUrl: 'modules/authentication/views/Registration.html',
            hideMenus: true
        })

        .when('/resetPassword', {
            controller: 'ResetPasswordController',
            templateUrl: 'modules/authentication/views/ResetPassword.html',
            hideMenus: true
        })
        .when('/posao', {
            controller: 'PosaoController',
            templateUrl: 'modules/Posao/View/unos_posla.html',
            hideMenus: true
        })

        .when('/', {
            controller: 'HomeController',
            templateUrl: 'modules/home/views/home.html'
        })

        //.otherwise({ redirectTo: '/login' });
}])

.run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            if ($location.path() !== '/login' &&
                $location.path() !== '/registration' &&
                $location.path() !== '/resetPassword' &&
                $location.path() !== '/changePassword' &&
                $location.path() !== '/posao' &&
                !$rootScope.globals.currentUser) {
                $location.path('/login');
            }
        });
    }]);