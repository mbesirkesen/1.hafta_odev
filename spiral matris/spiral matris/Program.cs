using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiral_matris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Matris boyutunu girin (N): ");
            int n = int.Parse(Console.ReadLine());
            //matrisi tanımlama
            int[,] spiralmatris = new int[n, n];
            //değisken tanımlama
            int mami = 1;
            int L = 0, k = n - 1, sag = n - 1, sol = 0;
            //matrisin içine spiral sekilde yazdırma
            while (mami <= n * n)
            {
                //soldan sağa yazdırma
                for (int i = sol; i <= sag; i++)
                {
                    spiralmatris[L, i] = mami;
                    mami++;
                }
                L++;
                //yukarından aşşagıya dogru yazdırma
                for (int i = L; i <= sag; i++)
                {
                    spiralmatris[i, sag] = mami;
                    mami++;

                }
                sag--;
                //sagdan sola dogru yazdırma
                for (int i = sag; i >= sol; i--)
                {
                    spiralmatris[k, i] = mami;
                    mami++;
                }
                k--;
                //aşşağıdan yukarıya dogru yazdırma
                for (int i = sag; i > sol; i--)
                {
                    spiralmatris[i, sol] = mami;
                    mami++;
                }
                sol++;
            }
            //olusturdugumuz matrisi ekrana yazdırma
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(spiralmatris[i, j] + "\t");
                }
            }
            Console.ReadKey();
          
        }
    }
}
