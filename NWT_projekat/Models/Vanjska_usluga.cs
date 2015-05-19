using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Vanjska_usluga
    {
        #region == Constructors ==

        public Vanjska_usluga()
        {
            Vrijeme_pocetka = DateTime.Now;
            Vrijeme_zavrsetka = DateTime.Now;
        }

        #endregion
        public int ID { get; set; }
        public int Korisnik_ID { get; set; }
        public string Obracun_kalkulacije_materijal { get; set; }
        public decimal Obracun_kalkulacije_sati { get; set; }
        public decimal Obracun_kalkulacije_cijena { get; set; }
        public string Prevoz_materijal { get; set; }
        public decimal Prevoz_sati { get; set; }
        public decimal Prevoz_cijena { get; set; }
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_usluge { get; set; }
        public TimeSpan Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
        public DateTime Vrijeme_pocetka { get; set; }
        public DateTime Vrijeme_zavrsetka { get; set; }

    }
}