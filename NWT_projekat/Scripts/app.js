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




angular.module('angularTranslateApp', ['pascalprecht.translate'])
.config(function ($translateProvider) {
    // Our translations will go in here

    $translateProvider.translations('bos_BOS', {
        'GREETING': 'Zdravo!',
        'BUTTON_BOS': 'Bosanski',
        'BUTTON_EN': 'Engleski',
        'LOGIN': 'Loguj se',
        'REGISTER': 'Registruj se',
        'WELCOME': 'Dobrodošli!',
        'LOGOUT': 'Odjavi se',
        'LOGGED_IN': 'Uspješno ste logovani!',
        'PromjenaLozinke': 'Promijeni lozinku'
    });
    // register english translation table
    $translateProvider.translations('en_EN', {
        'GREETING': 'Hello!',
        'BUTTON_BOS': 'Bosnian',
        'BUTTON_EN': 'English',
        'LOGIN': 'Login',
        'REGISTER': 'Registration',
        'WELCOME': 'Welcome!',
        'LOGOUT': 'Logout',
        'LOGGED_IN': 'You are logged in!',
        'PromjenaLozinke': 'Change password'
    });
    // which language to use?
    $translateProvider.preferredLanguage('bos_BOS');
});



angular.module('angularTranslateApp').controller('Ctrl', ['$translate', '$scope', function ($translate, $scope) {

   //$scope.changeLanguage = function () {
   //    $translate.uses(($translate.uses() === 'en_EN') ? 'bos_BOS' : 'en_EN');
   //};

   $scope.changeLanguage = function (key) {
              $translate.use(key);
          };

}]);

angular.module('myModule', ['ui.bootstrap']);

