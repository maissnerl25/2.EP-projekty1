namespace Sibenice;

internal class Program
{
    static void Main()
    {
        string[] slovicka = File.ReadAllLines("slovnicek.txt");
        Random nahoda = new Random();
        string slovo = slovicka[nahoda.Next(slovicka.Length)].Trim().ToLower();

        char[] odhad = new string('_', slovo.Length).ToCharArray();
        List<char> pouzita = new List<char>();
        const int maxChyb = 7;
        int chyb = 0;

        Console.WriteLine("Šibenice");

        while (chyb < maxChyb && new string(odhad) != slovo)
        {
            Console.WriteLine();
            Console.WriteLine("Slovo: " + string.Join(" ", odhad));
            Console.WriteLine($"Chyby: {chyb}/{maxChyb}  Použitá písmena: {string.Join(", ", pouzita)}");
            Console.Write("Tipni písmeno: ");
            string? vstup = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(vstup) || vstup.Length != 1 || !char.IsLetter(vstup[0]))
            {
                Console.WriteLine("Zadej právě jedno písmeno.");
                continue;
            }

            char pismeno = vstup[0];

            if (pouzita.Contains(pismeno))
            {
                Console.WriteLine("Toto písmeno už jsi zkoušel.");
                continue;
            }

            pouzita.Add(pismeno);

            if (slovo.Contains(pismeno))
            {
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == pismeno) odhad[i] = pismeno;
                }
            }
            else
            {
                chyb++;
                Console.WriteLine("Tam není.");
            }
        }

        Console.WriteLine();
        if (new string(odhad) == slovo)
            Console.WriteLine($"Vyhrál jsi! Slovo bylo: {slovo}");
        else
            Console.WriteLine($"Prohrál jsi. Slovo bylo: {slovo}");
    }
}
