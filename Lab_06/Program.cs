namespace Lab_06
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>
            {
                new Product { Name = "Apple", Price = 1.2m, Category = "Fruits" },
                new Product { Name = "Banana", Price = 0.5m, Category = "Fruits" },
                new Product { Name = "Carrot", Price = 0.8m, Category = "Vegetables" },
                new Product { Name = "Broccoli", Price = 1.5m, Category = "Vegetables" },
                new Product { Name = "Chicken", Price = 5.0m, Category = "Meat" },
                new Product { Name = "Beef", Price = 7.0m, Category = "Meat" },
                new Product { Name = "Milk", Price = 1.0m, Category = "Dairy" }
            };

            // a. Фильтрация
            var cheapProductsQuery = from p in products
                                     where p.Price < 2.0m
                                     select p;

            Console.WriteLine("Продукты с ценой менее 2 (from):");
            foreach (var product in cheapProductsQuery)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            // b. Анонимные типы
            var productNamesAndPrices = products.Select(p => new
            {
                p.Name,
                p.Price
            });
            Console.WriteLine("\nНазвания и цены продуктов:");
            foreach (var item in productNamesAndPrices)
            {
                Console.WriteLine($"{item.Name} - {item.Price}");
            }

            // c. Группировка
            var groupedProducts = products.GroupBy(p => p.Category)
                                          .Select(g => new
                                          {
                                              Category = g.Key,
                                              TotalPrice = g.Sum(p => p.Price)
                                          });

            Console.WriteLine("\nСумма цен по категориям:");
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"{group.Category}: {group.TotalPrice}");
            }


            // 1. ToArray

            Product[] productArray = products.ToArray();
            Console.WriteLine("Продукты в массиве:");
            foreach (var product in productArray)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            // 2. ToList
            List<Product> productList = products.ToList();
            Console.WriteLine("\nПродукты в списке:");
            foreach (var product in productList)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            // 3. Take
            var firstThreeProducts = products.Take(3);
            Console.WriteLine("\nПервые 3 продукта:");
            foreach (var product in firstThreeProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            // 4. Skip
            var productsAfterThree = products.Skip(3);
            Console.WriteLine("\nПродукты после первых 3:");
            foreach (var product in productsAfterThree)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            // 5. OrderBy
            var orderedByPrice = products.OrderBy(p => p.Price);
            Console.WriteLine("\nПродукты, отсортированные по цене:");
            foreach (var product in orderedByPrice)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            // 6. Any
            bool anyExpensiveProducts = products.Any(p => p.Price > 5);
            Console.WriteLine($"\nЕсть ли продукты с ценой более 5? {anyExpensiveProducts}");

            // 7. First
            var firstProduct = products.First();
            Console.WriteLine($"\nПервый продукт: {firstProduct.Name} - {firstProduct.Price}");

            // 8. FirstOrDefault
            var firstVegetable = products.FirstOrDefault(p => p.Category == "Vegetables");
            Console.WriteLine($"\nПервый овощ: {firstVegetable?.Name} - {firstVegetable?.Price}");

            var firstNonExistent = products.FirstOrDefault(p => p.Name == "NonExistentProduct");
            Console.WriteLine($"\nНесуществующий продукт: {(firstNonExistent == null ? "Не найден" : firstNonExistent.Name)}");
        }
    }
}
