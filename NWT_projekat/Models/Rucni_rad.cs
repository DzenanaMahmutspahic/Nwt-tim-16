using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Rucni_rad
    {
        public int ID { get; set; }
        public int Korisnik_ID { get; set; }
        public string Slaganje_materijal { get; set; }
        public decimal Slaganje_sati { get; set; }
        public decimal Slaganje_cijena { get; set; }
        public string Savijanje_materijal { get; set; }
        public decimal Savijanje_sati { get; set; }
        public decimal Savijanje_cijena { get; set; }
        public string Lijepljenje_materijal { get; set; }
        public decimal Lijepljenje_sati { get; set; }
        public decimal Lijepljenje_cijena { get; set; }
        public string Pakovanje_materijal { get; set; }
        public decimal Pakovanje_sati { get; set; }
        public decimal Pakovanje_cijena { get; set; }
        public string Razno_materijal { get; set; }
        public decimal Razno_sati { get; set; }
        public decimal Razno_cijena { get; set; }
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_rada { get; set; }
        public DateTime Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
        public DateTime Vrijeme_pocetka { get; set; }
        public DateTime Vrijeme_zavrsetka { get; set; }
    }
}