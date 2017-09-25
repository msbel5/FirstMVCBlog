/// <reference path="jquery-3.2.1.min.js" />


//$(document).ready(function () {
//    if ($.cookie('UserName') != null) {
//        $("#LogIcon").removeClass("glyphicon-log-in").addClass("glyphicon-log-out")        
//    }
//});


$(document).ready(function () {
    $("#LogBtn").click(function(){
        if ($("#LogIcon").class == "glyphicon glyphicon-log-in") {
            window.location.href = "/Account/Login";
        } else {
            window.location.href = "/Account/Logout"
        }
    })
    
});

