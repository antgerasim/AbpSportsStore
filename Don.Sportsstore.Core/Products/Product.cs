using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace Don.Sportsstore.Products
{
    //public class Product : Entity, IEntityDto<int> // used if implementing CrudAppservice anywhere
    public class Product : Entity

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
