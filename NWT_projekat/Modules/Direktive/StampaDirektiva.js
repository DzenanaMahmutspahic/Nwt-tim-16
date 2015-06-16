(function (angular) {
    'use strict';
    angular.module('BasicHttpAuthExample')
      .directive('stampaDirektiva', function ($rootScope) {

          return {
              template: '\
              <table class="formular-sekcija table table-striped">\
                        <tr> <th> 3. ŠTAMPA</th> <td> &nbsp</td> <td> Pranje</td> <td> Sati</td> <td> Sati rada</td> <td> Ukupno</td> </tr>\
                        <tr>\
                            <td> Priprema ČETVEROBOJNA</td>\
                            <td colspan="3"> \
                                <span>{{data.Stampa.Priprema4b_materijal}}</span> \
                            </td>\
                                <td><span>{{data.Stampa.Priprema4b_sati}}</span> \
                            </td>\
                                <td><span>{{data.Stampa.Priprema4b_cijena}}</span> \
                             </td>\
                        </tr>\
                        <tr>\
                            <td> GTO Četverobojni 4000/h</td>\
                            <td colspan="2">  \
                                <span>{{data.Stampa.Snimanje_materijal}}</span>\
                                </td>\
                            <td><span>{{data.Stampa.GTO1_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.GTO1_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.GTO1_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> Priprema B2</td> \
                            <td> PROVJERITI</td> \
                            <td><span>{{}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaB2_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaB2_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaB2_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> HD-B2 1/0 2500/h</td> \
                            <td colspan="2"> <input autocomplete="off" type="text" name="t5c13" ng-model="t5c13" style="width:100%" /> </td> \
                            <td><span>{{data.Stampa.HOB2_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.HOB2_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.HOB2_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> Priprema GTO</td> \
                            <td> PROVJERITI</td> \
                            <td><span>{{}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaGTO_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaGTO_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaGTO_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> GTO B3 1/0 3500/h</td> \
                            <td colspan="2"> <input autocomplete="off" type="text" name="t5c21" ng-model="t5c21" style="width:100%" /> </td> \
                            <td><span>{{data.Stampa.GTO2_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.GTO2_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.GTO2_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> Priprema numeracije i perforacije</td> \
                            <td colspan="2"><span>{{}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaNiG_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaNiG_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.PripremaNiG_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> Numeracija i perforacija GTO</td> \
                            <td colspan="2"> <span>{{data.Stampa.Numeracija_materijal}}</span>\</td>\
                            <td> 2000/h</td> \
                            <td><span>{{data.Stampa.Numeracija_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.Numeracija_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> GRAFOPRES</td> \
                            <td colspan="2"> <span>{{data.Stampa.Grafopres_materijal}}</span>\</td>\
                            <td> 2000/h</td> \
                            <td><span>{{data.Stampa.Grafopres_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.Grafopres_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td align="center"> XEIKON</td> \
                            <td colspan="3"> <span>{{data.Stampa.Xeicon_materijal}}</span>\</td>\
                            <td><span>{{data.Stampa.Xeicon_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.Xeicon_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td align="center"> XEROX</td> \
                            <td colspan="4"> <span>{{data.Stampa.Xerox_sati}}</span>\</td>\
                            <td><span>{{data.Stampa.Xerox_cijena}}</span>\</td>\
                        </tr> \
                        <tr> \
                            <td> UKUPNO ŠTAMPA</td> \
                            <td colspan="3"><span></span>\</td>\
                            <td> <span> \
{{data.Stampa.Priprema4b_sati + data.Stampa.GTO1_sati + data.Stampa.PripremaB2_sati + \
data.Stampa.HOB2_sati + data.Stampa.GTO2_sati + data.Stampa.PripremaGTO_sati + \
data.Stampa.PripremaNiG_sati + data.Stampa.Numeracija_sati + data.Stampa.Grafopres_sati + \
data.Stampa.Xeicon_sati + data.Stampa.Xerox_sati }} \
                            </span></td>\
                            <td><span> \
{{data.Stampa.Priprema4b_cijena + data.Stampa.GTO1_cijena + data.Stampa.PripremaB2_cijena + \
data.Stampa.HOB2_cijena + data.Stampa.GTO2_cijena + data.Stampa.PripremaGTO_cijena + \
data.Stampa.PripremaNiG_cijena + data.Stampa.Numeracija_cijena + data.Stampa.Grafopres_cijena + \
data.Stampa.Xeicon_cijena + data.Stampa.Xerox_cijena }} \
                            </span></td>\
                        </tr> \
                    </table>'
          };
      });
})(window.angular);