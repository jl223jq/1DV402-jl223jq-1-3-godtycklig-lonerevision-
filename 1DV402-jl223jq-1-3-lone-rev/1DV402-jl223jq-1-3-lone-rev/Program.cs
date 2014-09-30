using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402_jl223jq_1_3_lone_rev
{
    class Program
    {
        static void Main(string[] args)
        {
            int antalLoner;
            do
            {
                Console.Clear(); //måste ligga här för att rensa konsollen korrekt
                antalLoner = MangdLoner("Ange antal löner att mata in: "); // går ner till rad 36 för att hämta direktiv
                
                if (antalLoner > 1) //ser till så att det inte går att göra beräkning med färre än 2 löner
                {
                    Loneforvaring(antalLoner); //går ner till rad 62 för att hämta direktiv
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("För få löner, anställ fler!");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("Vill du göra en ny uträkning? Tryck på valfri tangent för att försöka igen, tryck på ESC om du vill avsluta.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape); // detta styr vad som händer när man har beräknat klart, "false" leder till att knappen man tryckte in skrivs ut i konsollen.

        }
        static int MangdLoner(string prompt)
        {
            int mangd;
            do
            {
                string anvandartal;
                Console.Write(prompt);
                anvandartal = Console.ReadLine();
                try
                {
                    mangd = int.Parse(anvandartal);
                    break;
                }
                catch
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! Du måste ange ett heltal.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            } 
            while (true);
            return mangd;
       }

        static void Loneforvaring(int mangd)
        {
            int[] betalning = new int[mangd];

            for (int i = 0; i < mangd; ++i)
            {
                betalning[i] = MangdLoner("Ange lön nr: "+ (1 + i) +": ");
            }
            int[] presentation = (int[])betalning.Clone();

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");

            Array.Sort(betalning);

            int skillnad = betalning.Max() - betalning.Min();

            Console.WriteLine("Lönesskillnad :      {0:c0}", skillnad);
            Console.WriteLine("Medelvärdet   :      {0:c0}", betalning.Average());
            if (betalning.Length % 2 == 0)
            {
                int mittennummer1 = betalning.Length / 2;
                int mittennummer2 = betalning.Length / 2 - 1;
                int median = (betalning[mittennummer1] + betalning[mittennummer2]) / 2;
                Console.WriteLine("Medianen         :          {0:c0}", median);
            }

            if (betalning.Length % 2 == 1)
            {
                int OjamnMedian = betalning.Length / 2;
                Console.WriteLine("Medianen         :          {0:c0}", betalning[OjamnMedian]);
            }

            Console.WriteLine("----------------------------------------------------");

            for (int i = 0; i < betalning.Length; ++i)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }

                    Console.Write("  {0,5}  ", presentation[i]);
            }
            Console.WriteLine();
        }

    }
}
