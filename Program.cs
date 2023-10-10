using System;

namespace Stefans_ATM
{
    internal class Program
    {

        static string[] kund = { "stefan", "tobias", "anas", "johanna", "pär" };
        static string[] pinkod = { "1111", "2222", "3333", "4444", "5555" };

      
        static string[][] användaresKonton = new string[5][];
        static decimal[][] användaresSaldon = new decimal[5][];

       
        static void SkapaAnvändarnasKonton()
        {
            användaresKonton[0] = new string[] { "Sparkonto", "Lönekonto" };
            användaresSaldon[0] = new decimal[] { 1000.0m, 500.0m };  

            användaresKonton[1] = new string[] { "Bilkonto" };           
            användaresSaldon[1] = new decimal[] { 1500.0m };          

            användaresKonton[2] = new string[] { "Båtkonto", "Sparkonto" }; 
            användaresSaldon[2] = new decimal[] { 2000.0m, 3000.0m }; 

            användaresKonton[3] = new string[] { "Aktiekonto", "Fondkonto" }; 
            användaresSaldon[3] = new decimal[] { 750.0m, 300.0m };   

            användaresKonton[4] = new string[] { "Matkonto" };          
            användaresSaldon[4] = new decimal[] { 2500.0m };         
        }
        static bool LoggaIn(string userName, string password)
        {
            for (int i = 0; i < kund.Length; i++)
            {
                if (userName == kund[i] && password == pinkod[i])
                {
                    Console.WriteLine("Välkommen " + kund[i]);
                    return true;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            bool användarenÄrInloggad = false;
            string inloggadAnvändare = "";

            int försök = 0;
            int maxFörsök = 3;

            while (!användarenÄrInloggad && försök < maxFörsök)
            {
                Console.WriteLine("--------------------Välkommen till Stefans ATM----------------------");
                Console.Write("Ange kundnamn:\n ");
                string användarnamn = Console.ReadLine().ToLower();
                Console.Write("Ange pinkod:\n ");
                string lösenord = Console.ReadLine();

                if (LoggaIn(användarnamn, lösenord))
                {
                    Console.WriteLine("Välkommen " + användarnamn);
                    Console.Clear();

                    inloggadAnvändare = användarnamn; 
                    användarenÄrInloggad = true;
                }
                else
                {
                    Console.WriteLine("Fel kundnamn eller pinkod. Försök igen.");
                    försök++;
                }
            }

            if (!användarenÄrInloggad)
            {
                Console.WriteLine("Du har överträtt maximalt antal inloggningsförsök. Programmet avslutas.");
            }
            else
            {
                bool myBool = true;
                while (myBool)
                {
                    Console.WriteLine("[1]. Se konton och saldo\n");
                    Console.WriteLine("[2]. Överföring mellan konton\n");
                    Console.WriteLine("[3]. Ta ut pengar\n");
                    Console.WriteLine("[4]. Logga ut\n");

                    Console.WriteLine("Ange val");

                    int menyVal = 0;
                    try
                    {
                        menyVal = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("\tFelaktigt kommando");
                    }

                    switch (menyVal)
                    {
                        case 1:
                            Console.Clear();

                            SkapaAnvändarnasKonton();

                            int användarIndex = Array.IndexOf(kund, inloggadAnvändare);

                            if (användarIndex != -1)
                            {
                                for (int i = 0; i < användaresKonton[användarIndex].Length; i++)
                                {
                                    Console.WriteLine($"{användaresKonton[användarIndex][i]}, Saldo: {användaresSaldon[användarIndex][i]:C}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Användaren hittades inte eller har inga konton.");
                            }

                            Console.WriteLine("Tryck Enter för att återgå till menyn...");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Från vilket konto vill du föra över pengar från");
                            Console.WriteLine("Tryck Enter för att återgå till menyn...");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Ange belopp för uttag: ");
                            Console.WriteLine("Tryck Enter för att återgå till menyn...");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Du har loggats ut.");
                            myBool = false;
                            break;

                        default:
                            Console.WriteLine("Felaktigt val!");
                            break;
                    }
                }
            }
        }
    }
}