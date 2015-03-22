using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NWT_projekat.Controllers {
    public class AccountController: ApiController {

        /* [HttpGet]
        public Account Get(int? id=null) {
            return new Account { ID = id??0, Username = "dmahmutspahic", Datum = DateTime.Now };
        }*/

        public Korisnik Get(int? ID = null) {
            var K = new Korisnik() { Ime = "Dženana", Prezime = "Mahmutspahić", Pozicija = "Šefica" };
            return K;
        }

        [System.Web.Mvc.HttpPost]
        public bool Login(Korisnik korisnik) {
            return DbPomocnik.IzvrsiProceduru("Login", new Dictionary<string, object>()).Rows.Count == 1;
        }

    }
}
