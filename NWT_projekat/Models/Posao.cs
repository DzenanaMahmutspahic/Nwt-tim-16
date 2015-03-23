using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Posao
    {
        public int ID { get; set; }
        public bool DTP { get; set; }
        public bool Stampa { get; set; }
        public bool Knjigovodstvena_usluga { get; set; }
        public bool Vanjska_usluga { get; set; }
        public bool Montaza { get; set; }
        public bool Rucni_rad { get; set; }
        public bool Status_posla { get; set; }
        public bool Repromaterijal { get; set; }
        public decimal Materijalni_troskovi { get; set; }
        public decimal Rad { get; set; }
        public bool Popust { get; set; }
        public decimal Ukupna_cijena { get; set; }
        public decimal Cijena_komad { get; set; }
        public string Vrsta_posla { get; set; }
        public decimal Obim_posla { get; set; }
        public DateTime Datum { get; set; }
        public string Papir { get; set; }
        public string Dorada { get; set; }
        public string Montaza_posla { get; set; }
        public decimal Ukupna_cijena_PDV { get; set; }
        public decimal Cijena_komad_PDV { get; set; }
        public int Korisnik_ID { get; set; }
        public int Repromaterijal_ID { get; set; }
        public int DTP_ID { get; set; }
        public int Montaza_ID { get; set; }
        public int Knjigovodstvena_dorada_ID { get; set; }
        public int Rucni_rad_ID { get; set; }
        public int Stampa_ID { get; set; }
    }
}