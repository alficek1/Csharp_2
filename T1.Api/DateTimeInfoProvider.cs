namespace T1.Api
{
    public class DateTimeInfoProvider : IMessageProvider
    {
        public String GetMessage()
        {
            return $"The current date and time is {DateTime.Now}";
        }

    }
}
