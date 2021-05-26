$("#taxRateSubmit").on("click", function (event) {
    event.preventDefault();
    var button = $(event.currentTarget);
    button.attr("disabled", "disabled");
    var zip = $("#zip").val();
    var url = button.data("url");
    url += "?zip=" + zip;
    if (url) {
        var request = $.ajax({
            url: url,
            type: "GET",
            cache: false,
            async: true
        });
        request.done(function (content) {
            $("#rateInfo").empty().append(content);
            $("#rateInfo").show();
            button.removeAttr("disabled");
        });
        request.fail(function (XMLHttpRequest, textStatus, errorThrown) {
            button.removeAttr("disabled");
        });
    }
});

$("#taxCalcSubmit").on("click", function (event) {
    event.preventDefault();
    var button = $(event.currentTarget);
    button.attr("disabled", "disabled");
    var url = button.data("url");
    var zip = $("#zip").val();
    url += "?zip=" + zip;
    var state = $("#state").text();
    url += "&state=" + state;
    var orderAmt = $("#orderAmt").val();
    url += "&orderAmt=" + orderAmt;
    if (url) {
        var request = $.ajax({
            url: url,
            type: "GET",
            cache: false,
            async: true
        });
        request.done(function (content) {
            $("#taxInfo").empty().append(content);
            $("#taxInfo").show();
            button.removeAttr("disabled");
        });
        request.fail(function (XMLHttpRequest, textStatus, errorThrown) {
            button.removeAttr("disabled");
        });
    }
});