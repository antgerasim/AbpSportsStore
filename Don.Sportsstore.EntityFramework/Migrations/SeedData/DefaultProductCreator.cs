using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don.Sportsstore.EntityFramework;
using Don.Sportsstore.Products;

namespace Don.Sportsstore.Migrations.SeedData
{
    public class DefaultProductCreator
    {
        public static List<Product> InitialProducts { get; private set; }

        private readonly SportsstoreDbContext _context;


        static DefaultProductCreator()
        {
            InitialProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Price = 275.00m,
                    Category = "Watersports"
                },
                new Product()
                {
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Price = 48.95m,
                    Category = "Watersports"
                },
                new Product()
                {
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Price = 19.50m,
                    Category = "Soccer"
                },
                new Product()
                {
                    Name = "Corner Flags",
                    Description = "Give your playing field a professional touch",
                    Price = 34.95m,
                    Category = "Soccer"
                },
                new Product()
                {
                    Name = "Stadium",
                    Description = "Flat-packed 35,000-seat stadium",
                    Price = 79500.00m,
                    Category = "Soccer"
                },
                new Product()
                {
                    Name = "Thinking Cap",
                    Description = "Improve your brain efficiency by 75%",
                    Price = 16.00m,
                    Category = "Chess"
                },
                new Product()
                {
                    Name = "Unsteady Chair",
                    Description = "Secretely give your opponent a disadvantage",
                    Price = 16.00m,
                    Category = "Chess"
                },
          
                new Product()
                {
                    Name = "Human Chess Board",
                    Description = "A fun game for the family",
                    Price = 75.00m,
                    Category = "Chess"
                },
                new Product()
                {
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    Price = 1200.00m,
                    Category = "Chess"
                },
            };
        }
        public DefaultProductCreator(SportsstoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            
        }

        private void CreateProducts()
        {
            foreach (var product in InitialProducts)
            {
                AddProductIfNotExist(product);
            }
        }

        private void AddProductIfNotExist(Product product)
        {
            if (_context.Products.Any(p=>p.Id ==product.Id))
            {
                return;
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}