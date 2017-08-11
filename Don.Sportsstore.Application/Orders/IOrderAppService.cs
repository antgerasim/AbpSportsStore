using System.Threading.Tasks;
using Abp.Application.Services;
using Don.Sportsstore.Orders.Dto;

namespace Don.Sportsstore.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task ProcessOrderFromCart(ShippingDetailsInput shippingDetails);
     /*   void SetCart(Carts.Cart cart);*/
 /*       Carts.Cart Cart { get; set; }   */ 
    }
}