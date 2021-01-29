$(document).ready(function () {

    // Preloader
    $(window).on('load', function () {
        if ($('#preloader').length) {
            $('#preloader').delay(100).fadeOut('slow', function () {
                //$(this).remove();
            });
        }
    });

    $('#carouselExampleInterval').carousel();

    $('#btn-bootstrap-toast-alert').on('click',
        function (e) {
            e.preventDefault();
            $('#bootstrap-toast-alert').toast('show');
        });

});