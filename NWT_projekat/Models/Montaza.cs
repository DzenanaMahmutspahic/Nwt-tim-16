using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Montaza
    {
        public int ID { get; set; }
        public int Korisnik_ID { get; set; }
        public string Snimanje_materijal { get; set; }
        public decimal Snimanje_sati { get; set; }
        public decimal Snimanje_cijena { get; set; }
        public string Montaza_materijal { get; set; }
        public decimal Montaza_sati { get; set; }
        public decimal Snimanje_cijena { get; set; }
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_montaze { get; set; }
        public DateTime Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
    }
}