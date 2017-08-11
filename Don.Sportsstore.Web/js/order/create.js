(function($) {
    $(function() {

        var _$form = $('#OrderCreationForm');

        //_$form.find('input:first').focus();
        _$form.find('#Name').focus();

        _$form.validate(
/*            {
                rules: {
                    Name: {
                        required: true,
                        minlength: 4,
                        maxlength: 16,
                    },

                    Line1: {
                        required: true,
                        minlength: 6,
                        maxlength: 16,
                    }
                },

                messages: {
                    Name: {
                        required: "Это поле обязательно для заполнения",
                        minlength: "Логин должен быть минимум 4 символа",
                        maxlength: "Максимальное число символо - 16",
                    },

                    Line1: {
                        required: "Это поле обязательно для заполнения",
                        minlength: "Пароль должен быть минимум 6 символа",
                        maxlength: "Пароль должен быть максимум 16 символов",
                    }

                }
            }*/
        );

        _$form.find('input[type=submit]')
            .click(function(e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                var cartJson = $('#cartJson').attr('data-value');
                input.Cart = cartJson; //get Session[Cart] mvc object parked as JSON
                abp.services.app.order.processOrderFromCart(input)
                    .done(function(data) {
                        console.log(data);
                        //clear cart
                        $('#cartJson').attr('data-value', '');
                        location.href = '/Cart/Completed'; //todo to checkout.cshtml
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

/*(function ($) {
    $(function () {

        var _$form = $('#OrderCreationForm');

        //_$form.find('input:first').focus();
        _$form.find('#Name').focus();

        _$form.validate({
            rules: {
                Name: {
                    required: true,
                    minlength: 4,
                    maxlength: 16,
                },

                Line1: {
                    required: true,
                    minlength: 6,
                    maxlength: 16,
                },
            },

            messages: {
                Name: {
                    required: "Это поле обязательно для заполнения",
                    minlength: "Логин должен быть минимум 4 символа",
                    maxlength: "Максимальное число символо - 16",
                },

                Line1: {
                    required: "Это поле обязательно для заполнения",
                    minlength: "Пароль должен быть минимум 6 символа",
                    maxlength: "Пароль должен быть максимум 16 символов",
                },

            }
        });

        _$form.removeAttr("novalidate");

        //_$form.find('button[type=submit]')
        _$form.find('input[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    //return; /*comment out to see ABP error alert window#1#
                }

                var input = _$form.serializeFormToObject();

                $.post("/Cart/Checkout", input)
                    .done(function (response, status, jqxhr) {
                        //location.href = '/Cart';
                    })
                    .fail(function (jqxhr, status, error) {
                        console.log(error);
                        console.log(jqxhr.responseText);
                    });

                /*              abp.services.app.order.processOrderFromCart(input)
              
                                  .done(function () {
                                      //location.href = '/Tasks';
                                      console.log("ficken");
                                  });#1#
            });

    });
})(jQuery);*/