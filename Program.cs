namespace Stefans_ATM
{
    internal class Program
    {
        static string[] kund = { "Stefan", "Tobias", "Anas", "Johanna", "Pär" };
        static string[] pinkod = { "1111", "2222", "3333", "4444", "5555" };

        static bool LoggaIn(string användarnamn, string lösenord)
        {
            for (int i = 0; i < kund.Length; i++)
            {
                if (användarnamn == kund[i] && lösenord == pinkod[i])
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
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

            }
            else
            {
                Console.WriteLine("Fel kundnamn eller pinkod. Försök igen.");
            }

        }
    }
}
