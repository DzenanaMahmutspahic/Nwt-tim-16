using NWT.Pomocnici;
using NWT_projekat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//using System.Web.Mvc;

namespace NWT_projekat.Controllers
{
    public class PosaoController : ApiController
    {
        //
        // GET: /Posao/


        /// <summary>
        /// Servis za dobavljanje posla po ID.
        /// </summary>
        /// <param name="ID">ID Posla</param>
        /// <returns>Objekat sa podacima o poslu ili null ako posao nije nađen</returns>
        [HttpGet]
        //[Description("Servis za dobavljanje posla po ID")]
        public Posao DajPosao(int ID)
        {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var q = DbPomocnik.IzvrsiProceduru<Posao>(Konstante.DAJ_POSAO_ID, parametri);
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

        [System.Web.Http.HttpPost]
        public Posao UnesiPosao(Posao p)
        {
            return DbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DODAJ_POSAO, p).FirstOrDefault();
        }


        [HttpGet]
        //[Description("Servis za dobavljanje završenih poslova")]
        public List<Posao> DajZavrsenePoslove()
        {
            var q = DbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DAJ_ZAVRSENE_POSLOVE, null);
            return q;
            
        }

        [System.Web.Http.HttpPost]
        public DTP UnesiDTP(DTP p)
        {
            return DbPomocnik.IzvrsiProceduru<DTP, DTP>(Konstante.DODAJ_DTP, p).FirstOrDefault();
        }

    }
}
