(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .controller('userInfoDirektiva', ['$scope', '$rootScope', function ($scope, $rootScope) {

      }])
      .directive('myProfile', function ($rootScope) {
          return {              
              controller: ('HomeController', ['$scope', '$rootScope', '$http', '$location', function ($scope, $rootScope, $http, $location) {
                  $scope.ime = $rootScope.globals.currentUser.ime + ' ' + $rootScope.globals.currentUser.prezime;
                  $scope.imgUrl = $rootScope.globals.currentUser.imgUrl;
                  ucitajGraf(3600);
              }]),
              template:
                  '<div ng-controller="HomeController"> \
<a href="index.html#/profil"><img src="{{ imgUrl }}" width=64 height=64 />' +
'<span></a><a href=\'index.html#/profil\'>{{ime}}</span></a>' +
'<div ng-controller=\'Ctrl\'>\
        <form name=\'form_logout\' ng-submit=\'logout()\' role=\'form\'>\
            <button class=\'btn-link\' type="submit">{{ \'LOGOUT\' | translate }}</button>\
        </form>\
    </div>\
</div>'
          };
      });
})(window.angular);
//comment 