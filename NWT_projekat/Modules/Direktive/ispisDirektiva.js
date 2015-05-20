(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .controller('ispisDirektiva', ['$scope', '$rootScope', function ($scope, $rootScope) {
      }])
      .directive('kontaktInformacije', function ($rootScope) {
          return {
              template:
'<pre> KONTAKT INFORMACIJE Grafičko izdavačko preduzeće Grafika Šaran d.o.o ' +
          'Srđana Aleksića 28, 71000 Sarajevo ' +
          '<br>Centrala: +387 33 26 26 26, Ponude: + 387 33 26 26 24 ' +
          'DTP: +387 33 26 26 28, Proizvodnja: + 387 33 26 26 25 ' +
          'Fax. : +387 33 26 26 29; E-mail: grafikas@bih.net.ba </pre>'
          };
      });
})(window.angular);
//comment 