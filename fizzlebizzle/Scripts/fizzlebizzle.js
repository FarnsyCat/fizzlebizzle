$('#switch-modal').bootstrapSwitch();
$(document).ready(function () {
    $('#switch-modal').on('switchChange.bootstrapSwitch', function (e, data) {
        var state = $(this).bootstrapSwitch('state');//returns true or false

        if (state) {
            $("#div_bazz").show();
        }
        else {
            $("#div_bazz").hide();
        }
    });
});