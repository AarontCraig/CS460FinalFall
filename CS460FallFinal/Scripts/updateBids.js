function ajax_call() {
    $.ajax({
        url: "/ITEMs/Index",
        type: "POST",
        dataType: 'json',
        success: function (data) {
            alert("Success");
        },
        error: function () {
            alert("Failed");
        }
    });
}

window.setInterval(ajax_call, 5000);