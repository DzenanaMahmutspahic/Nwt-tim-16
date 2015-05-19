(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .directive('vanjskaUslugaDirektiva', function ($rootScope) {

          return {
              template: '\
              <table class="ormular-sekcija table table-striped"  ng-hide="pokaziVanjskuUslugu()">\
                        <tr>\
                            <th> 4. VANjSKA USLUGA</th>\
                            <td> &nbsp;</td>\
                            <td> &nbsp;</td>\
                            <td> &nbsp;</td>\
                            <td> &nbsp;</td>\
                        </tr>\
                        <tr>\
                            <td> &nbsp</td>\
                            <td> Obracun Kalkulacije</td>\
                            <td> <span>{{data.VanjskaUsluga.Obracun_kalkulacije_materijal}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Obracun_kalkulacije_sati}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Obracun_kalkulacije_cijena}}</span> </td>\
                        </tr>\
                        <tr>\
                            <td> prevoz u gradu</td>\
                            <td> <span>{{}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Prevoz_materijal}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Prevoz_sati}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Prevoz_cijena}}</span> </td>\
                        </tr>\
                        <tr>\
                            <td> UKUPNO Vanjske Usluge</td>\
                            <td colspan="2"> <span>{{}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Obracun_kalkulacije_sati + data.VanjskaUsluga.Prevoz_sati}}</span> </td>\
                            <td> <span>{{data.VanjskaUsluga.Obracun_kalkulacije_cijena + data.VanjskaUsluga.Prevoz_cijena}}</span> </td>\
                        </tr>\
                    </table>'
          };
      });
})(window.angular);