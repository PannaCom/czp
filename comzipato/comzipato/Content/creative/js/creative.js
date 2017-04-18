(function($) {
    "use strict"; // Start of use strict

    // jQuery for page scrolling feature - requires jQuery Easing plugin
    $(document).on('click', 'a.page-scroll', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top - 50)
        }, 1250, 'easeInOutExpo');
        event.preventDefault();
    });

    // Highlight the top nav as scrolling occurs
    $('body').scrollspy({
        target: '#mainNav',
        offset: 51
    });

    // Closes the Responsive Menu on Menu Item Click
    $('.navbar-collapse ul li a').click(function() {
        $('.navbar-toggle:visible').click();
    });

    // Offset for Main Navigation
    $('#mainNav').affix({
        offset: {
            top: 100
        }
    })

    $('#mainNav').on('affixed.bs.affix', function () {
        $('#mainNav').addClass('navbar-fixed-top');
    }).on('affixed-top.bs.affix', function () {
        $('#mainNav').removeClass('navbar-fixed-top');
    })

    
    

    // Initialize and Configure Scroll Reveal Animation
    window.sr = ScrollReveal();
    sr.reveal('.sr-icons', {
        duration: 600,
        scale: 0.3,
        distance: '0px'
    }, 200);
    sr.reveal('.sr-button', {
        duration: 1000,
        delay: 200
    });
    sr.reveal('.sr-contact', {
        duration: 600,
        scale: 0.3,
        distance: '0px'
    }, 300);

    // Initialize and Configure Magnific Popup Lightbox Plugin
    $('.popup-gallery').magnificPopup({
        delegate: 'a',
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        mainClass: 'mfp-img-mobile',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
        },
        image: {
            tError: '<a href="%url%">The image #%curr%</a> could not be loaded.'
        }
    });

    $('#carousel-slider-top-home').carousel({ interval: 20000 });

    // bỏ tự căn chỉnh chiều cao của item new đi.
    //$('#article-item').map(function (i, e) {
    //    var list = $(this).find('.article-item');
    //    $.each(list, function (index, value) {            
    //        var width = 0;
    //        var height = 0;
    //        setpostion($(this), width, height);
    //        while (index = list.length) {
    //            width += $(this).outerWidth();
    //            height += $(this).outerHeight();
    //            setpostion($(this), width, height);
    //        }           
    //    });
    //})

    //function setpostion(s, w, h) {
    //    s.css({ 'position': 'absolute', 'left': w, 'top': h });
    //}

    

})(jQuery); // End of use strict

//$(document).ready(function () {
//    var heights = $(".article-item").map(function () {
//        return $(this).height();
//    }).get(),

//    maxHeight = Math.max.apply(null, heights);

//    $(".article-item").height(maxHeight);
//});

