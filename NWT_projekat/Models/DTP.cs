using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class DTP
    {
        public int DTP_ID { get; set; }
        public int Korisnik_ID { get; set; }
        public string Sofp_materijal { get; set; }
        public decimal Sofp_sati { get; set; }
        public decimal Sofp_cijena { get; set; }
        public string Fotografija_materijal { get; set; }
        public decimal Fotografija_sati { get; set; }
        public decimal Fotografija_cijena { get; set; }
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_DTP { get; set; }
        public DateTime Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
        public DateTime Vrijeme_pocetka { get; set; }
        public DateTime Vrijeme_zavrsetka { get; set; }
    }
}