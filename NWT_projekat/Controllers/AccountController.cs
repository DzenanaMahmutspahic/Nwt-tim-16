using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NWT_projekat.Controllers {
    public class AccountController: ApiController {
        
        /* [HttpGet]
        public Account Get(int? id=null) {
            return new Account { ID = id??0, Username = "dmahmutspahic", Datum = DateTime.Now };
        }*/

        public Korisnik Get(int? ID=null) {
            var K = new Korisnik() { Ime = "Dženana", Prezime = "Mahmutspahić", Pozicija = "Šefica" };
            return K;
        }

    }
}
