using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bu N x N boyutlarındaki labirentte maceracının başlangıç noktasından hazinenin
//bulunduğu noktaya en kısa yolu bulması gerekiyor. En kısa yolu bulan bir fonksiyon yazın
//ve kaç adımda hazinenin bulunduğunu hesaplayın. Eğer hazineye ulaşılamıyorsa,  Yol
//Yok sonucunu döndürün.

class Program
{
    static void Main()
    {
        //LABİRENT BOYUTUNU ALMA 
        Console.Write("lutfen labirent boyutunu tuslayınız (N): ");
        int n = int.Parse(Console.ReadLine());
        int[,] labirent = new int[n, n];
        Console.WriteLine("\n");
        Console.WriteLine("hadi labirentimizi çizelim ;)");
        Console.WriteLine("programın duzgun calısması ıcın sadece 0 ve 1 kullanın!! ");
        //LABİRENTİ KULLANICIDAN ALIP İŞLEME
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("lutfen deger giriniz :");
                int k = int.Parse(Console.ReadLine());
                labirent[i, j] = k;
            }
        }
        //LABİRENTİ EKRANA YAZDIRMA
        Console.WriteLine("oluşturdugunuz labirent su sekıldedır : ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(labirent[i, j] + "\t");
            }
            Console.WriteLine("\n");
        }
        //FONKSİYONUN SONUCUNDA EN KISA YOLU EKRANA YAZDIRMA
        int sonuc = EnKisaYol(labirent);
        Console.WriteLine(sonuc == -1 ? "Yol Yok!!" : $" Hazineye en kısa sekılde {sonuc} adımda ulaşılır.");
    }
    //EN KISA YOLU BULAN FONSKIYON
    static int EnKisaYol(int[,] labirent)
    {
        int N = labirent.GetLength(0);

        if (labirent[0, 0] == 0 || labirent[N - 1, N - 1] == 0)
            return -1;
        //HAREKET YONLERİNİ TNAİMALAMA
        int[,] hareketler = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        Queue<Koordinat> kuyruk = new Queue<Koordinat>();
        bool[,] ziyaretEdildi = new bool[N, N];

        kuyruk.Enqueue(new Koordinat(0, 0, 0)); // (x, y, adım)
        ziyaretEdildi[0, 0] = true;

        while (kuyruk.Count > 0)
        {
            Koordinat mevcut = kuyruk.Dequeue();

            if (mevcut.X == N - 1 && mevcut.Y == N - 1)
                return mevcut.Adim;
            //DX VE DY Yİ BASKA BIR DIZI UZERINDEN ALIOZ
            for (int i = 0; i < hareketler.GetLength(0); i++)
            {
                int dx = hareketler[i, 0];
                int dy = hareketler[i, 1];

                int yeniX = mevcut.X + dx;
                int yeniY = mevcut.Y + dy;

                if (yeniX >= 0 && yeniX < N && yeniY >= 0 && yeniY < N &&
                    labirent[yeniX, yeniY] == 1 && !ziyaretEdildi[yeniX, yeniY])
                {
                    kuyruk.Enqueue(new Koordinat(yeniX, yeniY, mevcut.Adim + 1));
                    ziyaretEdildi[yeniX, yeniY] = true;
                }
            }
        }

        return -1; //HEDEFE ULASAMADIK
    }

    //KOORDİNAT SINIFINI TANIMLAMA
    class Koordinat
    {
        public int X { get; }
        public int Y { get; }
        public int Adim { get; }

        public Koordinat(int x, int y, int adim)
        {
            X = x;
            Y = y;
            Adim = adim;
        }
    }
}
