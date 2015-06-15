using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using NWT_projekat.Controllers.Pomocnici;

namespace NWT_projekat.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController: System.Web.Http.ApiController
    {
        bool POSALjIMAIL = true;

        #region *** Fields ***

        /// <summary>
        /// Instanca klase <see cref="DbPomocnik" /> koja pomaze pri komunikaciji sa bazom
        /// </summary>
        private readonly DbPomocnik _dbPomocnik = null;

        private readonly Zapisnik _zapisnik = null;

        private readonly ProfilPomocnik _profilPomocnik;

        #endregion

        #region *** Konstruktori ***

        /// <summary>
        /// Kreira instancu klase <see cref="AccountController"/>
        /// </summary>
        public AccountController()
        {
            _dbPomocnik = new DbPomocnik();
            _zapisnik = new Zapisnik(_dbPomocnik);
            _profilPomocnik = new ProfilPomocnik(_dbPomocnik);
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
                Pozicija = Convert.ToInt32(k["Pozicija"]),
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
                var response = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.DAJ_KORISNIKA_ID, parametri);

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
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="adminId"></param>
        /// <param name="authInfo"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage BanujKorisnikaJson(int Id, int adminId, string authInfo)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                    {"ID", adminId}
                };
                var trenutniKorisnik = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.DAJ_KORISNIKA_ID, parametri);

                if(trenutniKorisnik.ID != 0 && !trenutniKorisnik.Banovan)
                {
                    var kod = KriptoPomocnik.Base64Encode(string.Format("{0}:{1}",
                        trenutniKorisnik.Username, trenutniKorisnik.Password));

                    if(authInfo == kod && trenutniKorisnik.Pozicija >= 3)
                    {
                        parametri["ID"] = Id;
                        var response = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.BANUJ_KORISNIKA, parametri);
                        return new HttpResponseMessage()
                        {
                            Content = new JsonContent(response.Banovan)
                        };
                    }
                } return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log { Datum = DateTime.Now, Sadrzaj = ex.ToString(), Tip = 3 }); ;
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage OdbanujKorisnikaJson(int Id, int adminId, string authInfo)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                    {"ID", adminId}
                };
                var trenutniKorisnik = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.DAJ_KORISNIKA_ID, parametri);

                if(trenutniKorisnik.ID != 0 && !trenutniKorisnik.Banovan)
                {
                    var kod = KriptoPomocnik.Base64Encode(string.Format("{0}:{1}",
                        trenutniKorisnik.Username, trenutniKorisnik.Password));

                    if(authInfo == kod && trenutniKorisnik.Pozicija >= 3)
                    {
                        parametri["ID"] = Id;
                        var response = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.ODBANUJ_KORISNIKA, parametri);
                        return new HttpResponseMessage()
                        {
                            Content = new JsonContent(response.Banovan)
                        };
                    }
                } return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log { Datum = DateTime.Now, Sadrzaj = ex.ToString(), Tip = 3 }); ;
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage UnaprijediKorisnikaJson(int Id, int adminId, string authInfo)
        {
            try
            {
                if(_profilPomocnik.AutorizovanKorisnik(adminId, authInfo))
                {
                    var parametri = new Dictionary<string, object> { { "ID", Id } };
                    var response = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.UNAPRIJEDI_KORISNIKA, parametri);
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new { pozicija = response.Pozicija })
                    };
                }
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log { Datum = DateTime.Now, Sadrzaj = ex.ToString(), Tip = 3 }); ;
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage UnazadiKorisnikaJson(int Id, int adminId, string authInfo)
        {
            try
            {
                if(_profilPomocnik.AutorizovanKorisnik(adminId, authInfo))
                {
                    var parametri = new Dictionary<string, object> { { "ID", Id } };
                    var response = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.NAZADUJ_KORISNIKA, parametri);
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new { pozicija = response.Pozicija })
                    };
                }
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log { Datum = DateTime.Now, Sadrzaj = ex.ToString(), Tip = 3 }); ;
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
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
        public System.Net.Http.HttpResponseMessage Login(Korisnik korisnik)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                {"Username", korisnik.Username},
                {"Password", KriptoPomocnik.GetMd5Hash(korisnik.Password)}
            };
                var odgovor = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.DAJ_KORISNIKA_UNAME_PASS, parametri);

                if(odgovor != null && odgovor.ID != 0)
                {
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Successfull = true,
                            User = odgovor
                        })
                    };
                }
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(new
                    {
                        Successfull = false,
                        Message = "Pogrešni login podaci!"
                    })
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log
                                    {
                                        Datum = DateTime.Now,
                                        Sadrzaj = ex.ToString(),
                                        Tip = 3
                                    });

                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(new
                    {
                        Successfull = false,
                        Message = "Greška u izvršavanju Login servisa!"
                    })
                };
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
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
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
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
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
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
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

                if(noviKorisnik != null && noviKorisnik.ID != 0 && !string.IsNullOrEmpty(noviKorisnik.Email))
                {
                    Guid noviGuid = Guid.NewGuid();
                    parametri = new Dictionary<string, object> { 
                        {"KorisnikId", noviKorisnik.ID },
                        {"GUID", noviGuid},
                        {"Email", noviKorisnik.Email}
                    };

                    var zahtjevIdOdgovor = _dbPomocnik.IzvrsiProceduru(Konstante.ZAHTJEV_NOVA_LOZINKA, parametri);
                    int zahtjevId;
                    try
                    {
                        int.TryParse(zahtjevIdOdgovor.Rows[0]["ID"].ToString(), out zahtjevId);

                        SendEmail(
                            "Promjena lozinke",
                            string.Format(Konstante.PROMJENA_LOZINKE_TEMPLATE, zahtjevId, noviGuid),
                            noviKorisnik.Email
                       );
                    }
                    catch(Exception ex)
                    {
                        _zapisnik.Zapisi(ex.ToString(), 2);
                        return new HttpResponseMessage()
                        {
                            StatusCode = System.Net.HttpStatusCode.BadRequest,
                            Content = new JsonContent("Greška pri slanju email poruke.")
                        };
                    }
                }
                var response = new HttpResponseMessage();
                if(noviKorisnik.ID != 0)
                {
                    response.Content = new JsonContent(true);
                }
                else
                {
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.Content = new JsonContent("Pogrešan korisnik.");
                }
                return response;
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
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        /// <summary>
        /// Akcija promjene lozinke
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public System.Net.Http.HttpResponseMessage PromjenaLozinke(PromjenaLozinkeModel model)
        {
            try
            {
                int id = model.id;
                string zahtjevGuid = model.guid.ToUpper();
                string novaLozinka = KriptoPomocnik.GetMd5Hash(model.novaLozinka);

                var parametri = new Dictionary<string, object>{
                    {"Id", id},
                    {"GUID", zahtjevGuid},
                    {"NovaLozinka", novaLozinka}
                };
                var tmp = _dbPomocnik.IzvrsiProceduru(Konstante.PROMJENI_LOZINKU, parametri);

                try
                {
                    string poruka = tmp.Rows[0]["Greska"].ToString();
                    _zapisnik.Zapisi(poruka, 2);
                }
                catch { /* Nothing to see here. Move along!*/ }

                var response = Request.CreateResponse(HttpStatusCode.Moved);
                var add = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                response.Headers.Location = new Uri(add + "/index.html", UriKind.Absolute);
                return response;
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log()
                {
                    Datum = DateTime.Now,
                    Sadrzaj = ex.ToString(),
                    Tip = 3
                });
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent("Doslo je do greske u procesiranju!")
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public string DajPutanju(string Username)
        {
            try
            {
                var parametri = new Dictionary<string, object> { { "Username", Username } };
                var tmp = _dbPomocnik.IzvrsiProceduru(Konstante.DAJ_PUTANjU_SLIKE, parametri);
                var url = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                var putanja = tmp.Rows[0]["Putanja"].ToString();
                return url + "/Images/Profile/" + putanja;
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(new Log()
                {
                    Datum = DateTime.Now,
                    Sadrzaj = ex.ToString(),
                    Tip = 3
                });
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="authInfo"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage DajKorisnikeJson(int Id, string authInfo)
        {
            try
            {
                var redovi = _dbPomocnik.IzvrsiProceduru<Korisnik, Korisnik>(Konstante.DAJ_SVE_KORISNIKE, null);
                var trenutniKorisnik = redovi.FirstOrDefault(x => x.ID == Id);
                if(trenutniKorisnik != null)
                {
                    var kod = KriptoPomocnik.Base64Encode(string.Format("{0}:{1}", trenutniKorisnik.Username, trenutniKorisnik.Password));
                    if(authInfo == kod && trenutniKorisnik.Pozicija >= 3)
                    {
                        redovi.Remove(trenutniKorisnik);
                        redovi.AsParallel().ForAll(x => x.Password = "");
                        return new HttpResponseMessage()
                        {
                            StatusCode = System.Net.HttpStatusCode.Accepted,
                            Content = new JsonContent(redovi)
                        };
                    }
                }
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Content = new JsonContent(redovi)
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
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new JsonContent(ex.Message)
                };
            }
        }

        [HttpPost]
        public void UploadFile(System.Web.HttpPostedFileBase file)
        {
            if(System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = System.Web.HttpContext.Current.Request.Files["UploadedImage"];

                if(httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<object> UploadFile1()
        {
            if(!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }
            NamedMultipartFormDataStreamProvider streamProvider = new
              NamedMultipartFormDataStreamProvider(System.Web.HttpContext.Current.Server.MapPath("~/Images/Profile"));
            await Request.Content.ReadAsMultipartAsync(streamProvider);
            var r = new
            {
                FileNames = streamProvider.FileData.Select(entry => Path.GetFileName(entry.LocalFileName)),
            };
            var id = Convert.ToInt32(streamProvider.FormData["ID"]);
            var authInfo = streamProvider.FormData["authinfo"];
            if(_profilPomocnik.AutorizovanKorisnik(id, authInfo))
            {
                string put = Path.GetFileName(r.FileNames.FirstOrDefault());
                var param = new Dictionary<string, object> { 
                    { "KorisnikId", id },
                    { "Putanja", put }
                };
                _dbPomocnik.IzvrsiProceduru("DodajSliku", param);
            }
            return r;
        }

        #endregion

        #region *** Pomoćne metode ***

        private bool SendEmail(string subject, string body, string mailTo)
        {
            if(!POSALjIMAIL)
            {
                _zapisnik.Zapisi("Slanje maila iskljuceno!", 1);
                return false;
            }
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