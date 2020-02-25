$(function () {
    var i = $('#photos').children().length;

    $('.addPhoto').click(function () {
        var cloned = $('#photoItem').clone(true);
        cloned.removeAttr('id');
        cloned.children('.fotoLabel').text('Фото №' + (i + 1));
        cloned.children('.photoSelect').attr('name', 'Photos[' + i + ']');
        cloned.appendTo('#photos');
        i++;

        var selectHtml = cloned.children('.photoSelect');
        selectPhoto.call(selectHtml);
    });

    $('.removePhoto').click(function () {
        if (i > 0) {
            var pi = $('#photos').children('div.photoItem:last-child');
            pi.remove();
            i--;
        }

    });

    $(".photoSelect").change(selectPhoto);

    function selectPhoto() {
        var par = $(this).parent();
        var id = $(this).val();
        var opt = $('#photoSelectSource').children("option[value='" + id + "']");
        var src = opt.text();
        par.children('img').attr('src', src);
    }
})