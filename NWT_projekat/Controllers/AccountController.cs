using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace NWT_projekat.Controllers
{
    public class AccountController: System.Web.Http.ApiController
    {

        #region *** Fields ***

        /// <summary>
        /// Instanca klase <see cref="DbPomocnik" /> koja pomaze pri komunikaciji sa bazom
        /// </summary>
        private readonly DbPomocnik _dbPomocnik = null;

        private readonly Zapisnik _zapisnik = null;

        #endregion

        #region *** Konstruktori ***

        /// <summary>
        /// Kreira instancu klase <see cref="AccountController"/>
        /// </summary>
        public AccountController()
        {
            _dbPomocnik = new DbPomocnik();
            _zapisnik = new Zapisnik();
        }

        #endregion

        #region *** Metode ***

        /// <summary>
        /// Servis za dobavljanje korisnika po ID
        /// </summary>
        /// <param name="ID">ID Korisnika</param>
        /// <returns>Objekat sa podacima o korisniku ili null ako korisnik nije nađen</returns>
        [System.Web.Mvc.HttpGet]
        public Korisnik DajKorisnikaXml(int ID)
        {
            var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
            var k = _dbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_ID, parametri).Rows[0];
            return new Korisnik
            {
                ID = Convert.ToInt32(k["ID"]),
                Ime = k["Ime"].ToString(),
                Password = k["Password"].ToString(),
                ConfirmPassword = k["ConfirmPassword"].ToString(),
                Pozicija = k["Pozicija"].ToString(),
                Prezime = k["Prezime"].ToString(),
                Username = k["Username"].ToString()
            };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage DajKorisnikaJson(int ID)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
                var k = _dbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_ID, parametri).Rows[0];
                var response = new Korisnik
                {
                    ID = Convert.ToInt32(k["ID"]),
                    Ime = k["Ime"].ToString(),
                    Password = k["Password"].ToString(),
                    ConfirmPassword = k["ConfirmPassword"].ToString(),
                    Pozicija = k["Pozicija"].ToString(),
                    Prezime = k["Prezime"].ToString(),
                    Username = k["Username"].ToString()
                };
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(response)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log { Datum = DateTime.Now, Sadrzaj = ex.ToString(), Tip = 3 }); ;
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// Servis za prijavu na sistem.
        /// </summary>
        /// <param name="korisnik">Objekat sa popunjenom podacima o korisniku</param>
        /// <returns>Logičku vrijednost true ako je prijavljivanje uspješno</returns>
        [System.Web.Mvc.HttpPost]
        public bool Login(Korisnik korisnik)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", korisnik.Password}
            };
                return _dbPomocnik.IzvrsiProceduru(Konstante.DAJ_KORISNIKA_UNAME_PASS, parametri).Rows.Count == 1;
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log
                                    {
                                        Datum = DateTime.Now,
                                        Sadrzaj = ex.ToString(),
                                        Tip = 3
                                    });
                return false;
            }
        }

        /// <summary>
        /// Servis za registraciju novog korisnika
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public Korisnik Registracija(Korisnik korisnik)
        {
            var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", korisnik.Password},
                {"Ime", korisnik.Ime},
                {"Prezime", korisnik.Prezime},
                {"Email", korisnik.Email},
            };
            try
            {
                int ID = Convert.ToInt32(_dbPomocnik.IzvrsiProceduru(Konstante.REGISTRUJ_KORISNIKA, parametri).Rows[0][0]);
                korisnik.ID = ID;
                return korisnik;
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(
                    new Log
                    {
                        Datum = DateTime.Now,
                        Sadrzaj = ex.ToString(),
                        Tip = 3
                    }
                );
            }
            return null;
        }

        /// <summary>
        /// Servis za registraciju novog korisnika
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public System.Net.Http.HttpResponseMessage RegistracijaJson(Korisnik korisnik)
        {
            Guid tmpGuid = Guid.NewGuid();
            var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", korisnik.Password},
                {"Ime", korisnik.Ime},
                {"Prezime", korisnik.Prezime},
                {"Email", korisnik.Email},
                {"GUID", tmpGuid.ToString().ToLower()}
            };
            try
            {
                int ID = Convert.ToInt32(_dbPomocnik.IzvrsiProceduru(Konstante.REGISTRUJ_KORISNIKA, parametri).Rows[0][0]);
                korisnik.ID = ID;

                SendEmail("Potvrda Registracije", string.Format(Konstante.REGISTRACIJA_TEMPLATE, korisnik.ID, tmpGuid), korisnik.Email);

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(ID != 0)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(
                    new Log
                    {
                        Datum = DateTime.Now,
                        Sadrzaj = ex.ToString(),
                        Tip = 3
                    }
                );
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(ex.Message)
                };
            }
        }


        /// <summary>
        /// Servis za promjenu lozinke
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage PromijeniLozinkuJson(Korisnik k)
        {
            var parametri = new Dictionary<string, object>{
                {"Username", k.Username},
                {"Password", k.Password},
                {"NewPassword", k.ConfirmPassword}
            };
            try
            {
                var korisnik = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.PROMJENA_LOZINKE, parametri);
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(korisnik.ID != 0)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(
                    new Log
                    {
                        Datum = DateTime.Now,
                        Sadrzaj = ex.ToString(),
                        Tip = 3
                    }
                );
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// Servis za potvrdu registracije
        /// </summary>
        /// <param name="id"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage PotvrdaRegistracijeJson(int id, string guid)
        {
            var parametri = new Dictionary<string, object>{
                {"ID", id},
                {"GUID", guid.ToLower()}
            };
            var response = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.POTVRDI_REGISTRACIJU, parametri);

            try
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(response.ID != 0)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(
                    new Log
                    {
                        Datum = DateTime.Now,
                        Sadrzaj = ex.ToString(),
                        Tip = 3
                    }
                );
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// Servis za slanje lozinke putem emaila
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public System.Net.Http.HttpResponseMessage PosaljiLozinkuJson(Korisnik korisnik)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                    {"Email", korisnik.Email}
                };
                var noviKorisnik = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.DAJ_KORISNIKA_EMAIL, parametri);

                if(noviKorisnik != null)
                {
                    SendEmail(
                        "Promjena lozinke",
                        string.Format(Konstante.PROMJENA_LOZINKE_TEMPLATE, noviKorisnik.Password),
                        noviKorisnik.Email
                   );
                }
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(noviKorisnik.ID != 0)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(
                    new Log
                    {
                        Datum = DateTime.Now,
                        Sadrzaj = ex.ToString(),
                        Tip = 3
                    }
                );
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        #endregion

        #region *** Pomoćne metode ***

        private bool SendEmail(string subject, string body, string mailTo)
        {
            string fromMail = "do.not.answer.nwt@gmail.com";

            MailMessage mail = new MailMessage(fromMail, mailTo, subject, body);

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Timeout = 20000,
                Credentials = new NetworkCredential("do.not.answer.nwt", "lozinka123")
            };
            try
            {
                client.Send(mail);
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(
                    new Log
                    {
                        Datum = DateTime.Now,
                        Sadrzaj = ex.ToString(),
                        Tip = 3
                    }
                );
                return false;
            }

            return true;
        }

        #endregion

    }
}
