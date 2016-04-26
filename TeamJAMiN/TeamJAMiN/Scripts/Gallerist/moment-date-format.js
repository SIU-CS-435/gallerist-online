$(document).ready(function () {
    $('[data-utcdate]').each(function () {
        let dateString = $(this).attr('data-utcdate');
        let date = new Date(dateString);
        let momentDate = moment(date).fromNow();
        $(this).html(momentDate);
    });

    $('[data-duration]').each(function () {
        let minutes = $(this).attr('data-duration');
        let durationString = formatMinutesAsGenericDuration(minutes);
        let momentDuration = moment.duration(parseInt(minutes), 'm').humanize();
        $(this).html(durationString); // + " (" + momentDuration + ")"); we can put minutes back if we feel we need it
        $(this).attr('title', minutes + " Minutes");
    });
});

function formatMinutesAsGenericDuration(lengthInMinutes) {
    //todo we should just make time an enum and the user can actually pick "short, long, medium"
    let value = "";

    if (lengthInMinutes < 10) {
        value = "Short";
    }
    else if (lengthInMinutes >= 10 && lengthInMinutes <= 45) {
        value = "Moderate";
    }
    else if (lengthInMinutes > 45) {
        value = "Long";
    }

    return value;
}