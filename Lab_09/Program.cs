namespace Lab_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "example.txt";

          
            File.WriteAllText(filePath, "Hello, World!");

        
            string content = File.ReadAllText(filePath);
            Console.WriteLine("Содержимое файла: " + content);

          
            string copyPath = "example_copy.txt";
            File.Copy(filePath, copyPath, true); 

            File.Delete(copyPath);
            Console.WriteLine("Копия файла удалена.");

            string directoryPath = "example_directory";

            Directory.CreateDirectory(directoryPath);
            Console.WriteLine("Каталог создан.");

      
            string[] files = Directory.GetFiles(directoryPath);
            Console.WriteLine("Файлы в каталоге:");

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            Directory.Delete(directoryPath, true); 
            Console.WriteLine("Каталог удален.");

            //

            string sourceFile = "example.txt"; 
            string destinationFile = @"path_to_your_destination_file.txt"; 
            int blockSize = 4096; 

            FileCopyHelper fileCopyHelper = new FileCopyHelper(sourceFile, destinationFile, blockSize);

            fileCopyHelper.CopyStarted += (sender, e) => Console.WriteLine("Копирование начато...");
            fileCopyHelper.CopyCompleted += (sender, e) => Console.WriteLine("Копирование завершено.");
            fileCopyHelper.CopyProgress += (sender, progress) => Console.WriteLine($"Прогресс: {progress}%");

            fileCopyHelper.CopyFile();

            //

            string textToAppend = "Это новая строка, которую мы добавим в конец файла." + Environment.NewLine;
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(textToAppend);
            }

            Console.WriteLine("Данные успешно добавлены в файл.");


        }
    }
}
