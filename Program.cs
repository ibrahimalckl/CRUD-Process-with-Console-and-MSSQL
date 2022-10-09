using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusuCRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            //CRUD, CREATE, READ, UPDATE, DELETE

            husuEntities db = new husuEntities();

            //CREATE

            //Bilgi yeniKayit = new Bilgi();

            //yeniKayit.Adi = "Ibrahim";
            //yeniKayit.Soyadi = "ALACAKAL";
            //yeniKayit.Bolum = "BTBS";

            //db.Bilgi.Add(yeniKayit);

            //db.SaveChanges();


            //READ

            //List<Bilgi> okunacak1 = db.Bilgi.ToList(); //tum tablo

            //Bilgi okunacak = db.Bilgi.Where(x => x.KullaniciNO == 1).SingleOrDefault(); //tek bir kayit

            //Console.WriteLine(okunacak.KullaniciNO + " " + okunacak.Adi + " " + okunacak.Soyadi + " " + okunacak.Bolum);


            //foreach (Bilgi item in okunacak1)
            //{
            //    Console.WriteLine(okunacak.Adi);
            //}

            //Console.ReadKey();


            //UPDATE

            //Bilgi degistirilecek = db.Bilgi.Where(x => x.KullaniciNO == 2).SingleOrDefault();

            //degistirilecek.Adi = "Mehmet";
            //degistirilecek.Soyadi = "Bilen";
            //degistirilecek.Bolum = "BTBS";

            //db.SaveChanges();


            //DELETE

            //Bilgi silinecek = db.Bilgi.Where(x => x.KullaniciNO == 1).SingleOrDefault();

            //db.Bilgi.Remove(silinecek);
            //db.SaveChanges();

            Console.WriteLine("Bilgi Veritabanina Hos Geldiniz\nIlerlemek icin Enter tusuna basiniz.");

            ConsoleKeyInfo giris;

        Giris:
            giris = Console.ReadKey();

            if (giris.Key == ConsoleKey.Enter)
            {
                goto Anamenu;
            }
            else if (giris.Key != ConsoleKey.Enter)
            {
                Console.WriteLine(" Lutfen Enter Tusuna Basiniz. ");
                goto Giris;
            }

        Anamenu:
            Console.Clear();
            Console.WriteLine("Yapmak Istediginiz Islemi Seciniz.");

            Console.WriteLine("F1 - Veri Ekleme");
            Console.WriteLine("F2 - Veri Inceleme");
            Console.WriteLine("F3 - Veri Guncelleme");
            Console.WriteLine("F4 - Veri Silme");
            Console.WriteLine("F9 - Programi Kapat");

            ConsoleKeyInfo veri;
            veri = Console.ReadKey();

            if (veri.Key == ConsoleKey.F2 || veri.Key == ConsoleKey.F3 || veri.Key == ConsoleKey.F4)
            {

            Inceleme:

                Console.Clear();

                List<Bilgi> okunacak = db.Bilgi.ToList();

                foreach (Bilgi item in okunacak)
                {
                    Console.WriteLine(item.KullaniciNO + " " + item.Adi + " " + item.Soyadi + " " + item.Bolum);
                }

                Console.WriteLine("\nIslem yapmak istediginiz kullaniciyi seciniz.");
                int islem = Convert.ToInt16(Console.ReadLine());

                Console.Clear();

                Bilgi islem1 = db.Bilgi.Where(x => x.KullaniciNO == islem).SingleOrDefault();

                Console.WriteLine(islem1.KullaniciNO + " " + islem1.Adi + " " + islem1.Soyadi + " " + islem1.Bolum);

                ConsoleKeyInfo islem2;

            Yanlis:

                Console.WriteLine("F1 - Sil");
                Console.WriteLine("F3 - Guncelle");
                Console.WriteLine("F5 - Ana Menu");

                islem2 = Console.ReadKey();

                if (islem2.Key == ConsoleKey.F1)
                {

                Dogru1:

                    ConsoleKeyInfo onay;

                    Console.WriteLine("Silmek istediginize emin misiniz?\nF1 - Evet\nF3 - Iptal");

                    onay = Console.ReadKey();

                    if (onay.Key == ConsoleKey.F1)
                    {

                    Dogru2:

                        Console.Clear();
                        db.Bilgi.Remove(islem1);
                        db.SaveChanges();
                        Console.WriteLine("Islem Basariyla Gerceklestirildi.\nF1 - Silmeye Devam Et\nF5 - Ana Menu\nF9 - Programi Kapat");

                        ConsoleKeyInfo onay1;
                        onay1 = Console.ReadKey();

                        if (onay1.Key == ConsoleKey.F1)
                        {
                            goto Inceleme;
                        }
                        else if (onay1.Key == ConsoleKey.F5)
                        {
                            goto Anamenu;
                        }
                        else if (onay1.Key == ConsoleKey.F9)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            goto Dogru2;
                        }
                    }
                    else if (onay.Key == ConsoleKey.F3)
                    {
                        goto Anamenu;
                    }
                    else
                    {
                        goto Dogru1;
                    }
                }
                else if (islem2.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine(islem1.KullaniciNO + " " + islem1.Adi + " " + islem1.Soyadi + " " + islem1.Bolum);

                    Bilgi degistirelecek = db.Bilgi.Where(x => x.KullaniciNO == islem).SingleOrDefault();

                    Console.Write("Adi = ");
                    degistirelecek.Adi = Console.ReadLine();

                    Console.Write("Soyadi = ");
                    degistirelecek.Soyadi = Console.ReadLine();

                    Console.Write("Bolum = ");
                    degistirelecek.Bolum = Console.ReadLine();
                    
                    
                    Console.WriteLine("\nF5 - Kaydet");
                    Console.WriteLine("F7 - Iptal Et");

                    Geri:
                    ConsoleKeyInfo kaydet3;
                    kaydet3 = Console.ReadKey();

                    if (kaydet3.Key == ConsoleKey.F5)
                    {
                        Console.Clear();
                        Console.WriteLine("Basariyla Kaydedildi.");
                        db.SaveChanges();

                        ConsoleKeyInfo anamenu2;
                        Console.WriteLine("F1 - Guncellemeye Devam");
                        Console.WriteLine("F5 - Ana Menu");
                        Console.WriteLine("F9 - Programi Kapat");

                        anamenu2 = Console.ReadKey();

                        if (anamenu2.Key == ConsoleKey.F1)
                        {
                            goto Inceleme;
                        }
                        else if (anamenu2.Key == ConsoleKey.F5)
                        {
                            goto Anamenu;
                        }
                        else if (anamenu2.Key == ConsoleKey.F9)
                        {
                            Environment.Exit(0);
                        }
                    }
                    else if (kaydet3.Key == ConsoleKey.F7)
                    {
                        goto Anamenu;
                    }
                    else
                    {
                        goto Geri;
                    }
                }


            }
            
          
            else if (veri.Key == ConsoleKey.F1)
                {
                yeniKayit1:

                    Console.Clear();
                    Bilgi yeniKayit = new Bilgi();

                    Console.Write("Adi = ");
                    yeniKayit.Adi = Console.ReadLine();

                    Console.Write("Soyadi = ");
                    yeniKayit.Soyadi = Console.ReadLine();

                    Console.Write("Bolum = ");
                    yeniKayit.Bolum = Console.ReadLine();

                    db.Bilgi.Add(yeniKayit);

                    Console.WriteLine("F5 - Kaydet");
                    Console.WriteLine("F7 - Iptal Et");
                    ConsoleKeyInfo kaydet;
                    kaydet = Console.ReadKey();

                    if (kaydet.Key == ConsoleKey.F5)
                    {
                        Console.Clear();
                        Console.WriteLine("Basariyla Kaydedildi.");
                        db.SaveChanges();

                        ConsoleKeyInfo anamenu;
                        Console.WriteLine("F1 - Yeni Kayit");
                        Console.WriteLine("F5 - Ana Menu");
                        Console.WriteLine("F9 - Programi Kapat");

                        anamenu = Console.ReadKey();

                        if (anamenu.Key == ConsoleKey.F1)
                        {
                            goto yeniKayit1;
                        }
                        else if (anamenu.Key == ConsoleKey.F5)
                        {
                            goto Anamenu;
                        }
                        else if (anamenu.Key == ConsoleKey.F9)
                        {
                            Environment.Exit(0);
                        }
                    }
                    else if (kaydet.Key == ConsoleKey.F7)
                    {
                        goto Anamenu;
                    }
                }
                else if (veri.Key == ConsoleKey.F9)
                {
                    Environment.Exit(0);
                }
                else
                {
                    goto Anamenu;
                }

                Console.ReadKey();
            }
        }
    }


