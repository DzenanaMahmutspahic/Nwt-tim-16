using NWT.Pomocnici;
using NWT_projekat.Models;
using NWT_projekat.Models.Enumeracije;
using NWT_projekat.Models.Parametri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NWT_projekat.Controllers
{
    public class ValuesController: ApiController
    {
        #region === Fields ===

        DbPomocnik _dbPomocnik;

        Zapisnik _zapisnik;

        #endregion

        #region == Konstruktori ==

        public ValuesController()
        {
            _dbPomocnik = new DbPomocnik();
            _zapisnik = new Zapisnik(_dbPomocnik);
        }

        #endregion

        // GET api/values
        public System.Net.Http.HttpResponseMessage Get(string vrsta, int minute, VremenskiPeriod? vremenskiPeriod = null)
        {
            vremenskiPeriod = vremenskiPeriod ?? VremenskiPeriod.sekunda;
            try
            {
                var parametri = new Dictionary<string, object> {
                    {"vrsta", vrsta},
                    {"zadnjihMinuta", minute}
                };
                var tmp = _dbPomocnik.IzvrsiProceduru<ParametriZaGraf, PodatakZaGraf>(Konstante.DAJ_PODATKE_ZA_GRAF,
                    new ParametriZaGraf { vrsta = vrsta, zadnjihMinuta = minute });
                var t1 = tmp.GroupBy(a => a.Podaci);
                var t2 = t1
                        .Select(b => new {
                            Kljuc=b.FirstOrDefault().Podaci, 
                            Vrijednost = b.GroupBy(c => GrupisiDatum(c.VrijemeUpisa, vremenskiPeriod))
                                            .Select(d => new
                                            {
                                                Kljuc = new DateTime(GrupisiDatum(d.FirstOrDefault().VrijemeUpisa, vremenskiPeriod)),
                                                Vrijednost = d.Count()
                                            })
                        });
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.Accepted,
                    Content = new JsonContent(t2)
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

        private long GrupisiDatum(DateTime vrijednost, VremenskiPeriod? komponenta)
        {
            komponenta = komponenta ?? VremenskiPeriod.sekunda;
            long n1 = (long)(vrijednost.Ticks / 10000000);
            n1 -= n1 % (int)komponenta;
            n1 *= (long)(10000000);
            DateTime d1 = new DateTime(n1);
            return n1;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}