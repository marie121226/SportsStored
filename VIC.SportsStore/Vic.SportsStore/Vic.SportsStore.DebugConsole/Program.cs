using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                for (int i = 0; i < 20; i++)
                {
                    var product = new Product()
                {
                    Name = $"Apple{i}",
                    Price = i+1m,
                    Description = $"this is an Apple{i}",
                    Category = "Fruit"


                };
                    var product1 = new Product()
                    {
                        Name = $"book_{i}",
                        Price = i + 2m,
                        Description = $"this is an Book{i}",
                        Category = "Book"


                    };

                    ctx.Products.Add(product);
                    ctx.Products.Add(product1);
                }

                ctx.SaveChanges();
            }
            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}
