(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .directive('dtpDirektiva', function ($rootScope) {

          return {
              template: '\
              <table class="formular-sekcija" id="T1">\
                        <tr> <th> 1.DTP</th> <th> Materijal</th> <th> Sati rada</th> <th> Ukupno</th> </tr>\
                        <tr>\
                            <td> Sken.i obrada fotog.-prelom</td>\
                            <td>\
                                <span>{{data.DTP.Sofp_materijal}}</span>\
                            </td>\
                            <td>\
                                <span>{{data.DTP.Sofp_sati}}</span>\
                            </td>\
                            <td align="right">\
                                <span>{{data.DTP.Sofp_cijena}}</span>\
                                <span class="table-cell borderless">KM</span>\
                            </td>\
                        </tr>\
                        <tr>\
                            <td> Fotografija</td>\
                            <td>\
                                <span>{{data.TP.Fotografija_materijal}}</span>\
                            </td>\
                            <td>\
                                <span>{{data.DTP.Fotografija_sati}}</span>\
                            </td>\
                            <td align="right">\
                                <span class="table-cell borderless">{{data.DTP.Fotografija_cijena}}</span>\
                                <span>KM</span>\
                            </td>\
                        </tr>\
                        <tr>\
                            <td> UKUPNO DTP</td>\
                            <td> &nbsp;</td>\
                            <td>\
                                <span>{{data.DTP.Sofp_sati + data.DTP.Fotografija_sati}}</span>\
                            </td>\
                            <td>\
                                <span class="table-cell borderless">{{data.DTP.Sofp_cijena + data.DTP.Fotografija_cijena}}</span>\
                                <span class="table-cell borderless">KM</span>\
                            </td>\
                        </tr>\
                    </table>'
          };
      });
})(window.angular);