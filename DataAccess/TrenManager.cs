using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class TrenManager
    {
        public ReturnData Sorgula(Content c)
        {
            var count = c.Tren.Vagonlar.Count;
            if (c.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                List<YerlesimAyrinti> yerlesimAyrintiList3 = new List<YerlesimAyrinti>();
                for (int i = 0; i < count; i++)
                {
                    int kisiSayisi = 0;
                    bool result = true;
                    while (result && c.RezervasyonYapilacakKisiSayisi!=0)
                    {
                        result = KapasiteKontrol(c.Tren.Vagonlar[i]);
                        if (result)
                        {
                            kisiSayisi++;
                            c.RezervasyonYapilacakKisiSayisi--;
                            c.Tren.Vagonlar[i].DoluKoltukAdet++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (kisiSayisi != 0)
                    {
                        var yerlesimAyrinti = new YerlesimAyrinti(c.Tren.Vagonlar[i].Ad, kisiSayisi);
                        yerlesimAyrintiList3.Add(yerlesimAyrinti);
                    }
                }

                if (c.RezervasyonYapilacakKisiSayisi == 0)
                {
                    var data2 = new ReturnData(true, yerlesimAyrintiList3);
                    return data2;
                }
                
            }

            for (var i = 0; i < count; i++)
            {
                c.Tren.Vagonlar[i].DoluKoltukAdet += c.RezervasyonYapilacakKisiSayisi;
                var result = KapasiteKontrol(c.Tren.Vagonlar[i]);
                if (result)
                {
                    var yerlesimAyrinti =
                        new YerlesimAyrinti(c.Tren.Vagonlar[i].Ad, c.RezervasyonYapilacakKisiSayisi);
                    List<YerlesimAyrinti> yerlesimAyrintiList = new List<YerlesimAyrinti>();
                    yerlesimAyrintiList.Add(yerlesimAyrinti);
                    var data = new ReturnData(true, yerlesimAyrintiList);

                    return data;
                }
            }

            List<YerlesimAyrinti> yerlesimAyrintiList2 = new List<YerlesimAyrinti>();
            var dataFalse = new ReturnData(false, yerlesimAyrintiList2);

            return dataFalse;
        }

        public bool KapasiteKontrol(Vagon vagon)
        {
            float result = (float)vagon.DoluKoltukAdet / (float)vagon.Kapasite;
            if (result > 0.7) return false;
            return true;
        }
    }
}
