(function($){
  $(function(){
      
      

  }); // end of document ready
})(jQuery); // end of jQuery name space

function checkemail(email) {
    $.ajax({
        url: '/Home/checkemailexist',
        data: { email: email },
        type: 'POST',
        dataType: 'json',
        cache: false,
        done: function (data) {
            if (data) {
                console.log(data);
                return data;
            }
        }
    })
}

function checkphone(phone) {
    $.ajax({
        url: '/Home/checkphoneexist',
        data: { phone: phone },
        type: 'POST',
        dataType: 'json',
        cache: false,
        done: function (data) {
            if (data) {
                console.log(data);
                return data;
            }
        }
    })
}

function adderror(selector, error) {
    $('label[for="' + selector + '"]').attr('data-error', error);
    $('#' + selector).removeClass("valid").addClass("invalid");
}

function removeerror(selector) {
    $('label[for="' + selector + '"]').removeAttr('data-error');
    $('#' + selector).removeClass("invalid").addClass("valid");
}