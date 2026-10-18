
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Vítejte v kalkulačce");
        string pokracovat = "ano";
        while (pokracovat.Trim().ToLowerInvariant() == "ano")
        {
            float a = ReadFloat("Zadejte první číslo:");
            float b = ReadFloat("Zadejte druhé číslo:");

            int volba = ReadIntInRange("Zvolte si operaci:\n1 - sčítání\n2 - odčítání\n3 - násobení\n4 - dělení", 1, 4);

            bool vypis = true;
            float vysledek = 0f;
            switch (volba)
            {
                case 1:
                    vysledek = a + b;
                    break;
                case 2:
                    vysledek = a - b;
                    break;
                case 3:
                    vysledek = a * b;
                    break;
                case 4:
                    if (b == 0f)
                    {
                        Console.WriteLine("Chyba: dělení nulou není povoleno.");
                        vypis = false;
                    }
                    else
                    {
                        vysledek = a / b;
                    }
                    break;
            }

            if (vypis)
                Console.WriteLine("Výsledek: {0}", vysledek);

            Console.WriteLine("Přejete si zadat další příklad? [ano/ne]");
            pokracovat = (Console.ReadLine() ?? "ne");
        }

        Console.WriteLine("Děkuji za použití kalkulačky, aplikaci ukončíte libovolnou klávesou.");
        Console.ReadKey();
    }

    static float ReadFloat(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Vstup je prázdný. Zkuste to znovu.");
                continue;
            }

            input = input.Trim();

            if (float.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out float result))
                return result;

            // fallback: allow dot as decimal separator if user typed it
            if (float.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result))
                return result;

            Console.WriteLine("Neplatné číslo. Zadejte prosím správný formát (např. 3.14 nebo 3,14).\n");
        }
    }

    static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse((input ?? string.Empty).Trim(), out int v) && v >= min && v <= max)
                return v;

            Console.WriteLine($"Neplatná volba. Zadejte číslo mezi {min} a {max}.\n");
        }
    }
}
