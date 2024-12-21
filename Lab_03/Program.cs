namespace Lab_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = "This is a test. This test is only a test.";
            Dictionary<string, int> wordFrequency = CountWordFrequency(inputText);

            foreach (var kvp in wordFrequency.OrderBy(w => w.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            //

            DynamicArray<int> dynamicArray = new DynamicArray<int>();

            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);
            Console.WriteLine("Элементы в DynamicArray после добавления 10, 20, 30:");
            PrintDynamicArray(dynamicArray);

            dynamicArray.AddRange(new List<int> { 40, 50, 60 });
            Console.WriteLine("Элементы в DynamicArray после добавления диапазона (40, 50, 60):");
            PrintDynamicArray(dynamicArray);

            dynamicArray.Insert(2, 25); 
            Console.WriteLine("Элементы в DynamicArray после вставки 25 на позицию 2:");
            PrintDynamicArray(dynamicArray);

            dynamicArray.Remove(30); 
            Console.WriteLine("Элементы в DynamicArray после удаления 30:");
            PrintDynamicArray(dynamicArray);


            int elementAtIndex = dynamicArray[3]; 
            Console.WriteLine($"Элемент на позиции 3: {elementAtIndex}");

            Console.WriteLine($"Количество элементов в массиве: {dynamicArray.Length}");
            Console.WriteLine($"Ёмкость массива: {dynamicArray.Capacity}");

            //

            List<string> stringList = new List<string>();
            stringList.Add("Apple");
            stringList.Add("Banana");
            stringList.Add("Cherry");
            Console.WriteLine("Список фруктов:");
            foreach (var fruit in stringList)
            {
                Console.WriteLine(fruit);
            }


            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "One");
            dictionary.Add(2, "Two");
            dictionary.Add(3, "Three");
            Console.WriteLine("\nСловарь чисел:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"Ключ: {kvp.Key}, Значение: {kvp.Value}");
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            Console.WriteLine("\nОчередь:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            Console.WriteLine("\nСтек:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            //

            DynamicArray<int> array1 = new DynamicArray<int>();
            array1.Add(1);
            array1.Add(2);
            array1.Add(3);

            DynamicArray<int> array2 = new DynamicArray<int>();
            array2.Add(1);
            array2.Add(2);
            array2.Add(3);

            DynamicArray<int> array3 = new DynamicArray<int>();
            array3.Add(4);
            array3.Add(5);
            array3.Add(6);

            Console.WriteLine($"Array1 равно Array2? {array1.Equals(array2)}"); // True
            Console.WriteLine($"Array1 равно Array3? {array1.Equals(array3)}"); // False

            string anotherObject = "Hello";
            Console.WriteLine($"Array1 равно строке? {array1.Equals(anotherObject)}"); // False
        }

        static Dictionary<string, int> CountWordFrequency(string text)
        {
            text = text.ToLower().Replace('.', ' ');

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> frequency = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency[word] = 1;
                }
            }

            return frequency;
        }

        //

        static void PrintDynamicArray(DynamicArray<int> dynamicArray)
        {
            foreach (var item in dynamicArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
