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
using System.Net.Mail;
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
                {"Email", korisnik.Email},
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
            Guid tmpGuid = Guid.NewGuid();
            var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", korisnik.Password},
                {"Ime", korisnik.Ime},
                {"Prezime", korisnik.Prezime},
                {"Email", korisnik.Email},
                {"GUID", tmpGuid.ToString().ToLower()}
            };
            try {
                int ID = Convert.ToInt32(DbPomocnik.IzvrsiProceduru(Konstante.REGISTRUJ_KORISNIKA, parametri).Rows[0][0]);
                korisnik.ID = ID;

                SendEmail("Potvrda Registracije", string.Format(Konstante.REGISTRACIJA_TEMPLATE, korisnik.ID, tmpGuid), korisnik.Email);

                return new HttpResponseMessage() {
                    Content = new JsonContent(ID != 0)
                };
            } catch(Exception ex) {
                return new HttpResponseMessage() {
                    Content = new JsonContent(ex.Message)
                };
            }
        }


        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage PotvrdaRegistracijeJson(int id, string guid) {
            var parametri = new Dictionary<string, object>{
                {"ID", id},
                {"GUID", guid.ToLower()}
            };
            var response = DbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.POTVRDI_REGISTRACIJU, parametri);

            try {
                return new HttpResponseMessage() {
                    Content = new JsonContent(response.ID != 0)
                };
            } catch(Exception ex) {
                return new HttpResponseMessage() {
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        private bool SendEmail(string subject, string body, string mailTo) {
            string fromMail = "do.not.answer.nwt@gmail.com";

            MailMessage mail = new MailMessage(fromMail, mailTo, subject, body);

            var client = new SmtpClient("smtp.gmail.com", 587) {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Timeout = 20000,
                Credentials = new NetworkCredential("do.not.answer.nwt", "lozinka123")
            };
            try {
                client.Send(mail);
            } catch(Exception ex) {
                return false;
            }

            return true;
        }
    }
}
