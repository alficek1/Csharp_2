namespace T1.Api
{
    /// <summary>
    /// Interface pro poskytování jednoduchých informací (zpráva a náhodné číslo).
    /// Implementace by měla vracet textovou zprávu a náhodné "šťastné" číslo.
    /// </summary>
    public interface IMessageProvider
    {
        /// <summary>
        /// Vrátí textovou zprávu (např. aktuální datum/čas nebo jinou informaci).
        /// </summary>
        string GetMessage();

        /// <summary>
        /// Vrátí náhodné celé číslo používané jako "šťastné číslo".
        /// Rozsah závisí na implementaci (aktuálně 1..100).
        /// </summary>
        int GetLuckyNumber();
    }
}