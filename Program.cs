using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rehber> kisiler = new List<Rehber>
            {
                new Rehber(){Isim="Ataberk", SoyIsim="Anıt", TelefonNo=05532443950},
                new Rehber(){Isim = "Sevgül", SoyIsim="Çetin", TelefonNo=05543449538},
                new Rehber(){Isim="Gökberk", SoyIsim="Anıt", TelefonNo=05994839583},
                new Rehber(){Isim="Haydari",SoyIsim="Geceler",TelefonNo=05994773859}
            };

            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
            Console.WriteLine("**********************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak﻿");


            Console.Write("işlem yapacağınız sıra:"); int deger = int.Parse(Console.ReadLine());
            switch (deger)
            {

                case 1:
                    RehberIslemleri.numaraEkleme(kisiler);
                    break;

                case 2:
                    RehberIslemleri.numaraSilme(kisiler);
                    break;

                case 3:
                    RehberIslemleri.numarGuncelle(kisiler);
                    break;

                case 4:
                    RehberIslemleri.RehberListeleme(kisiler);
                    break;

                case 5:
                    RehberIslemleri.RehberdeArama(kisiler);
                    break;


            }

            System.Console.WriteLine("Gerçekleştirdiğiniz işlem başarıyla tamamlanmıştır..");
        }
       
    }
   
}
