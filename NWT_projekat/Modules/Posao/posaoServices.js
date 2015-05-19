'use strict';

angular.module('BasicHttpAuthExample')
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

angular.module('BasicHttpAuthExample')
.factory('PosaoService',
    ['Base64', '$http', '$cookieStore', '$rootScope', '$timeout',
    function (Base64, $http, $cookieStore, $rootScope, $timeout) {
        var service = {};
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
        service.dodajStampu = function (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15,
            p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, callback) {
            $http.post('/api/Posao/UnesiStampuJson', {
                Priprema4b_materijal: p1,
                Priprema4b_sati: p2,
                Priprema4b_cijena: p3,
                GTO1_materijal: p4,
                GTO1_sati: p5,
                GTO1_cijena: p6,
                PripremaB2_materijal: p7,
                PripremaB2_sati: p8,
                PripremaB2_cijena: p9,
                HOB2_materijal: p10,
                HOB2_sati: p11,
                HOB2_cijena: p12,
                GTO2_materijal: p13,
                GTO2_sati: p14,
                GTO2_cijena: p15,
                PripremaGTO_materijal: p16,
                PripremaGTO_sati: p17,
                PripremaGTO_cijena: p18,
                PripremaNiG_materijal: p19,
                PripremaNiG_sati: p20,
                PripremaNiG_cijena: p21,
                Numeracija_materijal: p22,
                Numeracija_sati: p23,
                Numeracija_cijena: p24,
                Grafopres_materijal: p25,
                Grafopres_sati: p26,
                Grafopres_cijena: p27,
                Xeicon_materijal: p28,
                Xeicon_sati: p29,
                Xeicon_cijena: p30,
                Xerox_materijal: p31,
                Xerox_sati: p32,
                Xerox_cijena: p33,
                Komentar: "",
                Korisnik_ID: 1
            })
            .success(function (response) {
                var a = { success: true, data: response };
                callback(a);
            })
            .error(function (data, status, headers, config) {
                alert("Neuspjelo postavljanje Štampe.");
            });
        };
        service.dodajVanjskuUslugu = function (okM, okC, okS, pM, pS, pC, callback) {
            $http.post('/api/Posao/UnesiVanjskuUsluguJson', {
                Obracun_kalkulacije_materijal: okM,
                Obracun_kalkulacije_sati: okC,
                Obracun_kalkulacije_cijena: okS,
                Prevoz_materijal: pM,
                Prevoz_sati: pS,
                Prevoz_cijena: pC,
                Komentar: "",
                Korisnik_ID: 1
            })
            .success(function (response) {
                var a = { success: true, data: response };
                callback(a);
            })
            .error(function (data, status, headers, config) {
                alert("Neuspjelo postavljanje Vanjske usluge.");
            });
        };
        service.dodajKnjigovDoradu = function (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15,
            p16, p17, p18, p19, p20, p21, callback) {
            $http.post('/api/Posao/UnesiKnjigovodstvenuDoraduJson', {
                Noz_materijal: p1,
                Noz_sati: p2,
                Noz_cijena: p3,
                Falc_materijal: p4,
                Falc_sati: p5,
                Falc_cijena: p6,
                Klamerica_materijal: p7,
                Klamerica_sati: p8,
                Klamerica_cijena: p9,
                Perforirka_materijal: p10,
                Perforirka_sati: p11,
                Perforirka_cijena: p12,
                Plastificiranje_materijal: p13,
                Plastificiranje_sati: p14,
                Plastificiranje_cijena: p15,
                Blinder_materijal: p16,
                Blinder_sati: p17,
                Blinder_cijena: p18,
                Spiralni_materijal: p19,
                Spiralni_sati: p20,
                Spiralni_cijena: p21,
                Komentar: "",
                Korisnik_ID: 1
            })
            .success(function (response) {
                var a = { success: true, data: response };
                callback(a);
            })
            .error(function (data, status, headers, config) {
                alert("Neuspjelo postavljanje Knjigovodstvene dorade.");
            });
        };
        service.dodajRucniRad = function (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, callback) {
            $http.post('/api/Posao/UnesiRucniRadJson', {
                Slaganje_materijal: p1,
                Slaganje_sati: p2,
                Slaganje_cijena: p3,
                Savijanje_materijal: p4,
                Savijanje_sati: p5,
                Savijanje_cijena: p6,
                Lijepljenje_materijal: p7,
                Lijepljenje_sati: p8,
                Lijepljenje_cijena: p9,
                Pakovanje_materijal: p10,
                Pakovanje_sati: p11,
                Pakovanje_cijena: p12,
                Razno_materijal: p13,
                Razno_sati: p14,
                Razno_cijena: p15,
                Komentar: "",
                Korisnik_ID: 1
            })
            .success(function (response) {
                var a = { success: true, data: response };
                callback(a);
            })
            .error(function (data, status, headers, config) {
                alert("Neuspjelo postavljanje Ručnog Rada.");
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