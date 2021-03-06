﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWT.Pomocnici
{
    /// <summary>
    /// Klasa koja sadrži logiku za upravljanje sa objektima tipa <see cref="Log"/>
    /// </summary>
    public class Zapisnik
    {
        #region Fields

        /// <summary>
        /// Instanca klase <see cref="DbPomocnik"/>
        /// </summary>
        DbPomocnik _dbPomocnik;

        #endregion

        #region Konstruktori

        /// <summary>
        /// Kreira novu instancu klase <see cref="Zapisnik"/>
        /// </summary>
        public Zapisnik()
        {
            _dbPomocnik = new DbPomocnik();
        }

        public Zapisnik(DbPomocnik dbPomocnik)
        {
            _dbPomocnik = dbPomocnik;
        }

        #endregion

        #region Metode


        /// <summary>
        /// Kreira zapis
        /// <example>
        ///     0 - Debug
        ///     1 - Informacija
        ///     2 - Upozorenje
        ///     3 - Greška
        /// </example>
        /// </summary>
        public void Zapisi(Log zapis)
        {
            new DbPomocnik().IzvrsiProceduru(Konstante.DODAJ_LOG, zapis);
        }

        /// <summary>
        /// Kreira zapis
        /// <example>
        ///     0 - Debug
        ///     1 - Informacija
        ///     2 - Upozorenje
        ///     3 - Greška
        /// </example>
        /// </summary>
        /// <param name="sadrzaj"></param>
        /// <param name="tip"></param>
        public void Zapisi(string sadrzaj, int tip = 1)
        {
            Dictionary<string, object> parametri = new Dictionary<string, object> {
                {"Sadrzaj", sadrzaj},
                {"Tip", tip}
            };
            _dbPomocnik.IzvrsiProceduru(Konstante.DODAJ_LOG, parametri);
        }

        #endregion
    }
}
