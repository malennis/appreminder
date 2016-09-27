    $(document).ready(function () {

        $(document).on("click","#searchbtn",function () {
       // $("#searchbtn").click(function () {
        
               


            var $form = $(this);
            var idVal = $("#PhoneNumber").val().trim();
            var PhoneNumber = idVal;// JSON.stringify(idVal); //this is needed when the value is not string
          
         //   alert(idVal);
          
            $.ajax({
                url: '/Appointments/Create2',
                // contentType: 'application/json; charset=utf-8',
                data: {'PhoneNumber': PhoneNumber},
                type: 'POST',
                dataType: 'html',
                cache: false
                //async: true

            })
            .done(function (data) {

                //var $target = $($form.attr("test"));
                //$target.html(data);
                //$target.replaceWith(data);

                // $("#test").load();

                //e.preventDefault();
                //loadPage(e.target.href);
                //direction = $(this).attr("#test");
              //  $("#test").replaceWith(data);
                $("#test").html(data);
                $("#Timezone").hide();
                $("#datetimepicker").datetimepicker();
                $("#Timezone").hide();
               // alert(data);

            })
            $("#Timezone").hide();
           // return false;
            //.success(function (result) {
            //    //  alert(result);


            //    $("#test").html(data);
            //    $("#test").replaceWith(data);
            //    $("#datetimepicker").datetimepicker();
            //})
            return true;
            //.error(function (xhr, status) {
            //    alert(status);
            //})
        });
    });


    //$(function () {

    //    $('#activelist,#inactivelist').change(function () {
    //        var id = "someval";
    //        var status = 'inactive';
    //        $("#myPartialViewContainer").load('@Url.Action("Skits","KitSection")' + '?id=' + id + '&status=' + status)
    //    });

    //});