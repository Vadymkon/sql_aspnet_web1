function hideButton() {
    var buttons = document.querySelectorAll('input[type="submit"]');
    buttons.forEach(function (button) {
        button.style.visibility = 'hidden';
    });
}
function showButton() {
    var buttons = document.querySelectorAll('input[type="submit"]');
    buttons.forEach(function (button) {
        button.style.visibility = 'visible';
    });
}


function isEmptyFields() {
    var textfields = document.querySelectorAll('input[type="text"]');
    textfields.forEach(function (textField) {
        if (textField.value == null || textField.value == "") return true;
    });
}

//ButtonHidingFunction
var buttons = document.querySelectorAll('input[type="submit"]');
buttons.forEach(function (button) {
    button.addEventListener('click', function () {
        hideButton();
    });
});
