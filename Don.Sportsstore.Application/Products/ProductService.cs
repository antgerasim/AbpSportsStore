using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Products
{
    internal class ProductService : SportsstoreAppServiceBase, IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly int _pageSize = 4;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetAll(GetAllProductsInput input)
        {
            //todo use  AsyncHelper.RunSync()
            var totalCount = await _productRepository.GetAll()
                .WhereIf(input.Category != null && input.Category != "Products", p => p.Category == input.Category)
                .CountAsync();
            //var totalCount2 = await _productRepository.GetAllListAsync();

            var products = await _productRepository
                .GetAll()
                .WhereIf(input.Category != null && input.Category != "Products", p => p.Category == input.Category)
                .OrderBy(p => p.Category)
                .Skip((input.SkipCount - 1) * _pageSize)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var mappedProducts = ObjectMapper.Map<List<ProductDto>>(products);
            var retVal = new PagedResultDto<ProductDto>(totalCount, mappedProducts);

            return retVal;
        }

        public async Task<IList<ProductDto>> GetAll()//todo change to listresultDto return type
        {

            var products = await _productRepository
                .GetAll()
                .OrderBy(p => p.Category).ToListAsync();

            var retVal = products.MapTo<List<ProductDto>>();
            //var retVal = products.MapTo<IReadOnlyList<ProductDto>>();

            return retVal;
        }

        public async Task Create(CreateProductInput input)
        {
            throw new NotImplementedException();
        }

        /*     public async Task Create(CreateProductInput input)
        {
            throw new System.NotImplementedException();
        }*/
    }
}