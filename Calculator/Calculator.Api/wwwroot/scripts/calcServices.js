function calculate() {
    var data = {};
    data.firstValue = parseFloat(document.getElementById("FirstValue").value);
    data.secondValue = parseFloat(document.getElementById("SecondValue").value);
    var operation = document.getElementById("Operation").value;

    switch (operation) {
        case "+":
            data.operation = "Add";
            break;
        case "-":
            data.operation = "Sub";
            break;
        case "*":
            data.operation = "Mult";
            break;
        case "/":
            data.operation = "Div";
            break;
    }

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