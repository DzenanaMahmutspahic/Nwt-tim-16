using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NWT_projekat.Controllers {
    public class AccountController: ApiController {

        private readonly Konstante _konstante = new Konstante();

        /// <summary>
        /// Servis za dobavljanje korisnika po ID
        /// </summary>
        /// <param name="ID">ID Korisnika</param>
        /// <returns>Objekat sa podacima o korisniku ili null ako korisnik nije nađen</returns>
        [HttpGet]
        public Korisnik DajKorisnika(int ID) {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var k = DbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_ID, parametri).Rows[0];
            return new Korisnik{
                ID=Convert.ToInt32(k["ID"]),
                Ime=k["Ime"].ToString(),
                Password=k["Password"].ToString(),
                Pozicija=k["Pozicija"].ToString(),
                Prezime = k["Prezime"].ToString(),
                Username = k["Username"].ToString()
            };

        }

        /// <summary>
        /// Servis za prijavu na sistem.
        /// </summary>
        /// <param name="korisnik">Objekat sa popunjenom podacima o korisniku</param>
        /// <returns>Logičku vrijednost true ako je prijavljivanje uspješno</returns>
        [System.Web.Mvc.HttpPost]
        public bool Login(Korisnik korisnik) {
            var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", korisnik.Password}
            };
            return DbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_UNAME_PASS, parametri).Rows.Count == 1;
        }

        /// <summary>
        /// Servis za registraciju novog korisnika
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        public Korisnik Registracija(Korisnik korisnik) {
            var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", korisnik.Password},
                {"Ime", korisnik.Ime},
                {"Prezime", korisnik.Prezime},
                {"Pozicija", korisnik.Pozicija}
            };
            try {
                int ID = Convert.ToInt32(DbPomocnik.IzvrsiProceduru(Konstante.REGISTRUJ_KORISNIKA, parametri).Rows[0][0]);
                korisnik.ID = ID;
                return korisnik;
            } catch(Exception) {
            }
            return null;
        }
    }
}
