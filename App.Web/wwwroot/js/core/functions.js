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

function getUltimoAlias() {
    return window.location.toString().split('/').pop();
}

function base64ToArrayBuffer(base64) {
    var binaryString = window.atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
        var ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
}