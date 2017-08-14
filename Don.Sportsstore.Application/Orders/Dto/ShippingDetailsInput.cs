using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.UI.Inputs;
using Don.Sportsstore.Cart;
using Don.Sportsstore.Carts;
using Newtonsoft.Json;

namespace Don.Sportsstore.Orders.Dto
{
    [AutoMapTo(typeof(ShippingDetails))]
    public class ShippingDetailsInput :  ICustomValidate
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Line 2")]
        public string Line2 { get; set; }

        [Display(Name = "Line 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }

        public string Cart { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            var cart = JsonConvert.DeserializeObject<Carts.Cart>(Cart);

            if (!cart.Lines.Any())
            {
                //ModelState.AddModelError("cartError", "Sorry, your cart is empty!");
                context.Results.Add(new ValidationResult("Sorry, your cart is empty!"));
            }


        }
    }
}