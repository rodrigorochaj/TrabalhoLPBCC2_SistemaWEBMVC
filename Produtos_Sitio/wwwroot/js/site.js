jQuery(function ($) {
    $('#quantidade_venda').focusout(function () {
        let qtd = $(this).val();
        console.log(qtd);
    });


});