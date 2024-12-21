namespace Lab_01_2
{
    /// <summary>
    /// Генератор
    /// </summary>
    public class Generator
    {

        /// <summary>
        /// Метод формирует и возвращает строку вида "1, 2, 3, … N"
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GenerateNumberString(int n)
        {
            var stringBuilder = new System.Text.StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                stringBuilder.Append(i);
                if (i < n)
                {
                    stringBuilder.Append(", "); 
                }
            }

            return stringBuilder.ToString(); 
        }

        /// <summary>
        /// Метод, выводящий на экран квадрат из звёздочек со стороной равной N и отсутствующей центральной звёздочкой.
        /// </summary>
        /// <param name="n"></param>
        public static void PrintStarSquare(int n)
        {
            int center = n / 2;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == center && j == center)
                    {
                        Console.Write(" "); 
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
