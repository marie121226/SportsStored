﻿using System;
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
                var product = new Product()
                {
                    Name = "Apple",
                    Price = 2.3m,
                    Description = "this is an Apple",
                    Category = "Fruit"


                };
                ctx.Products.Add(product);
                ctx.SaveChanges();
            }
            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}
