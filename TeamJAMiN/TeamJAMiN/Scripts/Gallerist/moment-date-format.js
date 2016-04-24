$(function () {
    $('[data-utcdate]').each(function () {
        var d = moment($(this).attr('data-utcdate').fromNow());
        $(this).html(d.format());
    });
});
