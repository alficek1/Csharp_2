
Console.WriteLine("Vítejte v kalkulačce");
string pokracovat = "ano";
while (pokracovat == "ano")
{
    Console.WriteLine("Zadejte první číslo:");
    float a = float.Parse(Console.ReadLine());
    Console.WriteLine("Zadejte druhé číslo:");
    float b = float.Parse(Console.ReadLine());
    Console.WriteLine("Zvolte si operaci:");
    Console.WriteLine("1 - sčítání");
    Console.WriteLine("2 - odčítání");
    Console.WriteLine("3 - násobení");
    Console.WriteLine("4 - dělení");
    int volba = int.Parse(Console.ReadLine());
    float vysledek = 0;
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
            vysledek = a / b;
            break;
    }
    if ((volba > 0) && (volba < 5))
        Console.WriteLine("Výsledek: {0}", vysledek);
    else
        Console.WriteLine("Neplatná volba");
    Console.WriteLine("Přejete si zadat další příklad? [ano/ne]");
    pokracovat = Console.ReadLine();
}
Console.WriteLine("Děkuji za použití kalkulačky, aplikaci ukončíte libovolnou klávesou.");
Console.ReadKey();