$(document).ready(function () {
    var validator = $("form").data("validator");
    if (validator) {
        validator.settings.highlight = function (element) {
            $(element).parent().parent().addClass("has-error");
            $(element).next("span").css("color", "#ed5565");
        }

        validator.settings.unhighlight = function (element) {
            $(element).parent().parent().removeClass("has-error");
        }
    }


    
 //   $("#datetimepicker").datepicker();
      
    
    

    $("#Timezone").hide();

    //$("#searchbtn").click(function () {
    //    //var idVal = $("#PhoneNumber").val();
    //    alert("hola");
    //    alert('bla hola');

    //});
});