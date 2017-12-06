function updateBids() {
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