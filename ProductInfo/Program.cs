using ProductInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProductInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Entre com o número de produtos: ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados do produto #{i}");
                Console.Write("Produto comum, usado ou importado (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string name = Console.ReadLine();
                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if(ch == 'i')
                {
                    Console.Write("Custo da taxa: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
                else
                {
                    Console.Write("Data de Fabricação (DD/MM/AAAA): ");
                    DateTime manufatureDate = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, manufatureDate));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Lista de produtos:");
            foreach (Product obj in list)
            {
                Console.WriteLine(obj.PriceTag());
            }
        }
    }
}
