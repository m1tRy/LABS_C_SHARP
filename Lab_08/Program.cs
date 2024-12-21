namespace Lab_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = "2023-03-15T13:00:00Z"; 
                DateTime utcDateTime = DateTime.Parse(input);
                DateTime localDateTime = ConvertUtcToLocal(utcDateTime);
                Console.WriteLine("Локальное время: " + localDateTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
                Console.WriteLine("Внутреннее исключение: " + GetInnerExceptionMessages(ex));
            }
        }

        static DateTime ConvertUtcToLocal(DateTime utcDateTime)
        {
            try
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Local);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при конвертации времени", ex);
            }
        }

        static string GetInnerExceptionMessages(Exception ex)
        {
            string messages = string.Empty;
            while (ex != null)
            {
                messages += ex.Message + " ";
                ex = ex.InnerException;
            }
            return messages.Trim();
        }

    }
}
