using System.Globalization;

namespace Lab_04
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Sorter<int> intSorter = new Sorter<int>();

            intSorter.SortingCompletedWithoutArgs += () =>
            {
                Console.WriteLine("Сортировка целых чисел завершена без аргументов.");
            };


            intSorter.SortingCompleted += (sender, e) =>
            {
                Console.WriteLine("Сортировка целых чисел завершена.");
            };

            int[] intArray = { 5, 2, 8, 3, 1 };
            intSorter.SortArray(intArray, CompareInt);
            Console.WriteLine("Отсортированный массив целых чисел: " + string.Join(", ", intArray));



            Sorter<string> stringSorter = new Sorter<string>();

            stringSorter.SortingCompletedWithoutArgs += () =>
            {
                Console.WriteLine("Сортировка строк завершена без аргументов.");
            };

  
            stringSorter.SortingCompleted += (sender, e) =>
            {
                Console.WriteLine("Сортировка строк завершена.");
            };

            string[] stringArray = { "apple", "orange", "banana", "pear" };
            stringSorter.SortArray(stringArray, CompareString);
            Console.WriteLine("Отсортированный массив строк: " + string.Join(", ", stringArray));
        }
    

        public static int CompareInt(int x, int y)
        {
            return x.CompareTo(y);
        }

        public static int CompareString(string x, string y)
        {
            return x.CompareTo(y);
        }

    }
}
