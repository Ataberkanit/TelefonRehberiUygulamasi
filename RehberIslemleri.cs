using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelefonRehberi
{
    public class RehberIslemleri
    {

        public static void numaraEkleme(List<Rehber> kisiler)
        {

            Console.WriteLine("Lütfen isim giriniz: ");
            string isim = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz: ");
            string soyisim = Console.ReadLine();
            Console.WriteLine("Lütfen numarayı giriniz: ");
            long numara = long.Parse(Console.ReadLine());
            kisiler.Add(new Rehber() { Isim = isim, SoyIsim = soyisim, TelefonNo = numara });
        }
        public static void numaraSilme(List<Rehber> kisiler)
        {
            Console.WriteLine("  Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string silinecekKisi = Console.ReadLine();
            bool kisiKontrol = false;

            foreach (var kisi in kisiler.ToList())
            {
                kisiKontrol = true;
                if (kisi.Isim == silinecekKisi || kisi.SoyIsim == silinecekKisi)
                {
                    Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", kisi);
                    string YesNo = Console.ReadLine().ToLower();
                    if (YesNo == "y")
                        kisiler.Remove(kisi);
                    else if (YesNo == "n")
                    {
                        System.Console.WriteLine("silme işlemi iptal edildi..");
                        break;
                    }
                    break;
                }
            }
            if (!kisiKontrol)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");

                int giren = int.Parse(Console.ReadLine());
                if (giren == 2)
                {
                    numaraSilme(kisiler);
                }
                if (giren == 1)
                {
                    Console.WriteLine("silme işlemi sonlandırılıyor..");

                }
            }
        }

        public static void numarGuncelle(List<Rehber>kisiler)
        {
            System.Console.WriteLine("Lütfen numarasını değiştirmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string girdi = Console.ReadLine();
            bool Kisivarmı = false;

            foreach (var item in kisiler.ToList())
            {
                if (item.Isim == girdi || item.SoyIsim == girdi)
                {
                    Kisivarmı = true;
                    Console.WriteLine("{0} isimli kişinin numarası güncellenmek üzere, onaylıyor musunuz ?(y / n)", item.Isim );
                    string Yesno = Console.ReadLine().ToLower();
                    if (Yesno == "y")
                    {
                        Console.WriteLine("Yeni numarayı giriniz:");
                        long yeniNumara = long.Parse(Console.ReadLine());
                        item.TelefonNo = yeniNumara;
                    }
                    else if (Yesno == "n")
                    {
                        Console.WriteLine("Güncelleme işlemi iptal edildi..");
                        break;
                    }
                    break;
                }
                if (!Kisivarmı)
                {
                    System.Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    System.Console.WriteLine("* güncellemeyi sonlandırmak için : (1)");
                    System.Console.WriteLine("* Yeniden denemek için      : (2)");

                    string input = Console.ReadLine();
                    if (input == "2")
                    {
                        numarGuncelle(kisiler);
                    }
                    if (input == "1")
                    {
                        System.Console.WriteLine("Güncelleme işlemi sonlandırılıyor..");
                    }
                }

            }
        }

        public static void RehberListeleme(List<Rehber> kisiler)
        {
            System.Console.WriteLine("Rehberi A-Z Şeklinde sıralamak istiyorsanız (1)");
            System.Console.WriteLine("Rehberi Z-A Şeklinde sıralamak istiyorsanız (2)");
            string girdi = Console.ReadLine();
            if (girdi == "1")
            {
                System.Console.WriteLine("Telefon Rehberi (A-Z)");
                System.Console.WriteLine("**********************************************");
                var SiraliRehberListesi = kisiler.OrderBy(Kisi => Kisi.Isim);
                //                           from Kisi in KisiListesi
                //                           orderby Kisi.Isim
                //                           select Kisi;
                foreach (var Kisi in SiraliRehberListesi)
                {
                    Console.WriteLine(" isim= {0} \n soyisim = {1} \n telefon no = {2} \n     - ", Kisi.Isim, Kisi.SoyIsim, Kisi.TelefonNo);
                    System.Console.WriteLine(".\n.");
                }
            }
            if (girdi == "2")
            {
                System.Console.WriteLine("Telefon Rehberi (Z-A)");
                System.Console.WriteLine("**********************************************");
                var SiraliRehberListesi = from Kisi in kisiler
                                          orderby Kisi.Isim descending
                                          select Kisi;
                foreach (var Kisi in SiraliRehberListesi)
                {

                    Console.WriteLine(" isim= {0} \n soyisim = {1} \n telefon no = {2} \n     - ", Kisi.Isim, Kisi.SoyIsim, Kisi.TelefonNo);
                    System.Console.WriteLine(".\n.");
                }
            }

        }

        public static void RehberdeArama(List<Rehber> kisiler)
        {

            System.Console.WriteLine("arama yapmak istediğiniz tipi seçiniz");
            System.Console.WriteLine("**********************************************");
            System.Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            System.Console.WriteLine("Telefon numarasına göre arama yapmak için: (2) ");

            int Secsayı = int.Parse(Console.ReadLine());
            if (Secsayı == 1)
            {
                System.Console.WriteLine("Lütfen Aramak istediğiniz kişiye ait isim veya soyisim giriniz");
                string girilen = Console.ReadLine();
                foreach (var item in kisiler)
                {
                    if (item.Isim.ToLower() == girilen.ToLower() || item.SoyIsim.ToLower() == girilen.ToLower())
                    {
                        System.Console.WriteLine("isim: {0}", item.Isim);
                        System.Console.WriteLine("Soyisim: {0}", item.SoyIsim);
                        System.Console.WriteLine("Telefon Numarası: {0}", item.TelefonNo);
                        System.Console.WriteLine("    -    ");
                    }

                }

            }
            else if (Secsayı == 2)
            {
                System.Console.WriteLine("Lütfen Aramak istediğiniz kişiye ait telefon numarası giriniz ");
                long girilenNo = long.Parse(Console.ReadLine());
                foreach (var item in kisiler)
                {
                    if (girilenNo == item.TelefonNo)
                    {
                        System.Console.WriteLine("isim: {0}", item.Isim);
                        System.Console.WriteLine("Soyisim: {0}", item.SoyIsim);
                        System.Console.WriteLine("Telefon Numarası: {0}", item.TelefonNo);
                        System.Console.WriteLine("    -    ");
                        System.Console.WriteLine(".\n.");

                    }
                }
            }
            else
            {
                System.Console.WriteLine("hatalı seçim..");
            }


        }
    }

   
}
