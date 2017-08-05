using System;


namespace Don.Sportsstore.Web.Models.Cart
{
    public class CartIndexViewModel 
    {
        public Carts.Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

      /*  public CartIndexViewModel(Carts.Cart cart, string returnUrl)
        {
            Cart = cart;
            ReturnUrl = returnUrl;
        }*/
    }
}