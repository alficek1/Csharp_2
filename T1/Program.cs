using T1.Api;

// Jednoduchá konzolová aplikace: vytvoří instanci poskytovatele, získá zprávu
// a náhodné "šťastné" číslo a vypíše je na konzoli.
var provider = new DateTimeInfoProvider();

// Získání textové zprávy (aktuální datum/čas)
var message = provider.GetMessage();

// Získání náhodného čísla z poskytovatele
var luckyNumber = provider.GetLuckyNumber();

// Vypíše obě informace najednou
Console.WriteLine($"{message}\nYour lucky number is {luckyNumber}");

