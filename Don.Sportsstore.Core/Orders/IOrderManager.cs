using System.Threading.Tasks;
using Abp.Domain.Services;
using Don.Sportsstore.Cart;
using Don.Sportsstore.Carts;

namespace Don.Sportsstore.Orders
{
    public interface IOrderManager : IDomainService
    {
        Task ProcessOrder(Carts.Cart cart, ShippingDetails shippingDetails);

    }
}