(function($) {
    $(function () {
        //to be used
       // alert('ficken');
        debugger;
        var _$form = $("#ProductEditForm");

        _$form.find("#Name").focus();

        abp.localization.defaultSourceName = "Sportsstore";
        var nameIsRequired = abp.localization.localize("NameIsRequired");
        var descriptionIsRequired = abp.localization.localize("DescriptionIsRequired");
        var priceIsRequired = abp.localization.localize("PriceIsRequired");
        var categoryIsRequired = abp.localization.localize("CategoryIsRequired");
 

/*        $.validator.addMethod(
            "regex",
            function(value, element, regexp) {
                var re = new RegExp(regexp);
                return this.optional(element) || re.test(value); //if value contains word "product" - dont show error!
            }
            
        );*/

        _$form.validate(
            {
                ignore: [], //set ingnore setting to empty
                rules: {
                    Name: {
                        required: true
                        /*               minlength: 4,
                                       maxlength: 16,*/
                    },
                    Description: {
                        required: true
                        /*                   minlength: 6,
                                           maxlength: 16,*/
                    },
                    Price: {
                        required: true
                    },
                    Category: {
                        required: true
                    }
                },

                messages: {
                    Name: {
                        required: nameIsRequired
/*                        minlength: "Логин должен быть минимум 4 символа",
                        maxlength: "Максимальное число символо - 16",*/
                    },

                    Description: {
                        required: descriptionIsRequired
/*                        minlength: "Пароль должен быть минимум 6 символа",
                        maxlength: "Пароль должен быть максимум 16 символов",*/
                    },
                    Price: {
                        required: priceIsRequired
                    },
                    Category: {
                        required: categoryIsRequired
                    }
                }
            }
        );

        _$form.find("input[type=submit]")
            .click(function(e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                var cartJson = $("#Cart").val();
                input.Cart = cartJson; //get Session[Cart] mvc object parked as JSON UpdateProduct
                abp.services.app.product.updateProduct(input)
                //abp.services.app.order.processOrderFromCart(input)
                    .done(function(data) {
                        console.log(data);
                        //clear cart
                        $("#cartJson").attr("data-value", "");
                        location.href = "/Cart/Completed"; //todo to checkout.cshtml
                    })
                    .fail(function(jqXHR, textStatus) {
                        console.log(jqXHR);
                        console.log(textStatus);
                    });
                //.always(function(parameters) {

                //});
            });

    });
})(jQuery);