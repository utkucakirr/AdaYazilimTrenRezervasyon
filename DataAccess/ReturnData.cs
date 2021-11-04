using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ReturnData
    {
        public ReturnData(bool rezervasyonYapilabilir, List<YerlesimAyrinti> yerlesimAyrinti)
        {
            RezervasyonYapilabilir = rezervasyonYapilabilir;
            YerlesimAyrinti = yerlesimAyrinti;
        }

        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}
