/*using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Products
{
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, GetAllProductsInput2, CreateProductInput2,UpdateTaskInput2>, IProductAppService
    {
        public ProductAppService(IRepository<Product, int> repository) : base(repository)
        {

        }

        protected override IQueryable<Product> CreateFilteredQuery(GetAllProductsInput2 input)
        {
            return base.CreateFilteredQuery(input)
                .Where(p => p.Category == input.Category);
        }

        protected override 

        public Task<Product> Get(EntityDto<int> input)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<Product>> GetAll(PagedAndSortedResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> Create(Product input)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> Update(Product input)
        {
            throw new System.NotImplementedException();
        }
    }
}*/
//Validate duplicating: the right way?
//https://forum.aspnetboilerplate.com/viewtopic.php?f=2&t=3995&p=9023&hilit=AsyncCrudAppService#p9023
