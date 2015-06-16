using NWT.Pomocnici;
using NWT_projekat.Models;
using System.Collections.Generic;

namespace NWT_projekat.Controllers.Pomocnici
{
    public class ProfilPomocnik
    {
        DbPomocnik _dbPomocnik;

        public ProfilPomocnik(DbPomocnik dbPomocnik)
        {
            _dbPomocnik = dbPomocnik;
        }

        public bool AutorizovanKorisnik(int Id, string authInfo)
        {

            var parametri = new Dictionary<string, object>{
                    {"ID", Id}
                };
            var trenutniKorisnik = _dbPomocnik.IzvrsiProceduru<Korisnik>(Konstante.DAJ_KORISNIKA_ID, parametri);

            if(trenutniKorisnik.ID != 0 && !trenutniKorisnik.Banovan)
            {
                var kod = KriptoPomocnik.Base64Encode(string.Format("{0}:{1}",
                    trenutniKorisnik.Username, trenutniKorisnik.Password));

                return authInfo == kod && trenutniKorisnik.Pozicija >= 3;
            }
            return false;
        }
    }
}
