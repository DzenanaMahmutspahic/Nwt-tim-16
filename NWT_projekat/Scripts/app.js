'use strict';

// declare modules
////angular.module('Authentication', []);
////angular.module('Home', []);
////angular.module('Posao', []);
////angular.module('myModule', ['ui.bootstrap']);
////angular.module('angularTranslateApp', [])

var app = angular.module('BasicHttpAuthExample', [
    //'Authentication',
    //'Home',
    //'Posao',
    'pascalprecht.translate',
    'ngRoute',
    'ngCookies'
 //   'angularFileUpload'

    
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
        .when('/upload', {
            controller: 'UploadFileController',
            templateUrl: 'modules/Upload/View/uploadFile.html',
            hideMenus: true
        })
        .when('/profil', {
            controller: 'Ctrl',
            templateUrl: 'modules/home/views/Profil.html',
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
                $location.path() !== '/upload' &&
                $location.path() !== '/profil' &&
                !$rootScope.globals.currentUser) {
                $location.path('/login');
            }
        });
    }]);


app.controller('LoginController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService',
    function ($scope, $rootScope, $location, AuthenticationService) {

        $scope.login = function () {
            $scope.dataLoading = true;
            // reset login status
            AuthenticationService.ClearCredentials();
            AuthenticationService.Login($scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthenticationService.SetCredentials($scope.username, $scope.password, response.imageUrl);
                    $location.path('/');
                } else {
                    $scope.error = response.message;
                    $scope.dataLoading = false;

                }
            });
        };
    }]);

app.controller('RegistrationController',
    ['$scope', '$rootScope', '$location', '$sce', 'AuthenticationService',
    function ($scope, $rootScope, $location, $sce, AuthenticationService) {

        $scope.registration = function () {
            $scope.dataLoading = true;
            AuthenticationService.registracija($scope.name, $scope.lastname, $scope.email, $scope.username, $scope.password, function (response) {
                if (response.success) {
                    alert('Email za potvrdu registracije je poslan. Provjerite Vaš inbox!');
                    $location.path('/login');
                } else {
                    $scope.error = response.message;
                    $scope.errorMessage = $sce.trustAsHtml(response.message);
                    $scope.dataLoading = false;
                }
            });
        };
        $scope.submitRegistration = function () {
            $scope.dataLoading = true;
            if ($scope.password != $scope.password_verify) {
                $scope.error = "Razlicite vrijednosti lozinke!";
                $scope.dataLoading = false;
            } else {
                AuthenticationService.registracija($scope.name, $scope.lastname, $scope.email, $scope.username, $scope.password, function (response) {
                    if (response.success) {
                        alert('Email za potvrdu registracije je poslan. Provjerite Vaš inbox!');
                        $location.path('/login');
                    } else {
                        $scope.error = response.message;
                        $scope.errorMessage = $sce.trustAsHtml(response.message);
                        $scope.dataLoading = false;
                    }
                });
            }
            $scope.dataLoading = false;
        };
    }])
.controller('ResetPasswordController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService',
    function ($scope, $rootScope, $location, AuthenticationService) {

        $scope.reset = function () {
            $scope.dataLoading = true;
            AuthenticationService.ClearCredentials();
            AuthenticationService.Reset($scope.email, function (response) {
                alert(response.success);
                if (response.success) {
                    alert('Vaša šifra je poslana na Email adresu koju ste unijeli. Provjerite poštu!');
                    $location.path('/login');
                } else {
                    alert(response.message);
                    if (response.message === undefined || response.error === null || response.message == '')
                        $scope.error = 'Desila se greška u promjeni lozinke. Kontaktirajte Administratora za detalje.';
                    else
                        $scope.error = response.message;
                    $scope.dataLoading = false;
                }
            });
        };
    }])


//app.controller('UploadFileController', ['$scope', $upload, function ($scope, $upload) {
//        $scope.$watch('files', function () {
//            $scope.upload($scope.files);
//        });
//        $scope.log = '';

//        $scope.upload = function (files) {
//            if (files && files.length) {
//                for (var i = 0; i < files.length; i++) {
//                    var file = files[i];
//                    Upload
//                        .upload({
//                            url: 'https://angular-file-upload-cors-srv.appspot.com/upload',
//                            fields: {
//                                'username': $scope.username
//                            },
//                            file: file
//                        })
//                       .progress(function (evt) {
//                           var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
//                           $scope.log = 'progress: ' + progressPercentage + '% ' +
//                                       evt.config.file.name + '\n' + $scope.log;
//                       })
//                        .success(function (data, status, headers, config) {
//                            $scope.log = 'file ' + config.file.name + 'uploaded. Response: ' + JSON.stringify(data) + '\n' + $scope.log;
//                            $scope.$apply();
//                        });
//                }
//            }
//        };
//}]);

.controller('UploadFileController', ['$scope', '$http', function ($scope, $http) {
    //var myModelObj = {};

    $scope.onFileSelect = function ($files, myModelObj) {
        $http.uploadFile({
            url: 'D:\\',
            file: $file[0] // for single file
            //files: $files  // for multiple files
        }).then(function (data) {
            myModelObj.fileId = data;
        });
        //return myModelObj;
    }
}]);

