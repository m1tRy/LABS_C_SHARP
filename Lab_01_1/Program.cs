

namespace Lab_01_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите положительное число N: ");

            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                string result = Generator.GenerateNumberString(n);
                Console.WriteLine("Результат: " + result);
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите корректное положительное число.");
            }


            Console.Write("Введите положительное нечётное число N: ");

            if (int.TryParse(Console.ReadLine(), out n) && n > 0 && n % 2 == 1)
            {
                Generator.PrintStarSquare(n);
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите корректное положительное нечётное число.");
            }

        }
    }
}
