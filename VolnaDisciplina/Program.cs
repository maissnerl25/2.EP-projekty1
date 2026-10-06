namespace VolnaDisciplina;

// Volná disciplína: Hádání čísla (počítač myslí, ty hádáš)
internal class Program
{
    static void Main()
    {
        Random nahoda = new Random();
        int cislo = nahoda.Next(1, 101);
        int pokusu = 0;

        Console.WriteLine("Hádání čísla – myslím si číslo od 1 do 100.");

        while (true)
        {
            Console.Write("Tvůj tip: ");
            if (!int.TryParse(Console.ReadLine(), out int tip))
            {
                Console.WriteLine("To není číslo.");
                continue;
            }

            pokusu++;

            if (tip < cislo) Console.WriteLine("Více.");
            else if (tip > cislo) Console.WriteLine("Méně.");
            else
            {
                Console.WriteLine($"Správně! Trvalo ti to {pokusu} pokusů.");
                break;
            }
        }
    }
}
