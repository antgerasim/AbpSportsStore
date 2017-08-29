using System.Threading.Tasks;
using Abp.Application.Services;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Cart
{
    //[RemoteService(false)]
    public interface ICartAppService : IApplicationService
    {
        //todo add return task to enable async operations 
        Task AddProductToCart(Carts.Cart cart, int productId);

        Task RemoveProductFromCart(Carts.Cart cart, int productId);
    }
}