
function EnableButton(checkbox) {

    if (checkbox.checked) {
        document.getElementById("DeleteButton").disabled = false;
    }
    else {
        document.getElementById("DeleteButton").disabled = true;
    }
}