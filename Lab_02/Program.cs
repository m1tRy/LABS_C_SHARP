namespace Lab_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите вашу массу тела (в килограммах): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ваш рост (в метрах): ");
            double height = Convert.ToDouble(Console.ReadLine());

            double bmi = CalculateBMI(weight, height);

            Console.WriteLine($"Ваш индекс массы тела (BMI): {bmi:F2}");

            //

            int arraySize = 10; 
            int[] numbers = GenerateRandomArray(arraySize);

            Console.WriteLine("Сгенерированный массив:");
            PrintArray(numbers);

            int max = FindMax(numbers);
            int min = FindMin(numbers);

            Console.WriteLine($"Максимальное значение: {max}");
            Console.WriteLine($"Минимальное значение: {min}");

            SortArray(numbers);

            Console.WriteLine("Отсортированный массив:");
            PrintArray(numbers);

            //

            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();

            double averageLength = CalculateAverageWordLength(input);

            Console.WriteLine($"Средняя длина слова: {averageLength:F2}");

            //

            WordInfo wordInfo = new WordInfo("Пример");
            Console.WriteLine(wordInfo);

            ModifyWordInfo(ref wordInfo);
            Console.WriteLine("После изменения:");
            Console.WriteLine(wordInfo);

            int result;
            CalculateSum(out result);
            Console.WriteLine($"Сумма чисел: {result}");

            ForceGarbageCollection();
        }

        static double CalculateBMI(double weight, double height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Рост должен быть положительным числом.");
            }
            return weight / (height * height);
        }

        // 

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101);
            }

            return array;
        }

        static int FindMax(int[] array)
        {
            int max = array[0];
            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        static int FindMin(int[] array)
        {
            int min = array[0];
            foreach (int num in array)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        static void SortArray(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        //

        static double CalculateAverageWordLength(string input)
        {
            string trimmedInput = input.Trim();

            if (string.IsNullOrEmpty(trimmedInput))
            {
                return 0; 
            }

            int totalLength = 0;
            int wordCount = 0;
            bool inWord = false;

            foreach (char c in trimmedInput)
            {
                if (char.IsLetter(c))
                {
                    totalLength++;
                    inWord = true; 
                }
                else
                {

                    if (inWord)
                    {
                        wordCount++; 
                        inWord = false; 
                    }
                }
            }

            if (inWord)
            {
                wordCount++;
            }

            return wordCount > 0 ? (double)totalLength / wordCount : 0;
        }

        //

        static void ModifyWordInfo(ref WordInfo wordInfo)
        {
            wordInfo.Word += " (изменено)";
        }

        static void CalculateSum(out int sum)
        {
            sum = 0; 
            for (int i = 1; i <= 10; i++) 
            {
                sum += i;
            }
        }

        static void ForceGarbageCollection()
        {
            Console.WriteLine("Принудительная сборка мусора...");
            GC.Collect(); 
            GC.WaitForPendingFinalizers(); 
            Console.WriteLine("Сборка мусора завершена.");
        }

    }
}
