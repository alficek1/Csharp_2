namespace T1.Api
{
    /// <summary>
    /// Poskytuje jednoduché informace související s datem/časem a náhodným číslem.
    /// </summary>
    public class DateTimeInfoProvider : IMessageProvider
    {
        // Sdílená instance Random, aby se zabránilo opakovanému seedování při rychlých voláních.
        private static readonly Random _rnd = new();

        /// <summary>
        /// Vrátí formátovanou zprávu s aktuálním datem a časem.
        /// </summary>
        public string GetMessage()
        {
            // DateTime.Now je použit pro jednoduchost; v produkci zvažte IClock pro testovatelnost.
            return $"The current date and time is {DateTime.Now}";
        }

        /// <summary>
        /// Vrátí náhodné celé číslo v rozsahu 1..100.
        /// </summary>
        public int GetLuckyNumber()
        {
            return _rnd.Next(1, 101); // 1..100
        }
    }
}
