(function($) {
    $(function() {

        var _$form = $("#OrderCreationForm");

        _$form.find("#Name").focus();

        abp.localization.defaultSourceName = "Sportsstore";
        var nameIsRequired = abp.localization.localize("NameIsRequired");
        var line1IsRequired = abp.localization.localize("Line1IsRequired");
        var cityIsRequired = abp.localization.localize("CityIsRequired");
        var countryIsRequired = abp.localization.localize("CountryIsRequired");
        var cartNotEmpty = abp.localization.localize("CartNotEmpty");

        $.validator.addMethod(
            "regex",
            function(value, element, regexp) {
                var re = new RegExp(regexp);
                return this.optional(element) || re.test(value); //if value contains word "product" - dont show error!
            },
            cartNotEmpty
        );

        _$form.validate(
            {
                ignore: [], //set ingnore setting to empty
                rules: {
                    Name: {
                        required: true
                        /*               minlength: 4,
                                       maxlength: 16,*/
                    },
                    Line1: {
                        required: true
                        /*                   minlength: 6,
                                           maxlength: 16,*/
                    },
                    City: {
                        required: true
                    },
                    Country: {
                        required: true
                    },
                    Cart: {
                        regex: /\bProduct\b/
                    }
                },

                messages: {
                    Name: {
                        required: nameIsRequired
/*                        minlength: "Логин должен быть минимум 4 символа",
                        maxlength: "Максимальное число символо - 16",*/
                    },

                    Line1: {
                        required: line1IsRequired
/*                        minlength: "Пароль должен быть минимум 6 символа",
                        maxlength: "Пароль должен быть максимум 16 символов",*/
                    },
                    City: {
                        required: cityIsRequired
                    },
                    Country: {
                        required: countryIsRequired
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
                input.Cart = cartJson; //get Session[Cart] mvc object parked as JSON
                abp.services.app.order.processOrderFromCart(input)
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