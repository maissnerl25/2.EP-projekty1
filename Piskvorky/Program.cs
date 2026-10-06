namespace Piskvorky;

internal class Program
{
    const int Velikost = 3;

    static void Main()
    {
        char[,] pole = new char[Velikost, Velikost];
        for (int r = 0; r < Velikost; r++)
            for (int s = 0; s < Velikost; s++)
                pole[r, s] = ' ';

        char hrac = 'X';
        int tahu = 0;

        while (true)
        {
            Vykresli(pole);
            Console.Write($"Hráč {hrac} – zadej řádek a sloupec (1-{Velikost}), např. '2 3': ");
            string[]? casti = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (casti == null || casti.Length != 2 ||
                !int.TryParse(casti[0], out int radek) ||
                !int.TryParse(casti[1], out int sloupec) ||
                radek < 1 || radek > Velikost || sloupec < 1 || sloupec > Velikost)
            {
                Console.WriteLine("Neplatný vstup.");
                continue;
            }

            radek--; sloupec--;

            if (pole[radek, sloupec] != ' ')
            {
                Console.WriteLine("Toto políčko je obsazené.");
                continue;
            }

            pole[radek, sloupec] = hrac;
            tahu++;

            if (Vyhral(pole, hrac))
            {
                Vykresli(pole);
                Console.WriteLine($"Vyhrál hráč {hrac}!");
                break;
            }

            if (tahu == Velikost * Velikost)
            {
                Vykresli(pole);
                Console.WriteLine("Remíza!");
                break;
            }

            hrac = hrac == 'X' ? 'O' : 'X';
        }
    }

    static void Vykresli(char[,] pole)
    {
        Console.WriteLine();
        Console.WriteLine("    1   2   3");
        for (int r = 0; r < Velikost; r++)
        {
            Console.Write($"{r + 1}   ");
            for (int s = 0; s < Velikost; s++)
            {
                Console.Write(pole[r, s]);
                if (s < Velikost - 1) Console.Write(" | ");
            }
            Console.WriteLine();
            if (r < Velikost - 1) Console.WriteLine("   ---+---+---");
        }
        Console.WriteLine();
    }

    static bool Vyhral(char[,] p, char h)
    {
        for (int i = 0; i < Velikost; i++)
        {
            if (p[i, 0] == h && p[i, 1] == h && p[i, 2] == h) return true; // řádek
            if (p[0, i] == h && p[1, i] == h && p[2, i] == h) return true; // sloupec
        }
        if (p[0, 0] == h && p[1, 1] == h && p[2, 2] == h) return true;     // úhlopříčka
        if (p[0, 2] == h && p[1, 1] == h && p[2, 0] == h) return true;     // úhlopříčka
        return false;
    }
}
