using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsStore = new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shopsStore.ContainsKey(shop))
                {
                    shopsStore.Add(shop, new Dictionary<string, double>());
                }

                shopsStore[shop].Add(product, price);
            }

            var orderedShopsStore = shopsStore.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in orderedShopsStore)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
