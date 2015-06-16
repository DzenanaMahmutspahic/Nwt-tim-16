using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace NWT_projekat.Controllers
{
    public class PosaoController: ApiController
    {

        #region *** Fields ***

        private readonly DbPomocnik _dbPomocnik = null;

        private readonly Zapisnik _zapisnik = null;

        #endregion

        #region *** Konstruktori ***

        /// <summary>
        /// Kreira novu instancu klase <see cref="PosaoController"/>
        /// </summary>
        public PosaoController()
        {
            _dbPomocnik = new DbPomocnik();
            _zapisnik = new Zapisnik(_dbPomocnik);
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
        public Posao DajPosao(int ID)
        {
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

        /// <summary>
        /// Servis za dobavljanje poslova json
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public System.Net.Http.HttpResponseMessage DajPosaoJson(int ID)
        {
            try
            {
                var parametri = new Dictionary<string, object>{
                {"ID", ID}
            };
                var q = _dbPomocnik.IzvrsiProceduru<Posao>(Konstante.DAJ_POSAO_ID, parametri);

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(q)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }


        [System.Web.Http.HttpPost]
        public Posao UnesiPosao(Posao p)
        {
            return _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DODAJ_POSAO, p).FirstOrDefault();
        }


        [System.Web.Http.HttpPost]
        //[Description("Servis za unos posla")]
        public System.Net.Http.HttpResponseMessage UnesiPosaoJson(Posao p)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DODAJ_POSAO, p).FirstOrDefault();

                if(q.ID != 0)
                    p.ID = q.ID;

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(p)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za dobavljanje završenih poslova
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Posao> DajZavrsenePoslove()
        {
            var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DAJ_ZAVRSENE_POSLOVE, null);
            return q;

        }

        /// <summary>
        /// Servis za dobavljanje završenih poslova
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Posao> DajNezavrsenePoslove()
        {
            var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DAJ_NEZAVRSENE_POSLOVE, null);
            return q;

        }

        /// <summary>
        /// Servis za dobavljanje završenih poslova
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public System.Net.Http.HttpResponseMessage DajZavrsenePosloveJson()
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Posao, Posao>(Konstante.DAJ_ZAVRSENE_POSLOVE, null);

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(q)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za dobavljanje završenih poslova
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public System.Net.Http.HttpResponseMessage DajDtpJson(int ID)
        {
            try
            {
                var parametri = new Dictionary<string, object> { { "ID", ID } };
                var q = _dbPomocnik.IzvrsiProceduru<DTP>(Konstante.DAJ_DTP, parametri);

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(q)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za dobavljanje završenih poslova
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public System.Net.Http.HttpResponseMessage DajMontazuJson(int ID)
        {
            try
            {
                var parametri = new Dictionary<string, object> { { "ID", ID } };
                var q = _dbPomocnik.IzvrsiProceduru(Konstante.DAJ_MONAZU, parametri).Rows[0];

                Montaza m = new Montaza
                {
                    ID = Convert.ToInt32(q["ID"]),
                    Korisnik_ID = Convert.ToInt32(q["Korisnik_ID"]),
                    Snimanje_materijal = q["Snimanje_materijal"].ToString(),
                    Snimanje_sati = Convert.ToDecimal(q["Snimanje_sati"]),
                    Snimanje_cijena = Convert.ToDecimal(q["Snimanje_cijena"]),
                    Montaza_materijal = Convert.ToString(q["Montaza_materijal"]),
                    Montaza_sati = Convert.ToDecimal(q["Montaza_sati"]),
                    Montaza_cijena = Convert.ToDecimal(q["Montaza_cijena"]),
                    Ukupno_sati = Convert.ToDecimal(q["Ukupno_sati"]),
                    Ukupno_cijena = Convert.ToDecimal(q["Ukupno_cijena"]),
                    Status_montaze = Convert.ToInt32(q["Status_montaze"]),
                    //public TimeSpan Vrijeme_cekanja = Convert.ToDateTime(q["xx"]),
                    Komentar = Convert.ToString(q["Komentar"])
                };

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(m)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za dobavljanje završenih poslova
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public System.Net.Http.HttpResponseMessage DajStampuJson(int ID)
        {
            try
            {
                var parametri = new Dictionary<string, object> { { "ID", ID } };
                var q = _dbPomocnik.IzvrsiProceduru(Konstante.DAJ_STAMPU, parametri).Rows[0];

                Stampa s = new Stampa
                {

                    Stampa_ID = Convert.ToInt32(q["Stampa_ID"]),
                    Korisnik_ID = Convert.ToInt32(q["Korisnik_ID"]),
                    Priprema4b_materijal = Convert.ToString(q["Priprema4b_materijal"]),
                    Priprema4b_sati = Convert.ToDecimal(q["Priprema4b_sati"]),
                    Priprema4b_cijena = Convert.ToDecimal(q["Priprema4b_cijena"]),

                    GTO1_materijal = Convert.ToString(q["GTO1_materijal"]),
                    GTO1_sati = Convert.ToDecimal(q["GTO1_sati"]),
                    GTO1_cijena = Convert.ToDecimal(q["GTO1_cijena"]),

                    PripremaB2_materijal = Convert.ToString(q["PripremaB2_materijal"]),
                    PripremaB2_sati = Convert.ToDecimal(q["PripremaB2_sati"]),
                    PripremaB2_cijena = Convert.ToDecimal(q["PripremaB2_cijena"]),

                    HOB2_materijal = Convert.ToString(q["HOB2_materijal"]),
                    HOB2_sati = Convert.ToDecimal(q["HOB2_sati"]),
                    HOB2_cijena = Convert.ToDecimal(q["HOB2_cijena"]),

                    GTO2_materijal = Convert.ToString(q["GTO2_materijal"]),
                    GTO2_sati = Convert.ToDecimal(q["GTO2_sati"]),
                    GTO2_cijena = Convert.ToDecimal(q["GTO2_cijena"]),

                    PripremaGTO_materijal = Convert.ToString(q["PripremaGTO_materijal"]),
                    PripremaGTO_sati = Convert.ToDecimal(q["PripremaGTO_sati"]),
                    PripremaGTO_cijena = Convert.ToDecimal(q["PripremaGTO_cijena"]),

                    PripremaNiG_materijal = Convert.ToString(q["PripremaNiG_materijal"]),
                    PripremaNiG_sati = Convert.ToDecimal(q["PripremaNiG_sati"]),
                    PripremaNiG_cijena = Convert.ToDecimal(q["PripremaNiG_cijena"]),

                    Numeracija_materijal = Convert.ToString(q["Numeracija_materijal"]),
                    Numeracija_sati = Convert.ToDecimal(q["Numeracija_sati"]),
                    Numeracija_cijena = Convert.ToDecimal(q["Numeracija_cijena"]),

                    Grafopres_materijal = Convert.ToString(q["Grafopres_materijal"]),
                    Grafopres_sati = Convert.ToDecimal(q["Grafopres_sati"]),
                    Grafopres_cijena = Convert.ToDecimal(q["Grafopres_cijena"]),

                    Xeicon_materijal = Convert.ToString(q["Xeicon_materijal"]),
                    Xeicon_sati = Convert.ToDecimal(q["Xeicon_sati"]),
                    Xeicon_cijena = Convert.ToDecimal(q["Xeicon_cijena"]),

                    Xerox_materijal = Convert.ToString(q["Xerox_materijal"]),
                    Xerox_sati = Convert.ToDecimal(q["Xerox_sati"]),
                    Xerox_cijena = Convert.ToDecimal(q["Xerox_cijena"]),

                    Ukupno_sati = Convert.ToDecimal(q["Ukupno_sati"]),
                    Ukupno_cijena = Convert.ToDecimal(q["Ukupno_cijena"]),
                    Status_stampe = Convert.ToInt32(q["Status_stampe"]),
                    //public TimeSpan Vrijeme_cekanja { get; set; }
                    Komentar = Convert.ToString(q["Komentar"])
                    //public DateTime Vrijeme_pocetka { get; set; }
                    //public DateTime Vrijeme_zavrsetka { get; set; }
                };

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(s)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za potvrdu posla
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public System.Net.Http.HttpResponseMessage PotvrdiPosao(int ID)
        {
            try
            {
                var parametri = new Dictionary<string, object> { { "ID", ID } };
                var q = _dbPomocnik.IzvrsiProceduru(Konstante.POTVRDI_POSAO, parametri);

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(true)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos montaze
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiMontazuJson(Montaza m)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Montaza, Montaza>(Konstante.DODAJ_MONTAZU, m).FirstOrDefault();

                if(q != null && q.ID != 0)
                {
                    m.ID = q.ID;
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(m)
                    };
                }
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new { message = "Greska u dodavanju Montaže!", success = false })
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos repromaterijala
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiRepromaterijalJson(Repromaterijal r)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Repromaterijal, Repromaterijal>(Konstante.DODAJ_REPROMATERIJAL, r).FirstOrDefault();


                if(q.ID != 0)
                    r.ID = q.ID;
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(r)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos knjigovodstvene dorade
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiKnjigovodstvenuDoraduJson(Knjigovodstvena_dorada k)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Knjigovodstvena_dorada, Knjigovodstvena_dorada>(Konstante.DODAJ_KNJIGOVODSTVENU_DORADU, k).FirstOrDefault();

                if(q.ID != 0)
                    k.ID = q.ID;
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(k)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos rucnog rada
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiRucniRadJson(Rucni_rad r)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Rucni_rad, Rucni_rad>(Konstante.DODAJ_RUCNI_RAD, r).FirstOrDefault();

                if(q.ID != 0)
                    r.ID = q.ID;

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(r)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos stampe
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiStampuJson(Stampa s)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Stampa, Stampa>(Konstante.DODAJ_STAMPU, s).FirstOrDefault();

                if(q.Stampa_ID != 0)
                {
                    s.Stampa_ID = q.Stampa_ID;
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(s)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos vanjske usluge
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiVanjskuUsluguJson(Vanjska_usluga v)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<Vanjska_usluga, Vanjska_usluga>(Konstante.DODAJ_VANJSKU_USLUGU, v).FirstOrDefault();

                if(q.ID != 0)
                    v.ID = q.ID;

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(v)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        /// <summary>
        /// Servis za unos DTP
        /// </summary>
        /// <param name="dtp"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public System.Net.Http.HttpResponseMessage UnesiDtpJson(DTP dtp)
        {
            try
            {
                var q = _dbPomocnik.IzvrsiProceduru<DTP, DTP>(Konstante.DODAJ_DTP, dtp).FirstOrDefault();

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(q)
                };
            }
            catch(Exception ex)
            {
                _zapisnik.Zapisi(ex.ToString(), 3);
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new JsonContent(new { message = "Greska u izvrsavanju servisa!", success = false })
            };
        }

        #endregion

    }
}
