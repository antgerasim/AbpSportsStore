using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Domain.Repositories;
using Abp.Web.Security.AntiForgery;
using Don.Sportsstore.Carts;
using Don.Sportsstore.Products;
using Don.Sportsstore.Web.Models.Cart;

namespace Don.Sportsstore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public CartController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            //var cart = GetCart();
            var model = new CartIndexViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [DisableAbpAntiForgeryTokenValidation] //https://forum.aspnetboilerplate.com/viewtopic.php?t=3270&p=7596
        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            var product = _productRepository.Get(id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }
        [DisableAbpAntiForgeryTokenValidation]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _productRepository.Get(productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        private Cart GetCart()
        {
            /*We use ASp.NET session state feature to store and retrieve Cart objects. ASP.NET has a nice session feature that uses cookies or URL rewriting to assocciate requests from a user together, to form a single browsing session. 
             * A related feature is session state, which allows us to associate data with a session. This is an ideal fit for our cart class. We want each user to have their own cart, and we want the cart to be persistent between requests.
             Data associated with a session is deleted when a session expires (typically when a user has not made a request for a while). No storage or lifecycle management of the cart objects nessacary*/
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}