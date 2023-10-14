namespace Stefans_ATM
{
    internal class Program
    {


                                           
        static string[] användare = { "stefan", "tobias", "anas", "johanna", "pär" };                   //Användarna som har tillgång till bankomaten
        static string[] pinkoder = { "1111", "2222", "3333", "4444", "5555" };                          //Deras lösenord i turordning


        static string[][] användaresKonton = new string[5][];       
        static decimal[][] användaresSaldon = new decimal[5][];
        static void SkapaAnvändarnasKonton()                                                            // En funktion för att spara och lagra användarnas konton och saldon
        {
            användaresKonton[0] = new string[] { "Sparkonto", "Lönekonto", "Matkonto" };
            användaresSaldon[0] = new decimal[] { 10000.0m, 5000.0m, 2000.0m };

            användaresKonton[1] = new string[] { "Bilkonto", "Mobilkonto", "Sparkonto" };
            användaresSaldon[1] = new decimal[] { 1500.0m, 500.0m, 10000,0m };

            användaresKonton[2] = new string[] { "Båtkonto", "Sparkonto" };
            användaresSaldon[2] = new decimal[] { 2000.0m, 3000.0m };

            användaresKonton[3] = new string[] { "Aktiekonto", "Fondkonto", "Hästkonto", "Klädkonto" };
            användaresSaldon[3] = new decimal[] { 750.0m, 300.0m, 5000,0m, 1000,0m };

            användaresKonton[4] = new string[] { "Matkonto", "Godiskonto" };
            användaresSaldon[4] = new decimal[] { 2500.0m, 1000.0m };
        }

        static void Main(string[] args)
        {
            int felaktigaFörsök = 0;                                                                    // Variabler för att hålla koll på antal felaktiga försök, inloggningens status och inloggad användare.
            bool inloggningLyckades = false;
            string inloggadAnvändare = null;

            while (true)                                                                               // En oändlig loop som körs tills användaren lyckas logga in eller överskrider max antal felaktiga försök.
            {
                inloggningLyckades = LoggaIn(användare, pinkoder, out inloggadAnvändare);

                if (inloggningLyckades)                                                                // Vid lyckad inloggning skrivs nedan kod ut
                {
                    Console.WriteLine($"Inloggningen lyckades. Välkommen, {inloggadAnvändare}!");
                    Console.Clear();

                    Meny(inloggadAnvändare);
                }
                else                                                                                   // Vid misslyckad inloggning
                { 
                    Console.WriteLine("Inloggningen misslyckades. Vänligen försök igen.");
                    felaktigaFörsök++;
                    if (felaktigaFörsök >= 3)                                                          // Om du ej lyckat logga in på 3 försök.
                    {
                        Console.WriteLine("Du har uppnått max antal felaktiga inloggningsförsök. Programmet avslutas.");
                        break; 
                    }
                }
            }
        }

        static bool LoggaIn(string[] användare, string[] pinkoder, out string inloggadAnvändare)           // En logga in funktion, som ber användaren skriva in användarnamn och pin-kod
        {
            Console.WriteLine("--------------------Välkommen till Stefans ATM----------------------");
            Console.WriteLine();
            Console.WriteLine("Ange ditt användarnamn: ");
            string användaridentifierare = Console.ReadLine().ToLower();

            Console.WriteLine("Ange din PIN-kod: ");
            string pinKod = Console.ReadLine();

            for (int i = 0; i < användare.Length; i++)                                                  // Loopar igenom användar- och pinkod-arraysen för att hitta en matchning.
            {
                if (användaridentifierare == användare[i] && pinKod == pinkoder[i])                     // Om användarnamn och pin-kod matchar, så blir det en lyckad inloggning, samt att vi har en inloggad användare
                {
                    inloggadAnvändare = användare[i];                                                   
                    return true; 
                }
            }

            inloggadAnvändare = null;                                                                   // Om ingen matchning hittades, återställ inloggadAnvändare och returnera false.
            return false; 
        }

        static void Meny(string inloggadAnvändare)                                                      // Vid lyckad inloggning så skickas användaren hit till menyn.
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

                string val = Console.ReadLine();                                                        // Läser av användarens val från menyn
                int användarIndex = Array.IndexOf(användare, inloggadAnvändare);                        // Hitta index för inloggad användare i användare-arrayen.

                switch (val)
                {
                    case "1":
                        Console.Clear();
                        SkapaAnvändarnasKonton();                                                       // Hämtar inloggade användarens konton och saldon
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
                        ÖverföringMellanKonton(inloggadAnvändare);                                         // Utför överföring mellan konton´för inloggad användare
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case "3":
                        Console.Clear();
                        TaUtPengar(inloggadAnvändare);                                                      // Utför uttag av pengar från kontot för inloggad användare
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Du har loggat ut.");
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        loggadUt = true;                                                                    // Loggar ut användaren
                        Console.Clear();
                        return;                                                                             // Avslutar loopen och därmed menyn.

                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        Console.WriteLine("Tryck Enter för att återgå till menyn...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }



        static void ÖverföringMellanKonton(string inloggadAnvändare)                        
        {
            int användareIndex = Array.IndexOf(användare, inloggadAnvändare);

            if (användareIndex == -1)
            {
                Console.WriteLine("Användaren hittades inte.");
                return;
            }

            Console.WriteLine("Dina befintliga konton:");
            for (int i = 0; i < användaresKonton[användareIndex].Length; i++)
            {
                Console.WriteLine($"{i + 1}. {användaresKonton[användareIndex][i]}, Saldo: {användaresSaldon[användareIndex][i]:C}");
            }

            int frånKontoIndex = VäljIndex(användaresKonton[användareIndex].Length, "Välj ett konto att ta pengar från (ange numret):");
            int tillKontoIndex = VäljIndex(användaresKonton[användareIndex].Length, "Välj ett konto att flytta pengarna till (ange numret):", frånKontoIndex);
            decimal överförBelopp = VäljDecimal(0, användaresSaldon[användareIndex][frånKontoIndex], "Ange beloppet att flytta:");

            användaresSaldon[användareIndex][frånKontoIndex] -= överförBelopp;
            användaresSaldon[användareIndex][tillKontoIndex] += överförBelopp;

            Console.WriteLine("Överföringen lyckades.");
            Console.WriteLine($"Det nya saldot på {användaresKonton[användareIndex][frånKontoIndex]} är: {användaresSaldon[användareIndex][frånKontoIndex]:C}");
            Console.WriteLine($"Det nya saldot på {användaresKonton[användareIndex][tillKontoIndex]} är: {användaresSaldon[användareIndex][tillKontoIndex]:C}");
        }

        static int VäljIndex(int max, string meddelande)
        {
            int valtIndex;
            while (true)
            {
                Console.WriteLine(meddelande);
                if (int.TryParse(Console.ReadLine(), out valtIndex) && valtIndex >= 1 && valtIndex <= max)
                {
                    return valtIndex - 1;
                }
                Console.WriteLine("Ogiltigt val. Vänligen välj ett nummer som representerar ett konto.");
            }
        }

        static int VäljIndex(int max, string meddelande, int exkluderadIndex)
        {
            int valtIndex;
            while (true)
            {
                Console.WriteLine(meddelande);
                if (int.TryParse(Console.ReadLine(), out valtIndex) && valtIndex >= 1 && valtIndex <= max && valtIndex - 1 != exkluderadIndex)
                {
                    return valtIndex - 1;
                }
                Console.WriteLine("Ogiltigt val. Vänligen välj ett nummer som representerar ett annat konto.");
            }
        }

        static decimal VäljDecimal(decimal min, decimal max, string meddelande)
        {
            decimal belopp;
            while (true)
            {
                Console.WriteLine(meddelande);
                if (decimal.TryParse(Console.ReadLine(), out belopp) && belopp > min && belopp <= max)
                {
                    return belopp;
                }
                Console.WriteLine("Ogiltigt belopp. Vänligen ange ett belopp som är inom rätt intervall.");
            }
        }

        static void TaUtPengar(string inloggadAnvändare)
        {
            int användareIndex = Array.IndexOf(användare, inloggadAnvändare);

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

            int valtKontoIndex = VäljIndex(användaresKonton[användareIndex].Length);

            Console.WriteLine("Ange det belopp du vill ta ut:");
            decimal uttagBelopp = VäljDecimal(0, användaresSaldon[användareIndex][valtKontoIndex]);

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

        static int VäljIndex(int max)
        {
            int valtIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out valtIndex) && valtIndex >= 1 && valtIndex <= max)
                {
                    return valtIndex - 1;
                }
                Console.WriteLine("Ogiltigt val. Vänligen välj ett nummer som representerar ett konto.");
            }
        }

        static decimal VäljDecimal(decimal min, decimal max)
        {

            decimal belopp;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out belopp) && belopp > 0 && belopp <= max)
                {
                    return belopp;
                }
                Console.WriteLine("Ogiltigt belopp. Vänligen ange ett belopp som är mindre än eller lika med ditt saldo.");
            }
        }

    }
}
