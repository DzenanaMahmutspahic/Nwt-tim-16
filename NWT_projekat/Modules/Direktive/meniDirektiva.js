(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .directive('meniDirektiva', function ($rootScope) {
          var logovan = false;
          if ($rootScope != null && $rootScope != undefined)
              if ($rootScope.globals != null && $rootScope.globals != undefined)
                  if ($rootScope.globals.currentUser != null && $rootScope.globals.currentUser != undefined)
                      if ($rootScope.globals.currentUser.username != null && $rootScope.globals.currentUser.username != undefined)
                          logovan = true;
          if (logovan) {
              return {
                  template:
'<table id="menu">\
    <tr>\
        <td align="center"><a href="Home/">Home</a></td>\
        <td align="center"><a href="Help/">API</a></td>\
        <td align="center"><a href="index.html#/">FrontPage</a></td>\
        <td align="center">\
            <a class="btn-link ng-scope" ng-click="changeLanguage(\'bos_BOS\')">\
                <img src="Images/ba.png" />\
            </a>\
        </td>\
        <td align="center">\
            <a class="btn-link ng-scope" ng-click="changeLanguage(\'en_EN\')">\
                <img src="Images/eng.png" />\
            </a>\
        </td>\
    </tr>\
</table>'
              };
          } else {
              return {
                  template:
'<table id="menu">\
    <tr>\
        <td align="center"><a href="Home/">Home</a></td>\
        <td align="center"><a href="Help/">API</a></td>\
        <td align="center"><a href="index.html#/">{{\'LOGIN\' | translate }}</a></td>\
        <td align="center"><a href="index.html#/registration">{{\'REGISTER\' | translate }}</a></td>\
        <td align="center">\
            <a class="btn-link ng-scope" ng-click="changeLanguage(\'bos_BOS\')">\
                <img src="Images/ba.png" />\
            </a>\
        </td>\
        <td align="center">\
            <a class="btn-link ng-scope" ng-click="changeLanguage(\'en_EN\')">\
                <img src="Images/eng.png" />\
            </a>\
        </td>\
    </tr>\
</table>'
              };
          }
      });
})(window.angular);