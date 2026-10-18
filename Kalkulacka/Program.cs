using System;
using System.Globalization;

class Program
{
    // Hlavní vstup do programu
    // Program opakovaně čte dva operandy a volbu operace, zpracuje výsledek a umožní opakovat výpočet.
    static void Main()
    {
        Console.WriteLine("Vítejte v kalkulačce");
        string pokracovat = "ano";
        // Smyčka programu, pokračuje dokud uživatel zadá "ano"
        while (pokracovat.Trim().ToLowerInvariant() == "ano")
        {
            // Načtení dvou čísel s validací
            float a = ReadFloat("Zadejte první číslo:");
            float b = ReadFloat("Zadejte druhé číslo:");

            // Načtení volby operace v rozmezí 1..4
            int volba = ReadIntInRange("Zvolte si operaci:\n1 - sčítání\n2 - odčítání\n3 - násobení\n4 - dělení", 1, 4);

            bool vypis = true; // indikátor, zda má být výsledek vypsán (např. false při dělení nulou)
            float vysledek = 0f;
            switch (volba)
            {
                case 1:
                    vysledek = a + b; // sčítání
                    break;
                case 2:
                    vysledek = a - b; // odčítání
                    break;
                case 3:
                    vysledek = a * b; // násobení
                    break;
                case 4:
                    // Ošetření dělení nulou
                    if (b == 0f)
                    {
                        Console.WriteLine("Chyba: dělení nulou není povoleno.");
                        vypis = false;
                    }
                    else
                    {
                        vysledek = a / b; // dělení
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

    // ReadFloat: bezpečně načte float z konzole.
    // Opakuje výzvu, dokud uživatel nezadá platné číslo.
    // Podporuje místní nastavení (desetinná čárka/tečka) a jako fallback InvariantCulture.
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

            // Nejprve použijeme aktuální kulturu (přizpůsobí se systému, např. čárka v CZ)
            if (float.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out float result))
                return result;

            // Fallback: povolit i formát s tečkou jako desetinným oddělovačem
            if (float.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result))
                return result;

            Console.WriteLine("Neplatné číslo. Zadejte prosím správný formát (např. 3.14 nebo 3,14).\n");
        }
    }

    // ReadIntInRange: načte celé číslo a zajistí, že je v daném rozsahu [min,max]
    // Opakuje výzvu dokud uživatel nezadá platnou hodnotu.
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
