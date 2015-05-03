using System;
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
        #region Metode

        public void Zapisi(Log zapis)
        {
            new DbPomocnik().IzvrsiProceduru(Konstante.DODAJ_LOG, zapis);
        }

        #endregion
    }
}
