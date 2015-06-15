using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWT_projekat.Models.Enumeracije
{
    public enum VremenskiPeriod : int
    {
        sekunda= 1,
        minuta = 60,
        sat = 3600,
        dan = 86400,
        mjesec = 2592000
    }
}