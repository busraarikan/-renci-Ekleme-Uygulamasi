using Öğrenci_Ekleme_Uygulaması;
using System.Threading.Channels;

namespace OgrebnciYonetimApp
{

    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();

        static bool devamMi = true;


        static void Main(string[] args)
        {
            //Bir sinifta tanimladiginiz metodu, program sinifi icerisinde kullanabilmemiz icin,
            //o siniftan olusturmus oldugunuz nesne uzerinden cagirmaniz gerekiyor.

            Uygulama();


            
        }
     
        static void Uygulama()

        {

            Menu();
            SahteVeri();
            while (devamMi)
            {

                string secim = SecimAl();
                switch (secim)
                {
                    case "E":
                    case "1":
                        OgrenciEkle();
                        break;
                    case "L":
                    case "2":
                        OgrenciListele();
                        break;
                    case "S":
                    case "3":
                        OgrenciSil();
                        break;
                    case "X":
                    case "4":
                        devamMi = false;
                        break;

                }
            }

        }
        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması ");
            Console.WriteLine("1 - Öğrenci Ekle(E)        ");
            Console.WriteLine("2 - Öğrenci Listele(L)     ");
            Console.WriteLine("3 - Öğrenci Sil(S)         ");
            Console.WriteLine("4 - Çıkış(X)               ");
            Console.WriteLine();
        }
        static string SecimAl()
        {
            string karakterler = "1234ELSX";  

            int sayac = 0;

            while (true)
            {
                sayac++;
                Console.Write("Seciminiz = ");
                string giris = Console.ReadLine().ToUpper();  //giriş yapılan harflerde sorun olmaması için to upper methoduyla kükük girse bile büyük dönüştürüp alıyoruz.
                int index = karakterler.IndexOf(giris); 
                Console.WriteLine();

                if (giris.Length == 1 && index >= 0)
                {
                    return giris;
                }
                else
                {
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatali giris yapildi, tekrar deneyin.");
                }

            }

        }
        static void OgrenciEkle()
        {

            Ogrenci o = new Ogrenci();
            Console.WriteLine("1 - Öğrenci Ekle----------");
            Console.WriteLine("Öğrencinin                ");
            Console.Write("No: ");
            o.No = int.Parse(Console.ReadLine());
            Console.Write("Ad: ");
            o.Ad = Console.ReadLine();
            Console.Write("Soyadi: ");
            o.Soyad = Console.ReadLine();
            Console.Write("Subesi: ");
            o.Sube = Console.ReadLine();

            Console.WriteLine("Öğrenciyi kaydetmek istediğinize emin misiniz ? (E / H)");
            string giris = Console.ReadLine().ToUpper();
            if (giris == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi. ");
            }
            else
            {
                Console.WriteLine("Ogrenci eklenmedi. ");
            }

        }
        static void OgrenciListele()
        {
            Console.WriteLine("2 - Öğrenci Listele---------- -   ");
            Console.WriteLine("                                  ");
            Console.WriteLine("Şube".PadRight(6) + "No".PadRight(4) + "Ad".PadRight(13) + "Soyad".PadRight(13));  //düzenli bir liste olması için kullanıyoruz.
            Console.WriteLine("----------------------------------");

            foreach (Ogrenci item in ogrenciler)
            {
                Console.WriteLine(item.Sube.PadRight(6) + item.No.ToString().PadRight(5) + item.Ad.PadRight(13) + item.Soyad.PadRight(13));
            }
            Console.WriteLine();
        }
        static void OgrenciSil()
        {
            Console.WriteLine("3 - Öğrenci Sil----------    ");
            Console.WriteLine("Silmek istediğiniz öğrencinin");
            Console.Write("No: ");
            int no = int.Parse(Console.ReadLine());

            Ogrenci ogr = null;

            foreach (Ogrenci item in ogrenciler)
            {
                if (no == item.No)
                {
                    ogr = item;
                    break;
                }
            }
            if (ogr != null)
            {
                Console.WriteLine("Adi : " + ogr.Ad);
                Console.WriteLine("Soyadi : " + ogr.Soyad);
                Console.WriteLine("Subesi : " + ogr.Sube);
                Console.WriteLine();

                Console.WriteLine("Öğrenciyi silmek istediğinize emin misiniz ? (E / H)");
                string giris = Console.ReadLine().ToUpper();
                if (giris == "E")
                {
                    ogrenciler.Remove(ogr);
                    Console.WriteLine("Öğrenci silindi. ");
                }
                else
                {
                    Console.WriteLine("Ogrenci silinmedi. ");
                }
            }
            else
            {
                Console.WriteLine("Ogrenci bulunamadi");
            }
        }
        static void SahteVeri() //uygulama ilk açıldığında ekleme yapmadan listelenecek öğrenciler.
        {
            Ogrenci o1 = new Ogrenci();
            o1.Ad = "Büşra ";
            o1.Soyad = "Arıkan ";
            o1.Sube = "A";
            o1.No = 3;

            ogrenciler.Add(o1);


            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Mahmut";
            o2.Soyad = "Aydin";
            o2.Sube = "B";
            o2.No = 13;

            ogrenciler.Add(o2);

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Uzeyir";
            o3.Soyad = "Yaman";
            o3.Sube = "c";
            o3.No = 42;

            ogrenciler.Add(o3);
        }
    }
}