app.controller('PosaoController', []);
app.factory('AuthenticationService',
    ['Base64', '$http', '$cookieStore', '$rootScope', '$timeout',
    function (Base64, $http, $cookieStore, $rootScope, $timeout) {
        var service = {};
        service.Login = function (username, password, callback) {

            $http.get('/api/Account/DajPutanju?Username=' + username).success(
                function (imgUrl) {
                    $http.post('/api/Account/Login', { username: username, password: password })
                       .success(function (response) {
                           if (response !== true) {
                               //response.message = 'Username or password is incorrect';
                               callback({ success: false, message: 'Wrong credentials!' });
                           } else {
                               var newResponse = { success: true, imageUrl:imgUrl };
                               callback(newResponse);
                           }
                       })
                    .error(function (data, status, headers, config) {
                        alert("Login failed");
                    }
                    )
                }
            );
        };
        service.registracija = function (name, lastname, email, username, password, callback) {
            $http.post('/api/Account/RegistracijaJson', { username: username, password: password, ime: name, prezime: lastname, Email: email })
               .success(function (response) {
                   if (response !== true) {
                       callback({ success: false, message: response });
                   } else {
                       var newResponse = { success: true };
                       callback(newResponse);
                   }
               })
            .error(error12345(data, status, headers, config));
        };

        function error12345(data, status, headers, config) {
            alert("Registration failed");
        }

        service.SetCredentials = function (username, password, imageUrl) {
            var authdata = Base64.encode(username + ':' + password);

            $rootScope.globals = {
                currentUser: {
                    username: username,
                    authdata: authdata,
                    imgUrl: imageUrl
                }
            };

            $http.defaults.headers.common['Authorization'] = 'Basic ' + authdata; //jshint ignore:line
            $cookieStore.put('globals', $rootScope.globals);
        };

        service.ClearCredentials = function () {
            $rootScope.globals = {};
            $cookieStore.remove('globals');
            $http.defaults.headers.common.Authorization = 'Basic ';
        };
        //RESET SERVICE
        service.Reset = function (Email, callback) {
            $http.post('/api/Account/PosaljiLozinkuJson', { Email: Email })
               .success(function (response) {
                   if (response !== true) {
                       callback({ success: false, message: response });
                   }
                   else {
                       var newResponse = { success: true };
                       callback(newResponse);
                   }
               })
            .error(function () {
                alert("Reset failed");
            }
            );
        };
        return service;
    }]);





app
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
        'PromjenaLozinke': 'Promijeni lozinku',
        'CHANGEPICTURE': 'Promijeni sliku'
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
        'PromjenaLozinke': 'Change password',
        'CHANGEPICTURE': 'Change picture'
    });
    // which language to use?
    $translateProvider.preferredLanguage('bos_BOS');
});


app.controller('Ctrl', ['$translate', '$scope', '$rootScope', '$cookieStore', '$location',
    function ($translate, $scope, $rootScope, $cookieStore, $location) {

    //$scope.changeLanguage = function () {
    //    $translate.uses(($translate.uses() === 'en_EN') ? 'bos_BOS' : 'en_EN');
    //};

    $scope.changeLanguage = function (key) {
        $translate.use(key);
    };
    $scope.logout = function () {
        $rootScope.globals = {};
        $cookieStore.remove('globals');
        $location.path('/login');
    };

}]);
app
.factory('Base64', function () {
    /* jshint ignore:start */

    var keyStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';

    return {
        encode: function (input) {
            var output = "";
            var chr1, chr2, chr3 = "";
            var enc1, enc2, enc3, enc4 = "";
            var i = 0;

            do {
                chr1 = input.charCodeAt(i++);
                chr2 = input.charCodeAt(i++);
                chr3 = input.charCodeAt(i++);

                enc1 = chr1 >> 2;
                enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                enc4 = chr3 & 63;

                if (isNaN(chr2)) {
                    enc3 = enc4 = 64;
                } else if (isNaN(chr3)) {
                    enc4 = 64;
                }

                output = output +
                    keyStr.charAt(enc1) +
                    keyStr.charAt(enc2) +
                    keyStr.charAt(enc3) +
                    keyStr.charAt(enc4);
                chr1 = chr2 = chr3 = "";
                enc1 = enc2 = enc3 = enc4 = "";
            } while (i < input.length);

            return output;
        },

        decode: function (input) {
            var output = "";
            var chr1, chr2, chr3 = "";
            var enc1, enc2, enc3, enc4 = "";
            var i = 0;

            //remove all characters that are not A-Z, a-z, 0-9, +, /, or =
            var base64test = /[^A-Za-z0-9\+\/\=]/g;
            if (base64test.exec(input)) {
                window.alert("There were invalid base64 characters in the input text.\n" +
                    "Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n" +
                    "Expect errors in decoding.");
            }
            input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

            do {
                enc1 = keyStr.indexOf(input.charAt(i++));
                enc2 = keyStr.indexOf(input.charAt(i++));
                enc3 = keyStr.indexOf(input.charAt(i++));
                enc4 = keyStr.indexOf(input.charAt(i++));

                chr1 = (enc1 << 2) | (enc2 >> 4);
                chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                chr3 = ((enc3 & 3) << 6) | enc4;

                output = output + String.fromCharCode(chr1);

                if (enc3 != 64) {
                    output = output + String.fromCharCode(chr2);
                }
                if (enc4 != 64) {
                    output = output + String.fromCharCode(chr3);
                }

                chr1 = chr2 = chr3 = "";
                enc1 = enc2 = enc3 = enc4 = "";

            } while (i < input.length);

            return output;
        }
    };

    /* jshint ignore:end */
})



    .factory('dataFactory', ['$http', function ($http) {

        var urlBase = '/api/Korisnik';
        var dataFactory = {};

        dataFactory.Login = function () {
            return $http.get(urlBase);
        };
    }])



    .service('dataService', ['$http', function ($http) {

        var urlBase = '/api/Korisnik';

        this.Login = function () {
            return $http.get(urlBase);
        };

    }]);