using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Görev: Bir N x N boyutundaki gridi (haritayı) ve robotların başlangıç noktalarını temsil
//eden bir listeyi giriş olarak alan bir fonksiyon yazın.Bu fonksiyon, robotların kaç tane
//düğümü kurtarabileceğini hesaplamalıdır.

namespace techcity_kurtarma
{
    class Program
    {
        static void Main(string[] args)
        {
            //HARİTA BOYUTUNU ALMA 
            Console.Write("lutfen harita boyutunu tuslayınız (N): ");
            int n = int.Parse(Console.ReadLine());
            int[,] harita = new int[n, n];
            //ROBOTLARIN BAŞLANGIÇ NOKTALARINI ALMA
            Console.Write("lutfen robot1 için x eksenindeki baslangıc noktasını giriniz :");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("lutfen robot1 için y eksenindeki baslangıc noktasını giriniz :");
            int y1 = int.Parse(Console.ReadLine());
            Console.Write("lutfen robot2 için x eksenindeki baslangıc noktasını giriniz :");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write("lutfen robot2 için y eksenindeki baslangıc noktasını giriniz :");
            int y2 = int.Parse(Console.ReadLine());
            Console.Write("lutfen robot3 için x eksenindeki baslangıc noktasını giriniz :");
            int x3 = int.Parse(Console.ReadLine());
            Console.Write("lutfen robot3 için y eksenindeki baslangıc noktasını giriniz :");
            int y3 = int.Parse(Console.ReadLine());
            List<(int, int)> baslangicnoktalari = new List<(int, int)> { (x1, y1), (x2, y2), (x3, y3) };
            Console.WriteLine("\n");
            Console.WriteLine("hadi haritamızı çizelim ;)");
            Console.WriteLine("programın duzgun calısması ıcın sadece 0 ve 1 kullanın!! ");
            //HARİTAYI KULLANICIDAN ALIP İŞLEME
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("lutfen deger giriniz :");
                    int k = int.Parse(Console.ReadLine());
                    harita[i, j] = k;
                }
            }
            //HARİTAYI EKRANA YAZDIRMA
            Console.WriteLine("oluşturdugunuz harita su sekıldedır : ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(harita[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            //FONKSIYONA GITME VE SONUCUNU EKRANA YAZZDIRMA
            int result = enfazlakurtarılandugum(harita, baslangicnoktalari);
            Console.WriteLine("Kurtarılan düğüm sayısı: " + result);
        }
        //TUM ISI YAPACAGIMIZ FONKSIYON
        static int enfazlakurtarılandugum(int[,] harita, List<(int, int)> baslangicnoktalari)
        {
            int N = harita.GetLength(0);
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            //ROBOTUUN HAREKET EDEBİLECEGİ YÖNLER
            int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            //HER ROBOT İÇİN DFS UYGULAYAN FONSKIYON
            void Dfs(int x, int y)
            {   
                //HEDEF GECERLİ DEGİLSE VEYA ZİYARET EDİLDİYSE ÇIK
                if (x < 0 || x >= N || y < 0 || y >= N || harita[x, y] == 0 || visited.Contains((x, y)))
                    return;

                //DÜĞÜMÜ ZİYARET ET
                visited.Add((x, y));

                //KOMŞU HUCRELERE DFS UYGULA
                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    Dfs(x + directions[i, 0], y + directions[i, 1]);
                }
            }

            //HER ROBOT İÇİN BASLANGIC NOKTASINDAN DFS BASLAT
            foreach (var start in baslangicnoktalari)
            {
                int x = start.Item1;
                int y = start.Item2;
                if (harita[x, y] == 1) //BASLANGIC NOKTASI KURTARILABILIR OLMALI
                {
                    Dfs(x, y);
                }
            }

            return visited.Count; //KURTARILAN DUGUM SAYISINI DONDUR
        }
    }
}
