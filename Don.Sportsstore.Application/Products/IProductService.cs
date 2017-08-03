using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Products
{
    public interface IProductService : IApplicationService
    {
        //Task<ListResultDto<ProductListDto>> GetAll(GetAllProductsInput input, int page);
        Task<PagedResultDto<ProductListDto>> GetAll(GetAllProductsInput input);
        PagedResultDto<ProductListDto> GetAllSync(GetAllProductsInput input);


        Task Create(CreateProductInput input);
    }
}