using Newtonsoft.Json;
using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace NWT_projekat.Controllers {
    public class AccountController: System.Web.Http.ApiController {

        private readonly Konstante _konstante = new Konstante();

        /// <summary>
        /// Servis za dobavljanje korisnika po ID
        /// </summary>
        /// <param name="ID">ID Korisnika</param>
        /// <returns>Objekat sa podacima o korisniku ili null ako korisnik nije nađen</returns>
        [System.Web.Mvc.HttpGet]
        public Korisnik DajKorisnikaXml(int ID) {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var k = DbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_ID, parametri).Rows[0];
            return new Korisnik {
                ID = Convert.ToInt32(k["ID"]),
                Ime = k["Ime"].ToString(),
                Password = k["Password"].ToString(),
                Pozicija = k["Pozicija"].ToString(),
                Prezime = k["Prezime"].ToString(),
                Username = k["Username"].ToString()
            };

        }

        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage DajKorisnikaJson(int ID) {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var k = DbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_ID, parametri).Rows[0];
            var response = new Korisnik {
                ID = Convert.ToInt32(k["ID"]),
                Ime = k["Ime"].ToString(),
                Password = k["Password"].ToString(),
                Pozicija = k["Pozicija"].ToString(),
                Prezime = k["Prezime"].ToString(),
                Username = k["Username"].ToString()
            };
            return new HttpResponseMessage() {
                Content = new JsonContent(response)
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
        [System.Web.Mvc.HttpPost]
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

        /// <summary>
        /// Servis za registraciju novog korisnika
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public System.Net.Http.HttpResponseMessage RegistracijaJson(Korisnik korisnik) {
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
                return new HttpResponseMessage() {
                    Content = new JsonContent(ID != 0 )
                };
            } catch(Exception ex) {
                return new HttpResponseMessage() {
                    Content = new JsonContent(ex.Message)
                };
            }
        }




        public class JsonContent: HttpContent {

            private readonly MemoryStream _Stream = new MemoryStream();
            public JsonContent(object value) {

                Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var jw = new JsonTextWriter(new StreamWriter(_Stream));
                jw.Formatting = Formatting.Indented;
                var serializer = new JsonSerializer();
                serializer.Serialize(jw, value);
                jw.Flush();
                _Stream.Position = 0;

            }
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context) {
                return _Stream.CopyToAsync(stream);
            }

            protected override bool TryComputeLength(out long length) {
                length = _Stream.Length;
                return true;
            }
        }
    }
}
