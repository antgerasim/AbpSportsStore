using System.Threading.Tasks;
using System.Web;
using Abp.Domain.Repositories;
using Don.Sportsstore.Products;

namespace Don.Sportsstore.Cart
{
    internal class CartAppService : ICartAppService
    {
        private const string CartSessionKey = "Cart";
        private readonly IRepository<Product> _productRepository;
        //private Carts.Cart _cart;

        public CartAppService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductToCart(Carts.Cart cart1, int productId)
        {
            var cart = GetCart();
            var product = await _productRepository.GetAsync(productId);

            if (product != null)
                cart1.AddItem(product, 1);
            // return null;
        }

        public async Task RemoveProductFromCart(Carts.Cart cart1, int productId)
        {
            var cart = GetCart();
            var product = await _productRepository.GetAsync(productId);

            if (product != null)
                cart1.RemoveLine(product);
            //return null;
        }

        public void SetCart(Carts.Cart cart)
        {
            //_cart = cart;
        }

        private Carts.Cart GetCart()
        {
            /*We use ASp.NET session state feature to store and retrieve Cart objects. ASP.NET has a nice session feature that uses cookies or URL rewriting to assocciate requests from a user together, to form a single browsing session. 
             * A related feature is session state, which allows us to associate data with a session. This is an ideal fit for our cart class. We want each user to have their own cart, and we want the cart to be persistent between requests.
             Data associated with a session is deleted when a session expires (typically when a user has not made a request for a while). No storage or lifecycle management of the cart objects nessacary*/

            /*In order to avoid using ASP>NET Session, use claims to add new property to session */
            //https://gist.github.com/hikalkan/67469e05475c2d18cb88#gistcomment-2029767
            var cart = (Carts.Cart) HttpContext.Current.Session[CartSessionKey];
            if (cart == null)
            {
                cart = new Carts.Cart();
                HttpContext.Current.Session[CartSessionKey] = cart;
            }
            return cart;
        }
    }
}