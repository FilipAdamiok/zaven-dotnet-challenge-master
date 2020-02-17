
function validateJobForm() {
    if ($('#Name').val() == "") {
        $('.name-validation').html("Name is required");
        return false;
    }

    var date = $('#DoAfter').val();
    var regEx = /^\d{4}-\d{2}-\d{2}$/;
    if (date != "" && !(date.match(regEx))) {
        $('.date-validation').html("The date is in the wrong format");
        return false;
    }
    return true;
}