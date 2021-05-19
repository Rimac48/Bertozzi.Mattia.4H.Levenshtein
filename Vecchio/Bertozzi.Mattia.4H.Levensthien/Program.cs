using System;

namespace Bertozzi.Mattia._4H.Levensthien
{
    class Program
    {
        static void Main(string[] args)
        {

            //cambiare le parole per prove diverse
            //1.
            Console.WriteLine($"Costante: {DistanzaLevenshtein("saturday", "sunday")}");
            Console.WriteLine("\n");
            //Console.WriteLine($"Costante: {DistanzaLevenshtein("rombo", "tromba")}");

            //string g = "casa";
            //Console.WriteLine($"{g[2]}");
        }

        public static int DistanzaLevenshtein(string s, string t)
        {
            //2.
            //se parola ha 4 lettere la matrice avrà quindi 5 righe

            s = s.ToLower();
            t = t.ToLower();
            int n = s.Length;
            int m = t.Length;
            
            //2.1.
            if(n==0)
            {
                //se n=0 su ha DL=m,stampare DL e terminare
                //quindi stampo m
                return m;
            }

            //2.2.
            if (m==0)
            {
                //se n=0 su ha DL=m,stampare DL e terminare
                //quindi stampo n
                return n;
            }

            //3.
            //es: se parola ha 4 lettere la matrice quindi 5 righe,quindi n+1
            int[,] d = new int[n + 1, m + 1];

            //3.1   inizializzo la prima riga con i valori da 0 a n
            for (int i = 0; i <= n;i++)
            {
                d[i, 0] = i;
            }

            //3.2   inizializzo la prima colonna con i valori da 0 a n
            for (int j = 0; j <= m;j++)
            {
                d[0, j] = j;
            }

            //4.    giro la matrice e faccio quel che devo
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int costo;
                    //4.1   se t[j] = s[i] allora costo=0 oppure costo=1
                    //dove t[] sarebbe il carattere della prima parola
                    //dove s[] sarebbe il carattere della seconda parola
                    if(t[j - 1] == s[i - 1])
                    {
                        costo = 0;
                    }
                    else
                    {
                        costo = 1;
                    }

                    //4.2
                    //prendo il minimo valore fra questi
                    int a = d[i - 1, j] + 1;
                    int b = d[i, j - 1] + 1;
                    int c = d[i - 1, j - 1] + costo;

                    if (a <= b && a <= c)
                    {
                        d[i, j] = a;
                    }
                    else if (b <= c && b <= a)
                    {
                        d[i, j] = b;
                    }
                    else
                    {
                        d[i, j] = c;
                    }

                }
            }

            //stampa extra
            //Console.WriteLine($"Parole prese:\n\t{s}\n\t{t}\n");
            //Console.WriteLine("Stampo la matrice");
            //for (int i = 0; i <=n; i++)
            //{
            //    Console.WriteLine("\n");
            //    for (int j = 0; j <=m; j++)
            //        Console.Write(d[i,j]);
            //}

            StampaMatrice(s, t, n, m, d);

            Console.WriteLine("\n");
            //5.
            return d[n,m];
        }

        static void StampaMatrice(string s, string t, int n, int m, int[,] d)
        {
            //stampa extra
            Console.WriteLine($"Parole prese:\n\t{s}\n\t{t}\n");
            Console.WriteLine("Stampo la matrice");
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j <= m; j++)
                    Console.Write(d[i, j]);
            }
        }
    }
}
