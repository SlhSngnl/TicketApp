// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#SubmitBtn").click(function () {
        if ($("#OriginID").val() === $("#DestinationID").val()) {
            alert("Başlangıç ve Bitiş Noktaları Aynı Olamaz!");
            return false; // Formu submit etmeyi engelle
        }
        // Formu submit et
    });
});

function exchangeLocations() {
    var originSelect = $('#OriginID');
    var destinationSelect = $('#DestinationID');

    var temp = originSelect.val();
    originSelect.val(destinationSelect.val());
    destinationSelect.val(temp);
}

