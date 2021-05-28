$("#taxRateSubmit").on("click", function (event) {
    event.preventDefault();
    var button = $(event.currentTarget);
    button.attr("disabled", "disabled");
    var zip = $("#zipCode").val();
    if (zip === "undefined" || zip === "") {
        button.removeAttr("disabled");
        $("#zip").focus();
        return alert("Please enter your zip to find your tax rate.");
    }
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
    var zip = $("#zipCode").val();
    if (zip === "undefined" || zip === "") {
        button.removeAttr("disabled");
        $("#zip").focus();
        return alert("Please find your tax rate before calculating tax.");        
    }
    url += "?zip=" + zip;
    var state = $("#state").val();
    if (state === "undefined" || state === "") {
        button.removeAttr("disabled");
        $("#zip").focus();
        return alert("Please find your tax rate before calculating tax.");
    }
    url += "&state=" + state;
    var orderAmt = $("#orderAmt").val();
    if (orderAmt === "undefined" || orderAmt === "") {
        button.removeAttr("disabled");
        $("#zip").focus();
        return alert("Please enter a valid order amount before calculating tax.");
    }
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