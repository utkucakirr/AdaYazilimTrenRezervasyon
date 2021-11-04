using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class YerlesimAyrinti
    {
        public YerlesimAyrinti(string vagonAdi, int kisiSayisi)
        {
            VagonAdi = vagonAdi;
            KisiSayisi = kisiSayisi;
        }
        public YerlesimAyrinti()
        {

        }
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
