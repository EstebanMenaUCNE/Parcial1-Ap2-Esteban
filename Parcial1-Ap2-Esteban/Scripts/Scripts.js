$(document).ready(function () {

    $(".fila").hover(function () {
        var id = $(this).children("td").first().html();
        $("#FilaTextBox").val(id);
    });
});