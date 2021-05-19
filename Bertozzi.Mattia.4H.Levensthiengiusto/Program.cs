using System;

namespace Bertozzi.Mattia._4H.Levensthiengiusto
{
    class Program
    {
        static public string publicS { get; set; }
        static public string publicT { get; set; }

        static void Main(string[] args)
        {
            string s = "naso";
            publicS = s;
            string t = "casa";
            publicT = t;

            Console.WriteLine($"\nla distanza di Levenshtein tra '{s}' e '{t}' è {DistanzaLevenshtein(s,t)}");
        }

        static int DistanzaLevenshtein(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            //punto 2.1
            if (n==0)
                return m;
            //punto 2.2
            if (m == 0)
                return n;

            //inizializzare la matrice m+1 righe,n+1 colonne
            int[,] distanze = new int[m+1,n+1];

            //punto 3.1
            //riga 01234
            for (int i = 0; i < n+1; i++)
            {
                distanze[0, i] = i;
            }
            //punto 3.2
            //colonna 01234
            for (int j = 0; j < m+1; j++)
            {
                distanze[j, 0] = j;
            }

            //extra
            //StampaMatrice(distanze);
            Console.WriteLine("\n\n");

            //punto 4
            //i righe
            for (int i = 0; i < n; i++)
            {
                //j colonne
                for (int j = 0; j < m; j++)
                {
                    //punto 4.1
                    //int costo = (s[i]==t[j]) ? 0 : 1;
                    //t[j] contiene il carattere della parola nella riga
                    //s[i] contiene il carattere della parola nella colonna

                    int costo;
                    if (t[j] == s[i])
                        costo = 0;
                    else
                        costo = 1;

                    //punto 4.2
                    distanze[j + 1, i + 1] = Minimo(distanze[j+1,i]+1, distanze[j,i+1]+1, distanze[j,i]+costo);
                }
            }

            StampaMatrice(distanze);
            //punto 5
            return distanze[m,n];
        }
        static int Minimo(int a,int b,int c)
        {
            int ret = a;
            if (b < ret)
                ret= b;
            if (c < ret)
                ret= c;

            return ret;
        }

        static void StampaMatrice(int[,] distanze)
        {
            for (int i = 0; i < publicS.Length+1; i++)
            {
                //Console.WriteLine("\n");
                for (int j = 0; j < publicT.Length+1; j++)
                    Console.Write(distanze[i, j]);
                    Console.WriteLine();
            }
        }
    }
}
