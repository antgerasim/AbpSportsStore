using System.Web.Mvc;
using Don.Sportsstore.Carts;

namespace Don.Sportsstore.Web.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the cart from the session
            Carts.Cart cart = (Carts.Cart) controllerContext.HttpContext.Session[sessionKey];
            //create the Cart if there wasnt one in the session data
            if (cart == null)
            {
                cart = new Carts.Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            //return the cart
            return cart;
        }
    }
}