$(document).ready(
function () {
    //check all checkboxes
    document.getElementById('allCheck')
            .addEventListener("change", function (event) { checkAll(event) });
});

function checkAll(event) {
    var elements = $('input[class = "checkable"]');
    if (event.target.checked)
    {
        elements.each(function () {
            this.checked = true;
        });
    }
    else 
    {
        elements.each(function () {
            this.checked = false;
        });
        
    }
}