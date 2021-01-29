$(document).ready(function () {
    // executes when HTML-Document is loaded and DOM is ready

    // There is a little gap below the button so if you didn't have the timeout function delay it would remove the open class before you actually stop hovering the component. 

    //sets timer variable
    var timer;

    // when the button and button menu are hovered
    $('.social-nav .dropdown button, .dropdown-menu').hover(function () {

        // Clears the time on hover to prevent a que or waiting for the delay to finish from a previous hover event
        clearTimeout(timer);
        // Add the class .open and show the menu
        $('.social-nav .dropdown-menu').addClass('show');

    }, function () {

        // Sets the timer variable to run the timeout delay
        timer = setTimeout(function () {
            // remove the class .open and hide the submenu
            $('.social-nav .dropdown-menu').removeClass("show");
        }, 500);

    });

    // residential slider

    $('#flat-glass-plastics-slider-1').owlCarousel({
        lazyLoad: true,
        navigation: false, // Show next and prev buttons
        slideSpeed: 300,
        paginationSpeed: 400,
        singleItem: true
    })

    // residential slider

    // document ready  
});