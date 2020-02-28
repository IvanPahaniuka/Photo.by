// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('body').click(function () {
        $('.carousel-inner').each(function () {

            var l = $(this).children('.item').length;
            var min = $(this).children('.item:first-child').children('img').height();
            alert(min);

            for (var i = 2; i <= l; i++) {
                var h = $(this).children('.item:nth-child(' + i + ')').children('img').height();
                alert(h);
                if (h < min)
                    min = h;
            }
            //$(this).height(min);
        });
    });
})