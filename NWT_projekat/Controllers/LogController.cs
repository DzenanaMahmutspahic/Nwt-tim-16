using NWT.Pomocnici;
using NWT_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NWT_projekat.Controllers
{
    public class LogController : ApiController
    {
        // GET api/log
        [System.Web.Mvc.HttpGet]
        public IEnumerable<Log> Get()
        {
            var logovi = new List<Log>();
            var redovi = new DbPomocnik().IzvrsiProceduru<Log, Log>(Konstante.DAJ_LOGOVE, null);
            return redovi;
        }

        // GET api/log/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
