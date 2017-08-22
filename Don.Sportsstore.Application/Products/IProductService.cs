using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Products
{
    public interface IProductService : IApplicationService
    {
        Task<ProductDto> Get(EntityDto<int> input);
        Task<PagedResultDto<ProductDto>> GetAll(GetAllProductsInput input);
        Task<IList<ProductDto>> GetAll();
        Task CreateProduct(CreateUpdateProductInput input);
        Task DeleteProduct(ProductDto input);
        Task UpdateProduct(CreateUpdateProductInput input);


    }
}