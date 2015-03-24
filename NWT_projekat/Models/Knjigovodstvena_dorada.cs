using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Knjigovodstvena_dorada
    {
        public int ID { get; set; }
        public int Korisnik_ID { get; set; }
        public string Noz_materijal { get; set; }
        public decimal Noz_sati { get; set; }
        public decimal Noz_cijena { get; set; }
        public string Falc_materijal { get; set; }
        public decimal Falc_sati { get; set; }
        public decimal Falc_cijena { get; set; }
        public string Klamerica_materijal { get; set; }
        public decimal Klamerica_sati { get; set; }
        public decimal Klamerica_cijena { get; set; }
        public string Perforirka_materijal { get; set; }
        public decimal Perforirka_sati { get; set; }
        public decimal Perforirka_cijena { get; set; }
        public string Plastificiranje_materijal { get; set; }
        public decimal Plastificiranje_sati { get; set; }
        public decimal Plastificiranje_cijena { get; set; }
        public string Blinder_materijal { get; set; }
        public decimal Blinder_sati { get; set; }
        public decimal Blinder_cijena { get; set; }
        public string Spiralni_materijal { get; set; }
        public decimal Spiralni_sati { get; set; }
        public decimal Spiralni_cijena { get; set; }
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_stampe { get; set; }
        public DateTime Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
        public DateTime Vrijeme_pocetka { get; set; }
        public DateTime Vrijeme_zavrsetka { get; set; }
    }
}