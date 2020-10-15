///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


// JS for the LOGIN page


//////////////////////////////////////////////////////////////////////////////////////
// Click handler for the SIGN-IN button
//
$("#btnLogin").click(function() {
    var user = $("#username").val();
    var pswd = $("#password").val();

    if (user.length === 0 || pswd.length === 0) {
        $("#message").html(Err_IncompleteCredentials);
        return;
    }

    $("#message").html(Info_Connecting);
    Ybq.postForm("#login-form",
        function(data) {
            var response = "";
            try {
                response = JSON.parse(data);
            } catch (e) {
                $("#message").html(System_SomethingWentWrong);
                return;
            };

            if (response.success)
                Ybq.goto(response.redirectUrl);
            else {
                $("#message").html(response.message);
                $("#username").val("");
                $("#password").val("");
            }
        },
        function(error) {
            $("#message").html(System_ConnectionError);
        });
});


//////////////////////////////////////////////////////////////////////////////////////
// Displays the login page shared by all users of the system
// 
$("#login-form input").on("focus",
    function() {
        $("#message").html("");
    });


