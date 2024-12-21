using System.Text.Json;

namespace Lab_05
{
    internal class Program
    {
        private const string FilePath = "persons.json";

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person("Vadimi", 21),
                new Person("Ivan", 20)
            };

            SaveToJson(persons);

            persons = null;

            LoadFromJson(out persons);
        }


        private static void SaveToJson(List<Person> persons)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(persons, options);

            File.WriteAllText(FilePath, json);
            Console.WriteLine("Данные сохранены в файл.");
        }

        private static void LoadFromJson(out List<Person> persons)
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                persons = JsonSerializer.Deserialize<List<Person>>(json);
                Console.WriteLine("Данные загружены из файла.");

                Console.WriteLine("Содержимое коллекции:");
                foreach (var person in persons)
                {
                    Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
                persons = new List<Person>();
            }
        }

    }
}
