using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
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

        // public async Task<ListResultDto<ProductListDto>> GetAll(GetAllProductsInput input, int page)
        public async Task<PagedResultDto<ProductListDto>> GetAll(GetAllProductsInput input)
        {
            var totalCount = _productRepository.GetAll().Count();
            //var totalCount2 = await _productRepository.GetAllListAsync();

            var products = await _productRepository
                .GetAll()
                .Where(p => p.Category == input.Category)
                .OrderBy(p => p.Category)
                .Skip((input.SkipCount - 1) * _pageSize)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var mappedProducts = ObjectMapper.Map<List<ProductListDto>>(products);
            var retVal = new PagedResultDto<ProductListDto>(totalCount, mappedProducts);

            return retVal;
        }

        public PagedResultDto<ProductListDto> GetAllSync(GetAllProductsInput input)
        {
            // input.SkipCount = input.Page;

            var totalCount = _productRepository.GetAll()
                .WhereIf(input.Category != null && input.Category != "Products", p => p.Category == input.Category)
                .Count();
            //var totalCount2 = await _productRepository.GetAllListAsync();

            var products = _productRepository
                .GetAll()
                //.Where(p => p.Category == input.Category)
                .WhereIf(input.Category != null && input.Category != "Products", p => p.Category == input.Category)
                .OrderBy(p => p.Category)
                .Skip((input.SkipCount - 1) * _pageSize)
                .Take(input.MaxResultCount)
                //.ToListAsync();
                .ToList();

            var mappedProducts = ObjectMapper.Map<List<ProductListDto>>(products);
            var retVal = new PagedResultDto<ProductListDto>(totalCount, mappedProducts);

            return retVal;
        }

        public Task Create(CreateProductInput input)
        {
            throw new System.NotImplementedException();
        }

        /*     public async Task Create(CreateProductInput input)
        {
            throw new System.NotImplementedException();
        }*/
    }
}