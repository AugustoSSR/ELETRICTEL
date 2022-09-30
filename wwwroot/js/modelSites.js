$(function () {
    var modelTest = $('modelTest');
    $('button[data-bs-toggle="modalTypes"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            modelTest.html(data);
            modelTest.find('.modal').modal('show');
        })
    })
}) 