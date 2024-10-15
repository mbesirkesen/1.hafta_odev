using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MUHAMMED BESİR KESEN GURURLA SUNAR ;)
 
namespace matris_carpimi
{
    class Program
    {
        static void Main(string[] args)
        {   //MATRİSLERİN BOYUTUNU BELİRLEME
            Console.Write("lutfen matrisin boyutunu giriniz(N): ");
            int n = int.Parse(Console.ReadLine());

          
            //MATRİSLERİ OLUSTURMA
            int[,] matris1 = new int[n, n];
            int[,] matris2 = new int[n, n];
            int[,] sonucmatrisi = new int[n, n];
            //MATRİSLERİ DOLDURMA
            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < n ; j++)
                {   
                    Console.Write("lutfen 1. matrisimiz için sayi girelim : ");
                    int k = int.Parse(Console.ReadLine());
                    matris1[i, j] = k;
                }
            }
            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < n ; j++)
                {
                    Console.Write("lutfen 2. matrisimiz için sayi girelim : ");
                    int k = int.Parse(Console.ReadLine());
                    matris2[i, j] = k;
                }
            }
            //MATRİS CARPİMİNİ YAPIP SONUC MATRISINE YAZDIRMA
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sonucmatrisi[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sonucmatrisi[i, j] += matris1[i, k] * matris2[k, j]; // LİNEER CEBİRDEKİ MATRİS CARPIMI
                    }
                }
                
              
            }
            //SONUC MATRİSİNİ EKRANA YAZDIRMA
            Console.WriteLine("Matrisin çarpım sonucu:");
            for (int i= 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(sonucmatrisi[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
