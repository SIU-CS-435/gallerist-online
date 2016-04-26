$(document).ready(function () {
    $('[data-utcdate]').each(function () {
        var dateString = $(this).attr('data-utcdate');
        var date = new Date(dateString);
        var momentDate = moment(date).fromNow();
        $(this).html(momentDate);
    });
});
