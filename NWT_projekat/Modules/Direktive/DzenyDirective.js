(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .controller('userInfoDirektiva', ['$scope', '$rootScope', function ($scope, $rootScope) {
          
      }])
      .directive('myProfile',  function ($rootScope) {
          return {
              template:
'<a href=\'index.html#/profil\'><img src=\'' + $rootScope.globals.currentUser.imgUrl + '\' width=64 height=64 />' +
'<span>' + $rootScope.globals.currentUser.username + '</span></a>'+
'<div ng-controller=\'Ctrl\'>\
        <form name=\'form_logout\' ng-submit=\'logout()\' role=\'form\'>\
            <button class=\'btn-link\' type="submit">{{ \'LOGOUT\' | translate }}</button>\
        </form>\
    </div>'
          };
      }); 
})(window.angular);
//comment 