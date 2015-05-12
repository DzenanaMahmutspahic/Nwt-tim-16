'use strict';

angular.module('Posao')
.factory('PosaoService',
        function (Base64, $http, $cookieStore, $rootScope, $timeout) {
            var service = {};
            service.dajPosao = function (posaoId, callback) {
                $http.get('/api/Posao/DajPosaoJson/' + posaoId)
               .success(function (response) {
                   alert(response);
                   var a = { success: true, data: response };
                   callback(a);
               })
                .error(function (data, status, headers, config) {
                    alert("Login failed");
                });
            };
            return service;
        }
    );

angular.module('Posao')
.factory('PosaoService',
    ['Base64', '$http', '$cookieStore', '$rootScope', '$timeout',
    function (Base64, $http, $cookieStore, $rootScope, $timeout) {
        var service = {};
        service.dodajMontazu = function (sM, sC, sS, mM, mS, mC, callback) {
            $http.post('/api/Posao/UnesiMontazuJson', {
                Snimanje_materijal: sM,
                Snimanje_sati: sC,
                Snimanje_cijena: sS,
                Montaza_materijal: mM,
                Montaza_cijena: mC,
                Montaza_sati: mS,
                Komentar: "",
                Korisnik_ID: 1
            })
            .success(function (response) {
                var a = { success: true, data: response };
                callback(a);
            })
            .error(function (data, status, headers, config) {
                alert("Neuspjelo postavljanje Montaze.");
            });
        };
        service.dodajDTP = function (sM, sC, sS, mM, mS, mC, callback) {
            $http.post('/api/Posao/UnesiDtpJson', {
                Sofp_materijal: sM,
                Sofp_sati: sC,
                Sofp_cijena: sS,
                Fotografija_materijal: mM,
                Fotografija_cijena: mC,
                Fotografija_sati: mS,
                Komentar: "",
                Korisnik_ID: 1
            })
            .success(function (response) {
                var a = { success: true, data: response };
                callback(a);
            })
            .error(function (data, status, headers, config) {
                alert("Neuspjelo postavljanje DTP.");
            });
        };
        return service;
    }])








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