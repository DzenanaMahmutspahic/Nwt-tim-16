(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .directive('montazaDirektiva', function ($rootScope) {

          return {
              template: '\
              <table class="formular-sekcija table table-striped">\
                        <tr> <th> 2.MONTAZA</th> <th> &nbsp;</th> <th> Sati rada</th> <th> Ukupno</th> </tr>\
                        <tr>\
                            <td> Snimanje i obrada ploča 12 na sat</td>\
                            <td>\
                                <span>{{data.Montaza.Snimanje_materijal}}</span>\
                            </td>\
                            <td>\
                                <span>{{data.Montaza.Snimanje_sati}}</span>\
                            </td>\
                            <td align="right">\
                                <span>{{data.Montaza.Snimanje_cijena}}</span> <span>KM</span>\
                            </td>\
                        </tr>\
                        <tr>\
                            <td> Montaža</td>\
                            <td>\
                                <span>{{data.Montaza.Montaza_materijal}}</span>\
                            </td>\
                            <td>\
                                <span>{{data.Montaza.Montaza_sati}}</span>\
                            </td>\
                            <td align="right">\
                                <span>{{data.Montaza.Montaza_cijena}}</span> <span>KM</span>\
                            </td>\
                        </tr>\
                        <tr>\
                            <td> UKUPNO MONTAŽA</td>\
                            <td>\
                                <span>&nbsp;</span>\
                            </td>\
                            <td>\
                                <span>{{data.Montaza.Snimanje_sati + data.Montaza.Montaza_sati}}</span>\
                            </td>\
                            <td>\
                                <input autocomplete="off" ng-show="pokaziMontaza()" type="text" name="t3c10" style="width:100%" />\
                                <span>{{data.Montaza.Snimanje_cijena + data.Montaza.Montaza_cijena}}</span> <span>KM</span>\
                            </td>\
                        </tr>\
                    </table>'
          };
      });
})(window.angular);