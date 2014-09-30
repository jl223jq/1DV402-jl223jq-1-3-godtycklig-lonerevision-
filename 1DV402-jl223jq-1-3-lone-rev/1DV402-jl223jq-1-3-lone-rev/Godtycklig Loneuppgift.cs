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
                Console.Clear();          
                antalLoner = MangdLoner("Ange antal löner att mata in: ");
                
                if (antalLoner > 1) 
                {
                    LoneForvaring(antalLoner); 
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
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        static int MangdLoner(string prompt)
        {
            int mangd;
            //Ger användaren möjlighet att ange tal och skickar dessa vidare
            do
            {
                string inputtal;
                Console.Write(prompt);
                inputtal = Console.ReadLine();
                try
                {
                    mangd = int.Parse(inputtal);
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

        static void LoneForvaring(int mangd)
        {
            //Skapar en array för att ta hand om inmatade tal
            int[] lon = new int[mangd];

            for (int i = 0; i < mangd; ++i)
            {
                lon[i] = MangdLoner("Ange lön nr: " + (i + 1) + ": ");
            }
            //Kopierar arrayens värden till en ny variabel
            int[] presentation = (int[])lon.Clone();


            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");

            Array.Sort(lon);
            //Skapar en variabel som är skillanden mellan högsta och lägsta lönen
            int skillnad = lon.Max() - lon.Min();
            Console.WriteLine("Lönesskillnad :      {0:c0}", skillnad);
            Console.WriteLine("Medelvärdet   :      {0:c0}", lon.Average());
            
            //Skapar medianvärden
            if (lon.Length % 2 == 0)
            {
                int mittenvarde1 = lon.Length / 2;
                int mittenvarde2 = (lon.Length / 2) - 1;
                int jamnmedian = (lon[mittenvarde1] + lon[mittenvarde2]) / 2;
                Console.WriteLine("Medianen      :      {0:c0}", jamnmedian);
            }

            if (lon.Length % 2 == 1)
            {
                int ojamnmedian = lon.Length / 2;
                Console.WriteLine("Medianen      :      {0:c0}", lon[ojamnmedian]);
            }

            Console.WriteLine("----------------------------------------------------");

            for (int i = 0; i < lon.Length; ++i)
            {
                //Ger radbyte efter tre inmatade tal uppräknats
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                    //Räknar upp talen i arrayen
                    Console.Write(String.Format("  {0,5}  ", presentation[i]));
            }
            Console.WriteLine();
        }

    }
}
