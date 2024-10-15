using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MUHAMMED BEŞİR KESEN GURURLA SUNAR ;)
//ADAM ASMACA OYUNUMUZDA OYUNCUYA RANDOM OLARAK ATANAN KELİMEMİZİN UZUNLUĞUNUN 2 EKSİĞİ KADAR HAK TANIMLIYACAZ 

namespace adam_asmaca
{
    class Program
    {
        static void Main(string[] args)
        {
            //KAYNAK YAZMA
            string[] iller = new string[] { "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AKSARAY", "AMASYA", "ANKARA","ANTALYA", "ARDAHAN", "ARTVİN", "AYDIN", "BALIKESİR", "BARTIN", "BATMAN", "BAYBURT", "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR", "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM", "DENİZLİ", "DİYARBAKIR", "DÜZCE", "EDİRNE", "ELAZIĞ", "ERZİNCAN", "ERZURUM", "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE", "HAKKARİ", "HATAY", "IĞDIR", "ISPARTA", "İSTANBUL", "İZMİR", "KAHRAMANMARAŞ", "KARABÜK", "KARAMAN","KARS","KASTAMONU","KAYSERİ","KIRIKKALE","KIRKLARELİ","KIRŞEHİR","KİLİS","KOCAELİ","KONYA","KÜTAHYA","MALATYA","MANİSA","MARDİN","MERSİN","MUĞLA","MUŞ","NEVŞEHİR","NİĞDE","ORDU","OSMANİYE","RİZE","SAKARYA","SAMSUN","SİİRT","SİNOP","SİVAS","ŞANLIURFA","ŞIRNAK","TEKİRDAĞ","TOKAT","TRABZON","TUNCELİ","UŞAK","VAN","YALOVA","YOZGAT","ZONGULDAK"};
            //YAZILAN KAYNAKTAN RASTGELE BİRİNİ SECME
            Random rastgele = new Random();
            //RASTGELE SECİLEN İLİ ATAMA
            string secilenil = iller[rastgele.Next(0, iller.Length)];
            
            //DEĞİŞKEN ATAMA
            int hak = 0;
            int uzunluk = 0;
          
            //SEÇİLEN İLİN HARFİ KADAR '_' OLUŞTURMA
            char[] karakter = new char[secilenil.Length];
            for(int i = 0; i < karakter.Length; i++)
            {
                karakter[i] = '_';
                uzunluk++;
            }
            Console.WriteLine("kelimemizin uzunlugu :"+uzunluk);
            hak = uzunluk - 2;
            //İŞLEMLERİ YAPACAGIMIZ DONGU
            while (hak!=0)
            {
                bool berat = false;
                bool mami = false;
                //KARAKTERİ EKRANA YAZDIRMA
                foreach (var item in karakter)
                {
                    Console.Write(item + " ");
                }
                //OYUNCUDAN HARF İSTEME
                Console.WriteLine();
                Console.WriteLine("kalan hakkınız:"+hak);
                Console.Write("Bir harf giriniz:");
                char harf = char.Parse(Console.ReadLine().ToUpper());
                Console.WriteLine("\n");
                //ALINAN HARFİN SEÇİLEN KELİMEDE OLUP OLMADIGINNI KONTROL ETME VE KARAKTERİN ELEMANIYLA DEĞİŞTİRME
                    for (int i = 0; i < secilenil.Length; i++)
                    {
                        if (harf == secilenil[i])
                        {
                            karakter[i] = harf;
                            berat = true;
                        }
                    
                    }
                //OYUNUN BİTİP BİTMEDİĞİNİ KONTROL ETME
                for (int i = 0; i < secilenil.Length; i++)
                {
                   if(karakter[i] == '_')
                    {
                        mami = true;
                    }
                }
                if (mami==false)
                {
                    break;
                }
                    
                    //HAK KONTROL ETME
                    if (berat != true)
                        hak--;

            }
            //OYUNUN SONUNDA KAZANIP KAYBETTIGINI KONTROL EDIP EKRANA YAZDIRMA
            if (hak == 0)
            {
                Console.WriteLine("tüm haklarınız bitti!!! ");
                Console.WriteLine("bulmaya calistiginiz ilimiz : " + secilenil);

            }
            else
                Console.WriteLine("tebrikler oyunu tamamlamayı basardınız :)");
                Console.ReadKey();


        }
    }
}
