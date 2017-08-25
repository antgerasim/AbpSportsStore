using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> Get(EntityDto<int> input);
        Task<PagedResultDto<ProductDto>> GetAllProducts(GetAllProductsInput input);
        Task<IList<ProductDto>> GetAllProducts();
        Task CreateProduct(CreateUpdateProductInput input);
        Task DeleteProduct(ProductDto input);
        Task UpdateProduct(CreateUpdateProductInput input);


    }
}