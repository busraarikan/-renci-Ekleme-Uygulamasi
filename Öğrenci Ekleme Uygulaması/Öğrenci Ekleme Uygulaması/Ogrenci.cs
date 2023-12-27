using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_Ekleme_Uygulaması
{


    //programda kullanacağımız öğrencimizin özelliklerinin tutulduğu farklı bir class oluşturuyoruz.

    internal class Ogrenci
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int No { get; set; }
        public string Sube { get; set; }
        public int MyProperty { get; set; }


        public Ogrenci()
        {

        }
        public Ogrenci(string ad, string soyad, int no, string sube)
        {

            this.Ad = ad;
            this.Soyad = soyad;
            this.No = no;
            this.Sube = sube;


            

        }

    }
}
