namespace Stefans_ATM
{
    internal class Program
    {

        static string[] kund = { "Stefan", "Tobias", "Anas", "Johanna", "Pär" };
        static string[] pinkod = { "1111", "2222", "3333", "4444", "5555" };
        static string[][] kontonArray =
            {
            new string[] { "Sparkonto", "Lönekonto" },
            new string[] { "Sparkonto" },
            new string[] {"Lönekonto", "Resekonto" },
            new string[] { "Bilkonto", "Lönekonto" },
            new string[] { "Fondsparande" }
            };


        static bool LoggaIn(string användarnamn, string lösenord)
        {
            for (int i = 0; i < kund.Length; i++)
            {
                if (användarnamn == kund[i] && lösenord == pinkod[i])
                {
                    Console.WriteLine("Välkommen " + kund[i]);
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            int försök = 0;
            int maxFörsök = 3;
            bool lyckadInloggning = false;

            while (försök < maxFörsök && !lyckadInloggning)
            {
                Console.WriteLine("--------------------Välkommen till Stefans ATM----------------------");
                Console.Write("Ange kundnamn:\n ");
                string användarnamn = Console.ReadLine();
                Console.Write("Ange pinkod:\n ");
                string lösenord = Console.ReadLine();

                if (LoggaIn(användarnamn, lösenord))
                {
                    Console.WriteLine("Kundnamn korrekt");
                    Console.Clear();
                    lyckadInloggning = true;
                }
                else
                {
                    Console.WriteLine("Fel kundnamn eller pinkod. Försök igen.");
                    försök++;
                }
            }

            if (!lyckadInloggning)
            {
                Console.WriteLine("Du har överträtt maximalt antal inloggningsförsök. Programmet avslutas.");
            }
            else
            {
                int choice = 0;
                while (true)
                {
                    Console.WriteLine("--------------------Välkommen till Stefans ATM----------------------\n");
                    Console.WriteLine("1. Se konton och saldo\n");
                    Console.WriteLine("2. Överföring mellan konton\n");
                    Console.WriteLine("3. Ta ut pengar\n");
                    Console.WriteLine("4. Logga ut\n");

                    Console.WriteLine("Ange val");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Konton och saldo: ");
                            break;

                        case 2:
                            Console.WriteLine("Från vilket konto vill du föra över pengar från");
                            break;

                        case 3:
                            Console.WriteLine("Ange belopp för uttag: ");
                            break;

                        case 4:
                            Console.WriteLine("Tack för idag!");
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