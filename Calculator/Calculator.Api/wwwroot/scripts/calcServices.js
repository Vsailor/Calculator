function calculate() {
    var firstValue = parseFloat(document.getElementById("FirstValue").value);
    var secondValue = parseFloat(document.getElementById("SecondValue").value);
    var operation = document.getElementById("Operation").value;
    var data = {};

    data.expression = firstValue + ' ' + operation + ' ' + secondValue;

    $.ajax({
        url: 'api/calc',
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            document.getElementById("ResultValue").value = response.result;
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}