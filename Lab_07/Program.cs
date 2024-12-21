namespace Lab_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите координаты центра X: ");
                double centerX = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите координаты центра Y: ");
                double centerY = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите радиус: ");
                double radius = Convert.ToDouble(Console.ReadLine());

                Round circle = new Round(centerX, centerY, radius);

                circle.DisplayInfo();

                //
 
                Console.WriteLine("Введите данные пользователя.");

                Console.Write("Фамилия: ");
                string lastName = Console.ReadLine();

                Console.Write("Имя: ");
                string firstName = Console.ReadLine();

                Console.Write("Отчество: ");
                string middleName = Console.ReadLine();

                Console.Write("Дата рождения (dd.MM.yyyy): ");
                DateTime dateOfBirth;
                while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите дату в формате dd.MM.yyyy.");
                }


                User user = new User(lastName, firstName, middleName, dateOfBirth);

                Console.WriteLine(user.ToString());

                //

                Console.Write("Стаж работы (в годах): ");
                int workExperience;
                while (!int.TryParse(Console.ReadLine(), out workExperience) || workExperience < 0)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                }

                Console.Write("Должность: ");
                string position = Console.ReadLine();

                Employee employee = new Employee(lastName, firstName, middleName, dateOfBirth, workExperience, position);

                Console.WriteLine(employee.ToString());

                //

                Dog dog = new Dog("Шарик", 3);
                Cat cat = new Cat("Мурка", 2);
                Parrot parrot = new Parrot("Кеша", 1);

                // Подписываемся на события
                dog.OnMakeSound += () => Console.WriteLine($"{dog.Name} издал звук!");
                cat.OnMakeSound += () => Console.WriteLine($"{cat.Name} издал звук!");
                parrot.OnMakeSound += () => Console.WriteLine($"{parrot.Name} издал звук!");

                // Массив для хранения животных
                Animal[] animals = { dog, cat, parrot };

                // Вывод информации о животных и их звуках
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.GetInfo());
                    animal.CelebrateBirthday(); // Отмечаем день рождения
                    if (animal is IMakeSound soundableAnimal)
                    {
                        soundableAnimal.MakeSound();
                    }
                    Console.WriteLine();
                }


            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введены некорректные данные. Пожалуйста, введите числовые значения.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}
