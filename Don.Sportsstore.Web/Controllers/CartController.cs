using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Security.AntiForgery;
using Don.Sportsstore.Cart;
using Don.Sportsstore.Orders;
using Don.Sportsstore.Orders.Dto;
using Don.Sportsstore.Web.Models.Cart;
using Newtonsoft.Json;

namespace Don.Sportsstore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartAppService _cartService;
        private readonly IOrderAppService _orderAppService;

        public CartController(ICartAppService cartService, IOrderAppService orderAppService)
        {
            _cartService = cartService;
            _orderAppService = orderAppService;
        }

        public ViewResult Index(Carts.Cart cart, string returnUrl)
        {
            //throw new Exception("A sample exception message...");
            //throw new UserFriendlyException("Ooppps! There is a problem!", "You are trying to see a product that is deleted...");

            var model = new CartIndexViewModel
            {
                Cart = cart,

                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public ViewResult Completed(Carts.Cart cart)
        {
            cart.Clear();
            return View();
        }

        public PartialViewResult Summary(Carts.Cart cart)
        {
            return PartialView(cart);
        }

        [DisableAbpAntiForgeryTokenValidation] //https://forum.aspnetboilerplate.com/viewtopic.php?t=3270&p=7596
        public async Task<RedirectToRouteResult> AddToCart(Carts.Cart cart, int id, string returnUrl)
        {
            await _cartService.AddProductToCart(cart, id);
            return RedirectToAction("Index", new {returnUrl});
        }

        [DisableAbpAntiForgeryTokenValidation]
        public async Task<RedirectToRouteResult> RemoveFromCart(Carts.Cart cart, int productId, string returnUrl)
        {
            await _cartService.RemoveProductFromCart(cart, productId);
            return RedirectToAction("Index", new {returnUrl});
        }

        [DisableAbpAntiForgeryTokenValidation]
        public ViewResult Checkout(Carts.Cart cart)
        {
            var model = new ShippingDetailsInput();
            model.Cart = JsonConvert.SerializeObject(cart);
            return View(model);
        }

/*        [HttpPost]
        [DisableAbpAntiForgeryTokenValidation]
        public ViewResult Checkout(ShippingDetailsInput input)
        {
            var cart = JsonConvert.DeserializeObject<Carts.Cart>(input.Cart);

            if (!cart.Lines.Any())
                ModelState.AddModelError("cartError", "Sorry, your cart is empty!");
            if (ModelState.IsValid)
            {
                _orderAppService.ProcessOrderFromCart(input);
                cart.Clear();
                return View("Completed");
            }
            return View(input);
        }*/
    }
}

//validation links
//https://forum.aspnetboilerplate.com/viewtopic.php?f=5&t=4947
//https://github.com/aspnetboilerplate/aspnetboilerplate/blob/dev/src/Abp.Web.Resources/Abp/Framework/scripts/libs/abp.jquery.js#L69