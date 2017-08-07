using Abp.AutoMapper;

namespace Don.Sportsstore.Cart.Dtos
{
    [AutoMapFrom(typeof(Carts.Cart))]
    public class CartDto
    {
        
    }
}