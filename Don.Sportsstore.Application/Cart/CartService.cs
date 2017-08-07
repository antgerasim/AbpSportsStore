using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Don.Sportsstore.Products;

namespace Don.Sportsstore.Cart
{
    class CartService : ICartService
    {
        private readonly IRepository<Product> _productRepository;

        public CartService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductToCart(Carts.Cart cart, int productId)
        {
            var product = await _productRepository.GetAsync(productId);

            if (product != null)
                cart.AddItem(product, 1);
           // return null;
        }

        public async Task RemoveProductFromCart(Carts.Cart cart, int productId)
        {
            var product = await _productRepository.GetAsync(productId);

            if (product != null)
                cart.RemoveLine(product);
            //return null;
        }
    }
}