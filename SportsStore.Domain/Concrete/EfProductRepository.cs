using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
  public  class EfProductRepository : IProductRepository
    {
      private EfDbContext context = new EfDbContext();
      public IQueryable<Product> Products
      {
          get { return context.Products; }
      }
    }
}
