namespace Stefans_ATM
{
    internal class Program
    {


        static string[][] användaresKonton = new string[5][];
        static decimal[][] användaresSaldon = new decimal[5][];
        static string[] användare = { "stefan", "tobias", "anas", "johanna", "pär" };
        static string[] pinkoder = { "1111", "2222", "3333", "4444", "5555" };

        static void SkapaAnvändarnasKonton()
        {
            användaresKonton[0] = new string[] { "Sparkonto", "Lönekonto", "Matkonto" };
            användaresSaldon[0] = new decimal[] { 10000.0m, 5000.0m, 2000.0m };

            användaresKonton[1] = new string[] { "Bilkonto", "Mobilkonto" };
            användaresSaldon[1] = new decimal[] { 1500.0m, 500.0m };

            användaresKonton[2] = new string[] { "Båtkonto", "Sparkonto" };
            användaresSaldon[2] = new decimal[] { 2000.0m, 3000.0m };

            användaresKonton[3] = new string[] { "Aktiekonto", "Fondkonto" };
            användaresSaldon[3] = new decimal[] { 750.0m, 300.0m };

            användaresKonton[4] = new string[] { "Matkonto", "Godiskonto" };
            användaresSaldon[4] = new decimal[] { 2500.0m, 1000.0m };
        }

        static void Main(string[] args)
        {


            int felaktigaFörsök = 0;
            bool inloggningLyckades = false;
            string inloggadAnvändare = null;

            while (true)
            {
                inloggningLyckades = LoggaIn(användare, pinkoder, out inloggadAnvändare);

                if (inloggningLyckades)
                {
                    Console.WriteLine($"Inloggningen lyckades. Välkommen, {inloggadAnvändare}!");
                    Console.Clear();

                    HanteraBankFunktioner(inloggadAnvändare);
                }
                else
                {
                    Console.WriteLine("Inloggningen misslyckades. Vänligen försök igen.");
                    felaktigaFörsök++;
                    if (felaktigaFörsök >= 3)
                    {
                        Console.WriteLine("Du har uppnått max antal felaktiga inloggningsförsök. Programmet avslutas.");
                        break; 
                    }
                }
            }
        }

        static bool LoggaIn(string[] användare, string[] pinkoder, out string inloggadAnvändare)
        {
            Console.WriteLine("--------------------Välkommen till Stefans ATM----------------------");
            Console.WriteLine();
            Console.WriteLine("Ange ditt användarnamn/användarnummer: ");
            string användaridentifierare = Console.ReadLine().ToLower();

            Console.WriteLine("Ange din PIN-kod: ");
            string pinKod = Console.ReadLine();

            for (int i = 0; i < användare.Length; i++)
            {
                if (användaridentifierare == användare[i] && pinKod == pinkoder[i])
                {
                    inloggadAnvändare = användare[i];
                    return true; 
                }
            }

            inloggadAnvändare = null;
            return false; 
        }

        static void HanteraBankFunktioner(string inloggadAnvändare)
        {
            bool loggadUt = false;
            while (true)
            {
                Console.WriteLine("--------------------Välkommen till Stefans ATM----------------------");
                Console.WriteLine();
                Console.WriteLine("Välj en av följande alternativ:");
                Console.WriteLine("1. Se dina konton och saldo");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");

                string val = Console.ReadLine();
                int användarIndex = Array.IndexOf(användare, inloggadAnvändare);
                switch (val)
                {
                    case "1":
                        Console.Clear();
                        SkapaAnvändarnasKonton();
                        if (användarIndex != -1)
                        {
                            for (int i = 0; i < användaresKonton[användarIndex].Length; i++)
                            {
                                Console.WriteLine($"{användaresKonton[användarIndex][i]}, Saldo: {användaresSaldon[användarIndex][i]:C}");
                            }
                        }
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        ÖverföringMellanKonton(inloggadAnvändare);
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        TaUtPengar(inloggadAnvändare);
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Du har loggat ut.");
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        loggadUt = true;
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        static void SeKontonOchSaldo(string inloggadAnvändare)
        {
            for (int i = 0; i < användare.Length; i++)
            {
                if (inloggadAnvändare == användare[i])
                {
                    if (användaresKonton[i] != null && användaresSaldon[i] != null)
                    {
                        Console.WriteLine($"Konton och saldo för användare: {inloggadAnvändare}");
                        for (int j = 0; j < användaresKonton[i].Length; j++)
                        {
                            string konto = användaresKonton[i][j];
                            decimal saldo = användaresSaldon[i][j];
                            Console.WriteLine($"{konto}: {saldo:C}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Användaren har inga konton eller saldon.");
                    }
                    return;
                }
            }
        }

        static void ÖverföringMellanKonton(string användare)
        {
            Console.WriteLine($"Överföring mellan konton för användare: {användare}");
        }

        static void TaUtPengar(string inloggadAnvändare)
        {
            int användareIndex = -1;
            for (int i = 0; i < användare.Length; i++)
            {
                if (inloggadAnvändare == användare[i])
                {
                    användareIndex = i;
                    break;
                }
            }

            if (användareIndex == -1)
            {
                Console.WriteLine("Användaren hittades inte.");
                return;
            }

            Console.WriteLine("Välj ett konto att ta ut pengar från:");

            for (int i = 0; i < användaresKonton[användareIndex].Length; i++)
            {
                Console.WriteLine($"{i + 1}. {användaresKonton[användareIndex][i]}");
            }

            int valtKontoIndex = -1;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out valtKontoIndex) && valtKontoIndex >= 1 && valtKontoIndex <= användaresKonton[användareIndex].Length)
                {
                    valtKontoIndex--;
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Vänligen välj ett nummer som representerar ett konto.");
                }
            }

            Console.WriteLine("Ange det belopp du vill ta ut:");
            decimal uttagBelopp = 0;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out uttagBelopp) && uttagBelopp > 0 && uttagBelopp <= användaresSaldon[användareIndex][valtKontoIndex])
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp. Vänligen ange ett belopp som är mindre än eller lika med ditt saldo.");
                }
            }

            Console.WriteLine("Ange din PIN-kod för att bekräfta:");
            string pinKod = Console.ReadLine();

            if (pinKod == pinkoder[användareIndex])
            {
                användaresSaldon[användareIndex][valtKontoIndex] -= uttagBelopp;
                Console.WriteLine("Pengar har tagits ut.");
                Console.WriteLine($"Det nya saldot på {användaresKonton[användareIndex][valtKontoIndex]} är: {användaresSaldon[användareIndex][valtKontoIndex]:C}");
            }
            else
            {
                Console.WriteLine("PIN-koden är felaktig. Transaktionen avbruten.");
            }
        }

    }
}
