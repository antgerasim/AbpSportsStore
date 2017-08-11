using System.Threading.Tasks;
using Abp.AutoMapper;
using Don.Sportsstore.Cart;
using Don.Sportsstore.Orders.Dto;
using Newtonsoft.Json;

namespace Don.Sportsstore.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderManager _orderManager;

        public OrderAppService(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public async Task ProcessOrderFromCart(ShippingDetailsInput input)
        {
            var cart = JsonConvert.DeserializeObject<Carts.Cart>(input.Cart);

            var shippingDetails = input.MapTo<ShippingDetails>();
            await _orderManager.ProcessOrder(cart,
                shippingDetails); //not use-case related, instead its a business operation. We may use same 'ProcessOrder' domain logic in a different use-case (is a concept). 
        }
    }
}