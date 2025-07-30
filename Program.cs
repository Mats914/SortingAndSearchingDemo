// Övning 7 - Algoritmer.cs
// Fullständig version med bubbelsortering och binärsökning för både siffror och bokstäver

using System;
using System.Collections.Generic;

namespace Ovning7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            bool intSortering = false; // Håller reda på om siffrorna är sorterade
            bool bokstavSortering = false; // Håller reda på om bokstavslistan är sorterad

            List<int> sifferLista = new List<int>();
            List<string> ordLista = new List<string>();

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n\tVälkommen till Övning 7 - Algoritmer\n\t#########################\n");
                Console.WriteLine("\t[1] Generera siffror");
                Console.WriteLine("\t[2] Sortera siffror (Bubbelsortering)");
                Console.WriteLine("\t[3] Sök siffra (Binärsökning)");
                Console.WriteLine("\t[4] Generera ord (slumpade)");
                Console.WriteLine("\t[5] Sortera ord (Bubbelsortering)");
                Console.WriteLine("\t[6] Sök ord (Binärsökning)");
                Console.WriteLine("\t[7] Avsluta programmet\n");

                Int32.TryParse(Console.ReadLine(), out int meny);

                switch (meny)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n\tHur många siffror vill du generera?");
                        Int32.TryParse(Console.ReadLine(), out int antal);
                        Random rnd = new Random();
                        sifferLista.Clear();
                        for (int i = 0; i < antal; i++)
                        {
                            sifferLista.Add(rnd.Next(1, 100));
                        }
                        Console.WriteLine("\n\tGenererade siffror:");
                        SkrivUtSiffror(sifferLista);
                        intSortering = false;
                        MenyAvslut();
                        break;

                    case 2:
                        Console.Clear();
                        if (sifferLista.Count > 0)
                        {
                            for (int i = 0; i < sifferLista.Count - 1; i++)
                            {
                                for (int j = 0; j < sifferLista.Count - 1 - i; j++)
                                {
                                    if (sifferLista[j] > sifferLista[j + 1])
                                    {
                                        int temp = sifferLista[j];
                                        sifferLista[j] = sifferLista[j + 1];
                                        sifferLista[j + 1] = temp;
                                    }
                                }
                            }
                            Console.WriteLine("\n\tSiffrorna har sorterats:");
                            SkrivUtSiffror(sifferLista);
                            intSortering = true;
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga siffror att sortera. Generera först.");
                        }
                        MenyAvslut();
                        break;

                    case 3:
                        Console.Clear();
                        if (sifferLista.Count > 0 && intSortering)
                        {
                            Console.WriteLine("\n\tAnge siffran du vill söka efter:");
                            Int32.TryParse(Console.ReadLine(), out int key);

                            int första = 0;
                            int sista = sifferLista.Count - 1;
                            bool hittad = false;

                            while (första <= sista)
                            {
                                int mellan = (första + sista) / 2;

                                if (sifferLista[mellan] < key)
                                {
                                    första = mellan + 1;
                                }
                                else if (sifferLista[mellan] > key)
                                {
                                    sista = mellan - 1;
                                }
                                else
                                {
                                    Console.WriteLine($"\n\tSiffran {key} finns på index {mellan}.");
                                    hittad = true;
                                    break;
                                }
                            }

                            if (!hittad)
                            {
                                Console.WriteLine($"\n\tSiffran {key} hittades inte i listan.");
                            }
                        }
                        else if (!intSortering)
                        {
                            Console.WriteLine("\n\tListan är inte sorterad. Sortera innan du söker.");
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga siffror att söka i. Generera först.");
                        }
                        MenyAvslut();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n\tHur många ord vill du generera?");
                        Int32.TryParse(Console.ReadLine(), out int ordAntal);
                        Random rnd2 = new Random();
                        ordLista.Clear();
                        for (int i = 0; i < ordAntal; i++)
                        {
                            char[] chars = new char[rnd2.Next(3, 8)];
                            for (int j = 0; j < chars.Length; j++)
                            {
                                chars[j] = (char)rnd2.Next(97, 123); // a-z
                            }
                            ordLista.Add(new string(chars));
                        }
                        Console.WriteLine("\n\tGenererade ord:");
                        SkrivUtOrd(ordLista);
                        bokstavSortering = false;
                        MenyAvslut();
                        break;

                    case 5:
                        Console.Clear();
                        if (ordLista.Count > 0)
                        {
                            for (int i = 0; i < ordLista.Count - 1; i++)
                            {
                                for (int j = 0; j < ordLista.Count - 1 - i; j++)
                                {
                                    if (ordLista[j].CompareTo(ordLista[j + 1]) > 0)
                                    {
                                        string temp = ordLista[j];
                                        ordLista[j] = ordLista[j + 1];
                                        ordLista[j + 1] = temp;
                                    }
                                }
                            }
                            Console.WriteLine("\n\tOrden har sorterats:");
                            SkrivUtOrd(ordLista);
                            bokstavSortering = true;
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga ord att sortera. Generera först.");
                        }
                        MenyAvslut();
                        break;

                    case 6:
                        Console.Clear();
                        if (ordLista.Count > 0 && bokstavSortering)
                        {
                            Console.WriteLine("\n\tAnge ordet du vill söka efter:");
                            string sökord = Console.ReadLine();
                            int första = 0;
                            int sista = ordLista.Count - 1;
                            bool hittad = false;

                            while (första <= sista)
                            {
                                int mellan = (första + sista) / 2;
                                int jämförelse = ordLista[mellan].CompareTo(sökord);

                                if (jämförelse < 0)
                                {
                                    första = mellan + 1;
                                }
                                else if (jämförelse > 0)
                                {
                                    sista = mellan - 1;
                                }
                                else
                                {
                                    Console.WriteLine($"\n\tOrdet '{sökord}' finns på index {mellan}.");
                                    hittad = true;
                                    break;
                                }
                            }

                            if (!hittad)
                            {
                                Console.WriteLine($"\n\tOrdet '{sökord}' hittades inte i listan.");
                            }
                        }
                        else if (!bokstavSortering)
                        {
                            Console.WriteLine("\n\tListan är inte sorterad. Sortera innan du söker.");
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga ord att söka i. Generera först.");
                        }
                        MenyAvslut();
                        break;

                    case 7:
                        isRunning = false;
                        break;
                }
            }
        }

        static void SkrivUtSiffror(List<int> lista)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (int siffra in lista)
            {
                Console.Write($"{siffra} ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void SkrivUtOrd(List<string> lista)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string ord in lista)
            {
                Console.WriteLine("\t" + ord);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MenyAvslut()
        {
            Console.WriteLine("\n\tTryck ENTER för att återgå till menyn.");
            Console.ReadLine();
        }
    }
}
