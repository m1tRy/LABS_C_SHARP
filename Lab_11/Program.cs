using DataModels;
using LinqToDB.Data;

namespace Lab_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataConnection.DefaultSettings = new MySettings();
            Laba11DB db = new Laba11DB();

            var sqlExpression1 = from x in db.Authors
                                 select x;
            Console.WriteLine("AuthorID\t| FirstName\t| LastName\t |BirthYear");
            foreach (var item in sqlExpression1.ToList())
                Console.WriteLine($"{item.AuthorID}\t| {item.FirstName}\t | {item.LastName}\t |{item.BirthYear}");
        }
    }
}
