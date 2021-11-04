using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Content
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi{ get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
