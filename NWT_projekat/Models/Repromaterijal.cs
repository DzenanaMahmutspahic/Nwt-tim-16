using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Repromaterijal
    {
        public Repromaterijal()
        {
            Vrijeme_pocetka = DateTime.Now;
            Vrijeme_zavrsetka = DateTime.Now;
        }

        public int ID { get; set; }
        public int Korisnik_ID { get; set; }
        public string Papir1_materijal { get; set; }
        public decimal Papir1_sati { get; set; }
        public decimal Papir1_cijena { get; set; }
        public string Papir2_materijal { get; set; }
        public decimal Papir2_sati { get; set; }
        public decimal Papir2_cijena { get; set; }
        public string PapirZK_materijal { get; set; }
        public decimal PapirZK_sati { get; set; }
        public decimal PapirZK_cijena { get; set; }
        public string MaterijalZXM_materijal { get; set; }
        public decimal MaterijalZXM_sati { get; set; }
        public decimal MaterijalZXM_cijena { get; set; }
        public string MZXMBoja_materijal { get; set; }
        public decimal MZXMBoja_sati { get; set; }
        public decimal MZXMBoja_cijena { get; set; }
        public string MZXMB3_materijal { get; set; }
        public decimal MZXMB3_sati { get; set; }
        public decimal MZXMB3_cijena { get; set; }
        public string MZXMFilmB2_materijal { get; set; }
        public decimal MZXMFilmB2_sati { get; set; }
        public decimal MZXMFilmB2_cijena { get; set; }
        public string MZXMFilmB3_materijal { get; set; }
        public decimal MZXMFilmB3_sati { get; set; }
        public decimal MZXMFilmB3_cijena { get; set; }
        public string OffsetPloceB5_materijal { get; set; }
        public decimal OffsetPloceB5_sati { get; set; }
        public decimal OffsetPloceB5_cijena { get; set; }
        public string OffsetPloceB3_materijal { get; set; }
        public decimal OffsetPloceB3_sati { get; set; }
        public decimal OffsetPloceB3_cijena { get; set; }
        public string OffsetPloceB2_materijal { get; set; }
        public decimal OffsetPloceB2_sati { get; set; }
        public decimal OffsetPloceB2_cijena { get; set; }
        public string Folija_materijal { get; set; }
        public decimal Folija_sati { get; set; }
        public decimal Folija_cijena { get; set; }
        public string Toner_materijal { get; set; }
        public decimal Toner_sati { get; set; }
        public decimal Toner_cijena { get; set; }
        public string Ostalo_materijal { get; set; }
        public decimal Ostalo_sati { get; set; }
        public decimal Ostalo_cijena { get; set; }
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_rada { get; set; }
        public TimeSpan Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
        public DateTime Vrijeme_pocetka { get; set; }
        public DateTime Vrijeme_zavrsetka { get; set; }
    }
}