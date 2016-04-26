$('.qtip-basic').each(function () {
    var tooltipString = $(this).attr('data-qtip-content');
    $(this).qtip({
        content: {
            text: tooltipString
        }
    })
});
