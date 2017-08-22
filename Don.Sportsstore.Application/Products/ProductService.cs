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
        private readonly int _pageSize = 4;
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Get(EntityDto<int> input)
        {
            var entity = await _productRepository.GetAsync(input.Id);
            var retVal = entity.MapTo<ProductDto>();
            return retVal;
        }

/*        protected virtual IQueryable<Product> CreateQueryable(PagedAndSortedResultRequestDto input)
        {
            return _productRepository.GetAll();
        }*/

        public async Task<PagedResultDto<ProductDto>> GetAll(GetAllProductsInput input)
        //public async Task<PagedResultDto<ProductDto>> GetAll(PagedAndSortedResultRequestDto input) //todo study AsyncCrudAppService in modular-to-do-app

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

            var mappedProducts =
                ObjectMapper.Map<List<ProductDto>>(products); //todo make sure output list contains (hiiden in view) ids
            var retVal = new PagedResultDto<ProductDto>(totalCount, mappedProducts);

            return retVal;
        }

        public async Task<IList<ProductDto>> GetAll() //todo change to listresultDto return type
        {
            var products = await _productRepository
                .GetAll()
                .OrderBy(p => p.Category).ToListAsync();

            var retVal = products.MapTo<List<ProductDto>>();
            //var retVal = products.MapTo<IReadOnlyList<ProductDto>>();

            return retVal;
        }


        public async Task CreateProduct(CreateUpdateProductInput input)
        {
            var product2 = input.MapTo<Product>();


            /*           var product = new Product
                       {
                           Name = input.Name,
                           Description = input.Description,
                           Category = input.Category,
                           Price = input.Price
                       };*/
            //Saving entity with standard Insert method of repositories.
            await _productRepository.InsertAsync(product2);
        }




        public async Task DeleteProduct(ProductDto input)
        {
            await _productRepository.DeleteAsync(input.Id);
        }

        public async Task UpdateProduct(CreateUpdateProductInput input)
        {//weiter mit p. 291
            //get inspired by
            //https://github.com/aspnetboilerplate/sample-blog-module/blob/master/src/Abp.Samples.Blog.Application/Application/Services/CrudAppService.cs

            var entity = await _productRepository.GetAsync(input.Id);
            input.MapTo(entity);//works since [AutoMap(typeof(Product))] maps two classes in both direction

            // await _productRepository.UpdateAsync(entity); dont need! calls automatically
            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }


        /*     public async Task Create(CreateProductInput input)
        {
            throw new System.NotImplementedException();
        }*/
    }
}