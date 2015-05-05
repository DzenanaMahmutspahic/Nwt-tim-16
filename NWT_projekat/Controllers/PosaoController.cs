using NWT.Pomocnici;
using NWT_projekat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace NWT_projekat.Controllers
{
    public class PosaoController: ApiController {
        #region *** Fields ***

        private readonly DbPomocnik _dbPomocnik = null;

        #endregion

        #region *** Konstruktori ***

        /// <summary>
        /// Kreira novu instancu klase <see cref="PosaoController"/>
        /// </summary>
        public PosaoController() {
            _dbPomocnik = new DbPomocnik();
        }

        #endregion

        #region *** Metode ***

        //
        // GET: /Posao/

        /// <summary>
        /// Servis za dobavljanje posla po ID.
        /// </summary>
        /// <param name="ID">ID Posla</param>
        /// <returns>Objekat sa podacima o poslu ili null ako posao nije nađen</returns>
        [HttpGet]
        //[Description("Servis za dobavljanje posla po ID")]
        public Posao DajPosao(int ID) {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var q = _dbPomocnik.IzvrsiProceduru<Posao>(Konstante.DAJ_POSAO_ID, parametri);
            return q;
            /*Dženana Mahmutspahić:
             * OVAKO NE TREBA!
             * NEMOJTE SE ŠALITI.
             * 
             var p = DbPomocnik.IzvrsiProceduru(Konstante.DAJ_POSAO_ID, parametri).Rows[0];
            return new Posao
            {
                ID = Convert.ToInt32(p["ID"]),
                DTP = p["DTP"].ToString(),
                Stampa = p["Stampa"].ToString(),
                Knjigovodstvena_usluga = p["Knjigovodstvena_usluga"].ToString(),
                Vanjska_usluga = p["Vanjska_usluga"].ToString(),
                Montaza = p["Montaza"].ToString(),
                Rucni_rad = p["Rucni_rad"].ToString(),
                Status_posla = p["Status_posla"].ToString(),
                Repromaterijal = p["Repromaterijal"].ToString(),
                Materijalni_troskovi = p["Materijalni_troskovi"].ToString(),
                Rad = p["Rad"].ToString(),
                Popust = p["Popust"].ToString(),
                Ukupna_cijena = p["Ukupna_cijena"].ToString(),
                Cijena_komad = p["Cijena_komad"].ToString(),
                Vrsta_posla = p["Vrsta_posla"].ToString(),
                Obim_posla = p["Obim_posla"],
                Datum = p["Datum"],
                Papir = p["Papir"].ToString(),
                Dorada = p["Dorada"].ToString(),
                Montaza_posla = p["Montaza_posla"].ToString(),
                Ukupna_cijena_PDV = p["Ukupna_cijena_PDV"].ToString(),
                Cijena_komad_PDV = p["Cijena_komad_PDV"].ToString()
            };*/
        }

        [HttpGet]
        //[Description("Servis za dobavljanje poslova json")]
        public System.Net.Http.HttpResponseMessage DajPosaoJson(int ID) {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var q = _dbPomocnik.IzvrsiProceduru<Posao>(Konstante.DAJ_POSAO_ID, parametri);

            return new HttpResponseMessage() {
                Content = new JsonContent(q)
            };
        }


        [System.Web.Http.HttpPost]
        public Posao UnesiPosao(Posao p) {
            return _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DODAJ_POSAO, p).FirstOrDefault();
        }


        [System.Web.Http.HttpPost]
        //[Description("Servis za unos posla")]
        public System.Net.Http.HttpRequestMessage UnesiPosaoJson(Posao p) {
            var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DODAJ_POSAO, p).FirstOrDefault();

            return new HttpRequestMessage() {
                Content = new JsonContent(q)
            };
        }

        [HttpGet]
        //[Description("Servis za dobavljanje završenih poslova")]
        public List<Posao> DajZavrsenePoslove() {
            var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DAJ_ZAVRSENE_POSLOVE, null);
            return q;

        }

        [HttpGet]
        //[Description("Servis za dobavljanje završenih poslova")]
        public System.Net.Http.HttpResponseMessage DajZavrsenePosloveJson() {
            var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DAJ_ZAVRSENE_POSLOVE, null);

            return new HttpResponseMessage() {
                Content = new JsonContent(q)
            };
        }


        [System.Web.Http.HttpPost]
        //[Description("Servis za unos montaze")]
        public System.Net.Http.HttpRequestMessage UnesiMontazu(Montaza m)
        {
            var q = _dbPomocnik.IzvrsiProceduru<Montaza, Montaza>(Konstante.DODAJ_MONTAZU, m).FirstOrDefault();

            return new HttpRequestMessage()
            {
                Content = new JsonContent(q)
            };
        }

        [System.Web.Http.HttpPost]
        //[Description("Servis za unos repromaterijala")]
        public System.Net.Http.HttpRequestMessage UnesiRepromaterijal(Repromaterijal r)
        {
            var q = _dbPomocnik.IzvrsiProceduru<Repromaterijal, Repromaterijal>(Konstante.DODAJ_REPROMATERIJAL, r).FirstOrDefault();

            return new HttpRequestMessage()
            {
                Content = new JsonContent(q)
            };
        }


        [System.Web.Http.HttpPost]
        //[Description("Servis za unos knjigovodstvene dorade")]
        public System.Net.Http.HttpRequestMessage UnesiKnjigovodstvenuDoradu(Knjigovodstvena_dorada k)
        {
            var q = _dbPomocnik.IzvrsiProceduru<Knjigovodstvena_dorada, Knjigovodstvena_dorada>(Konstante.DODAJ_KNJIGOVODSTVENU_DORADU, k).FirstOrDefault();

            return new HttpRequestMessage()
            {
                Content = new JsonContent(q)
            };
        }

        [System.Web.Http.HttpPost]
        //[Description("Servis za unos rucnog rada")]
        public System.Net.Http.HttpRequestMessage UnesiRucniRad(Rucni_rad r)
        {
            var q = _dbPomocnik.IzvrsiProceduru<Rucni_rad, Rucni_rad>(Konstante.DODAJ_RUCNI_RAD, r).FirstOrDefault();

            return new HttpRequestMessage()
            {
                Content = new JsonContent(q)
            };
        }

        [System.Web.Http.HttpPost]
        //[Description("Servis za unos stampe")]
        public System.Net.Http.HttpRequestMessage UnesiStampu(Stampa s)
        {
            var q = _dbPomocnik.IzvrsiProceduru<Stampa, Stampa>(Konstante.DODAJ_STAMPU, s).FirstOrDefault();

            return new HttpRequestMessage()
            {
                Content = new JsonContent(q)
            };
        }

        [System.Web.Http.HttpPost]
        //[Description("Servis za unos vanjske usluge")]
        public System.Net.Http.HttpRequestMessage UnesiVanjskuUslugu(Vanjska_usluga v)
        {
            var q = _dbPomocnik.IzvrsiProceduru<Vanjska_usluga, Vanjska_usluga>(Konstante.DODAJ_VANJSKU_USLUGU, v).FirstOrDefault();

            return new HttpRequestMessage()
            {
                Content = new JsonContent(q)
            };
        }

        #endregion

    }
}
