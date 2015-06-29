(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
    //  .controller('userInfoDirektiva', ['$scope', '$rootScope', function ($scope, $rootScope) {
    //      $scope.user = $rootScope.globals.currentUser;

    //  }])
      .directive('adminDashboard', function ($rootScope) {
          var user = $rootScope.globals.currentUser;
          if ($rootScope.globals.currentUser < 3)
              return {};
          return {
              controller: ['$scope', '$rootScope', '$http', function ($scope, $rootScope, $http) {
                  if(true)
                      return;
                  $scope.showLoading = true;
                  $http.get('/api/Account/DajkorisnikeJson/' + $rootScope.globals.currentUser.ID + '?authInfo=' + $rootScope.globals.currentUser.authdata)
                  .success(function (response) {
                      $scope.users = response;
                      var i = 0;
                      for (i = 0; i < $scope.users.length; i++) {
                          $scope.users[i].unaprjediv = function () { return this.Pozicija < 3; }
                          $scope.users[i].unazadiv = function () { return this.Pozicija > 1; }
                      }
                      $scope.pozicijeEnum = pozicijeEnum;
                      $scope.BanujKorisnika = function (id) {
                          $scope.showLoading = true;
                          if (confirm('Da li ste sigurni da želite banovati ovog korisnika?')) {
                              $http.get('/api/Account/BanujKorisnikaJson/' + id + '?adminid=' + $rootScope.globals.currentUser.ID + '&authInfo=' + $rootScope.globals.currentUser.authdata)
                              .success(function (response) {
                                  var k = IndexOf($scope.users, function (user) { return user.ID == id });
                                  if (k >= 0)
                                      $scope.users[k].Banovan = response;
                                  $scope.showLoading = false;
                              })
                              .error(function (response) {
                                  //TODO: Ovdje neki bootstrap info za gresku oko banovanja
                                  $scope.showLoading = false;
                              })
                          }
                      }
                      $scope.OdbanujKorisnika = function (id) {
                          if (confirm('Da li ste sigurni da želite odbanovati ovog korisnika?')) {
                              $scope.showLoading = true;
                              $http.get('/api/Account/OdbanujKorisnikaJson/' + id + '?adminid=' + $rootScope.globals.currentUser.ID + '&authInfo=' + $rootScope.globals.currentUser.authdata)
                              .success(function (response) {
                                  var k = IndexOf($scope.users, function (user) { return user.ID == id });
                                  if (k >= 0)
                                      $scope.users[k].Banovan = response;
                                  $scope.showLoading = false;
                              })
                              .error(function (response) {
                                  //TODO: Ovdje neki bootstrap info za gresku oko odbanovanja
                                  $scope.showLoading = false;
                              })
                          }
                      }
                      $scope.UnaprijediKorisnika = function (id) {
                          $scope.showLoading = true;
                          if (confirm('Da li ste sigurni da želite unaprijediti ovog korisnika?')) {
                              $http.get('/api/Account/UnaprijediKorisnikaJson/' + id + '?adminid=' + $rootScope.globals.currentUser.ID + '&authInfo=' + $rootScope.globals.currentUser.authdata)
                              .success(function (response) {
                                  var k = IndexOf($scope.users, function (user) { return user.ID == id });
                                  if (k >= 0)
                                      $scope.users[k].Pozicija = response.pozicija;
                                  $scope.showLoading = false;
                              })
                              .error(function (response) {
                                  //TODO: Ovdje neki bootstrap info za gresku oko unapredjenja
                                  $scope.showLoading = false;
                              })
                          }
                      }
                      $scope.UnazadiKorisnika = function (id) {
                          if (confirm('Da li ste sigurni da želite unazaditi ovog korisnika?')) {
                              $scope.showLoading = true;
                              $http.get('/api/Account/UnazadiKorisnikaJson/' + id + '?adminid=' + $rootScope.globals.currentUser.ID + '&authInfo=' + $rootScope.globals.currentUser.authdata)
                              .success(function (response) {
                                  var k = IndexOf($scope.users, function (user) { return user.ID == id });
                                  if (k >= 0)
                                      $scope.users[k].Pozicija = response.pozicija;
                                  $scope.showLoading = false;
                              })
                              .error(function (response) {
                                  //TODO: Ovdje neki bootstrap info za gresku oko nazadovanja
                                  $scope.showLoading = false;
                              })
                          }
                      }
                      $scope.showLoading = false;
                  })
                  .error(function (response) {
                      //TODO: Neki bootstrap notification za gresku
                      $scope.showLoading = false;
                  })
              }],
              template: '<div ng-show="showLoading" style="position:fixed; left:0; top:0; width:100%; height:100%; background:rgba(18, 51, 84, 0.25)">\
                            <div style="position:relative; margin-left:auto; margin-right:auto; top:32%; width:35%; height:35%; background:green; padding:25px;">\
                                <h2><img src="../../../Images/301.GIF" /> Učitavanje zaposlenika </h2>\
                            </div>\
                        </div> \
\
            <div ng-repeat="user in users" style="border:3px solid black; margin:15px; padding:5px; display: inline-block;">\
                <h4>{{user.Ime}}&nbsp;{{user.Prezime}}</h4>\
                <span>pozicija: {{ pozicijeEnum.properties[user.Pozicija] }}</span>  \
                <form  name="form_banujKorisnika" ng-submit="BanujKorisnika(user.ID)" role="form">  \
                    <button type="submit" class="btn-danger" ng-hide="user.Banovan">Banuj</button>\
                </form> \
                <form  name="form_odbanujKorisnika" ng-submit="OdbanujKorisnika(user.ID)" role="form">  \
                    <button type="submit" class="btn-success" ng-show="user.Banovan">Odbanuj</button>\
                </form> \
                <table style="width:100%" ng-hide="user.Banovan"> \
                    <tr>  \
                        <td>  \
                            <form  name="form_unaprijediKorisnika" ng-submit="UnaprijediKorisnika(user.ID)" role="form"> \
                                <div  ng-show="user.unaprjediv()">\
                                    <button type="submit" class="btn-link" style="float:left;"> \
                                        <img src="Images/unaprijedi.png"/>Unaprijedi \
                                    </button> \
                                </div>\
                            </form> \
                        </td> \
                        <td> \
                            <form  name="form_unazadiKorisnika" ng-submit="UnazadiKorisnika(user.ID)" role="form">  \
                                <button type="submit" ng-show="user.unazadiv()" class="btn-link"><img src="Images/unazadi.png"/>Unazadi</button>\
                            </form> \
                        </td>  \
                    </tr>  \
                </table>  \
            </div>'
          };
      });
})(window.angular);