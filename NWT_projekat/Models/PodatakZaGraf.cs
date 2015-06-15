using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class PodatakZaGraf
    {
        public int ID { get; set; }

        public string Vrsta { get; set; }

        public DateTime VrijemeUpisa { get; set; }

        public string Podaci { get; set; }

    }
}