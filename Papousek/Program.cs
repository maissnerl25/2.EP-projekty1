namespace Papousek;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Papoušek – opakuje, co řekneš. Pro konec napiš 'konec'.");

        while (true)
        {
            Console.Write("Ty: ");
            string? vstup = Console.ReadLine();

            if (vstup == null || vstup.Trim().ToLower() == "konec")
            {
                break;
            }

            Console.WriteLine("Papoušek: " + vstup);
        }

        Console.WriteLine("Papoušek odletěl. Ahoj!");
    }
}
