using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Domain.Repositories;
using Abp.Web.Security.AntiForgery;
using Don.Sportsstore.Cart;
using Don.Sportsstore.Products;
using Don.Sportsstore.Web.Models.Cart;

namespace Don.Sportsstore.Web.Controllers
{
    public class CartController : Controller
    {
        //private readonly IRepository<Product> _productRepository;
        private readonly ICartService _cartService;

        public CartController(IRepository<Product> productRepository, ICartService cartService)
        {
            //_productRepository = productRepository;
            _cartService = cartService;
        }

        public ViewResult Index(Carts.Cart cart, string returnUrl)
        {
            //var cart = GetCart();
            var model = new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public PartialViewResult Summary(Carts.Cart cart)
        {
            return PartialView(cart);
        }

        [DisableAbpAntiForgeryTokenValidation] //https://forum.aspnetboilerplate.com/viewtopic.php?t=3270&p=7596
        public async Task<RedirectToRouteResult>  AddToCart(Carts.Cart cart, int id, string returnUrl)
        {
           await _cartService.AddProductToCart(cart, id);

            return RedirectToAction("Index", new {returnUrl});
        }

        [DisableAbpAntiForgeryTokenValidation]
        public async Task<RedirectToRouteResult>  RemoveFromCart(Carts.Cart cart, int productId, string returnUrl)
        {
          await  _cartService.RemoveProductFromCart(cart, productId);

            return RedirectToAction("Index", new {returnUrl});
        }

        private Carts.Cart GetCart()
        {
            /*We use ASp.NET session state feature to store and retrieve Cart objects. ASP.NET has a nice session feature that uses cookies or URL rewriting to assocciate requests from a user together, to form a single browsing session. 
             * A related feature is session state, which allows us to associate data with a session. This is an ideal fit for our cart class. We want each user to have their own cart, and we want the cart to be persistent between requests.
             Data associated with a session is deleted when a session expires (typically when a user has not made a request for a while). No storage or lifecycle management of the cart objects nessacary*/
            var cart = (Carts.Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Carts.Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        [DisableAbpAntiForgeryTokenValidation]
        public ViewResult Checkout()
        {

            return View(new ShippingDetailsDto());
        }
        [HttpPost]
        [DisableAbpAntiForgeryTokenValidation]
        public ViewResult Checkout(Carts.Cart cart, ShippingDetailsDto shippingDetails)
        {

            return View(new ShippingDetailsDto());
        }
    }
}