var tempElementHtml = '';
function loading(element) {
    tempElementHtml = $(element).html();
    $(element).attr('disabled', true);
    $(element).html('<i style="font-size: 18px;" class="fa fa-circle-notch fa-spin" />');
}

function unloading(element) {
    $(element).html(tempElementHtml);
    $(element).attr('disabled', false);
}