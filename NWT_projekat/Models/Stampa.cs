using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models
{
    public class Stampa
    {
        #region == Constructors ==

        /// <summary>
        /// 
        /// </summary>
        public Stampa()
        {
            Vrijeme_pocetka = DateTime.Now;
            Vrijeme_zavrsetka = DateTime.Now;
        }

        #endregion

        public int Stampa_ID { get; set; }
        public int Korisnik_ID { get; set; }

        public string Priprema4b_materijal { get; set; }
        public decimal Priprema4b_sati { get; set; }
        public decimal Priprema4b_cijena { get; set; }
        
        public string GTO1_materijal { get; set; }
        public decimal GTO1_sati { get; set; }
        public decimal GTO1_cijena { get; set; }
        
        public string PripremaB2_materijal { get; set; }
        public decimal PripremaB2_sati { get; set; }
        public decimal PripremaB2_cijena { get; set; }
        
        public string HOB2_materijal { get; set; }
        public decimal HOB2_sati { get; set; }
        public decimal HOB2_cijena { get; set; }
        
        public string GTO2_materijal { get; set; }
        public decimal GTO2_sati { get; set; }
        public decimal GTO2_cijena { get; set; }
        
        public string PripremaGTO_materijal { get; set; }
        public decimal PripremaGTO_sati { get; set; }
        public decimal PripremaGTO_cijena { get; set; }
        
        public string PripremaNiG_materijal { get; set; }
        public decimal PripremaNiG_sati { get; set; }
        public decimal PripremaNiG_cijena { get; set; }
        
        public string Numeracija_materijal { get; set; }
        public decimal Numeracija_sati { get; set; }
        public decimal Numeracija_cijena { get; set; }
        
        public string Grafopres_materijal { get; set; }
        public decimal Grafopres_sati { get; set; }
        public decimal Grafopres_cijena { get; set; }
        
        public string Xeicon_materijal { get; set; }
        public decimal Xeicon_sati { get; set; }
        public decimal Xeicon_cijena { get; set; }
        
        public string Xerox_materijal { get; set; }
        public decimal Xerox_sati { get; set; }
        public decimal Xerox_cijena { get; set; }
        
        public decimal Ukupno_sati { get; set; }
        public decimal Ukupno_cijena { get; set; }
        public int Status_stampe { get; set; }
        public TimeSpan Vrijeme_cekanja { get; set; }
        public string Komentar { get; set; }
        public DateTime Vrijeme_pocetka { get; set; }
        public DateTime Vrijeme_zavrsetka { get; set; }
    }
}