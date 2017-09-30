function resetMField() {
    $("#Email").val("");
    $("#YMessage").val("");
    $("#Email").removeClass().addClass("Email");
    $("#YMessage").removeClass().addClass("YMessage");
};

function Send() {
    resetMField();
};

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
};

function isAllValid() {
    var _result;
    var _ERes;
    var _MRes;
    if ($("#Email").attr("class") == "EmailValid") { _ERes = true; }
    else { _ERes = false }
    if ($("#YMessage").attr("class") == "YMessageValid") { _MRes = true; }
    else { _MRes = false; }
    if (_ERes == true && _MRes == true) { _result = true; }
    else { _result = "Lütfen doğru mail adresi girdiğinize ve/veya alanları boş bırakmadığınıza emin olun." }
    return _result;
};

$(document).ready(function () {
    $(".Reset").click(function () {
        resetMField();
    });
});

$(document).ready(function () {
    $("#YMessage").on("change paste keyup", function () {
        var _cont = $(this).val();
        if (_cont != "") { $(this).removeClass().addClass("YMessageValid"); }
        else { $(this).removeClass().addClass("YMessage"); }
    });
});

$(document).ready(function () {
    $("#Email").on("change paste keyup", function () {
        var _cont = $(this).val();
        if (isEmail(_cont)) { $(this).removeClass().addClass("EmailValid"); }
        else { $(this).removeClass().addClass("Email"); }
    });
});

$(document).ready(function () {
    $(".Send").click(function () {
        if (isAllValid() == true) { Send(); }
        else { alert(isAllValid()); }
    });
});

