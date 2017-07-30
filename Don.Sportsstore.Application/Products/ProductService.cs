using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Products
{
    class ProductService : SportsstoreAppServiceBase, IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private int _pageSize = 4;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ListResultDto<ProductListDto>> GetAll(GetAllProductsInput input, int page)
        {
            var products = await _productRepository
                .GetAll() //_productRepository
               // .Where(p => p.Category == input.Category)
                .OrderByDescending(p => p.Name)
                .Skip((page-1) * _pageSize)
                .Take(_pageSize)
                .ToListAsync();

            var mappedProducts = ObjectMapper.Map<List<ProductListDto>>(products);

            var retVal = new ListResultDto<ProductListDto>(mappedProducts);
            return retVal;
        }

        public async Task Create(CreateProductInput input)
        {
            //throw new System.NotImplementedException();
        }
    }
}