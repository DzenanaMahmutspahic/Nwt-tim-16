using NWT.Pomocnici;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NWT_projekat.Controllers
{
    public class GrafController: ApiController
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
        public GrafController()
        {
            _dbPomocnik = new DbPomocnik();
            _zapisnik = new Zapisnik(_dbPomocnik);
        }

        #endregion

        [HttpPost]
        public System.Net.Http.HttpResponseMessage DajPodatkeJson(string vrsta, int zMin)
        {
            try
            {
                var response = new List<object>();

                DataSet ds = _dbPomocnik.IzvrsiStoredProceduru(Konstante.DAJ_PODATKE_ZA_GRAF, null);
                foreach(DataTable dt in ds.Tables)
                {
                    var currRow = new Dictionary<string, object>();
                    foreach(DataRow dr in dt.Rows)
                    {
                        foreach(DataColumn dc in dr.Table.Columns)
                        {
                            currRow[dc.ColumnName] = dr[dc.ColumnName];
                        }
                    }
                    response.Add(currRow);
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(response)
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
    }
}
