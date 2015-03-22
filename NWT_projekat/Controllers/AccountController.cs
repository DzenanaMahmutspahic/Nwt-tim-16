using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWT_projekat.Controllers {
    public class AccountController: Controller {
        //
        // GET: /Account/

        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public Account Get(int? id=null) {
            return new Account { ID = id??0, Username = "dmahmutspahic", Datum = DateTime.Now };
        }

        /*[HttpGet]
        public Korisnik Get(int ID) {
            var K = new Korisnik() { Ime = "Dženana", Prezime = "Mahmutspahić", Pozicija = "Šefica" };
            return K;
        }*/

    }
}
