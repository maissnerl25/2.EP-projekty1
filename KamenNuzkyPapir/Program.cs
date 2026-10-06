namespace KamenNuzkyPapir;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] nazvy = { "kámen", "nůžky", "papír" };
        Random nahoda = new Random();

        int vyhry = 0, prohry = 0, remizy = 0;

        Console.WriteLine("Kámen – nůžky – papír");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Vyber: 1 = kámen, 2 = nůžky, 3 = papír, 0 = konec");
            Console.Write("Tvůj hod: ");

            if (!int.TryParse(Console.ReadLine(), out int volba) || volba < 0 || volba > 3)
            {
                Console.WriteLine("Neplatná volba, zkus to znovu.");
                continue;
            }

            if (volba == 0)
                break;

            int hrac = volba - 1;      // 0 = kámen, 1 = nůžky, 2 = papír
            int hod = nahoda.Next(3);

            Console.WriteLine($"Ty: {nazvy[hrac]}, počítač: {nazvy[hod]}");

            if (hrac == hod)
            {
                Console.WriteLine("Remíza!");
                remizy++;
            }
            else if ((hrac == 0 && hod == 1) ||   // kámen tupí nůžky
                     (hrac == 1 && hod == 2) ||   // nůžky stříhají papír
                     (hrac == 2 && hod == 0))     // papír zabalí kámen
            {
                Console.WriteLine("Vyhrál jsi!");
                vyhry++;
            }
            else
            {
                Console.WriteLine("Prohrál jsi.");
                prohry++;
            }

            Console.WriteLine($"Skóre – Výhry: {vyhry} | Prohry: {prohry} | Remízy: {remizy}");
        }

        Console.WriteLine();
        Console.WriteLine("Konečné skóre:");
        Console.WriteLine($"Výhry: {vyhry}, prohry: {prohry}, remízy: {remizy}");

        if (vyhry > prohry)
            Console.WriteLine("Celkově jsi vyhrál!");
        else if (vyhry < prohry)
            Console.WriteLine("Celkově vyhrál počítač.");
        else
            Console.WriteLine("Celkově remíza.");
    }
}

