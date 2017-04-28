//searchRender();

//$(document).ready(function () {
//    $('#buttonSearch').click(searchRender);
//});

//$('#formRegister').submit(function () {
//    var validator = $("#formRegister").validate();
//    if (validator.form()) {
//        register();
//        this.form.reset();
//        searchRender();
//    }
//    return false;
//});

//function searchRender() {
//    $.ajax({
//        url: '@Url.Action("ParcelSearch", "Home")',
//        data: $('#formSearch').serialize(),
//        type: 'GET',
//        success: function (obj) {
//            $('#searchresults').html(obj);
//        },
//        error: function (obj) {
//            alert('Error!');
//        }
//    });
//}

//function register() {
//    $.ajax({
//        url: '@Url.Action("ParcelRegister", "Home")',
//        data: getFormJson(),
//        type: 'POST',
//        contentType: 'application/json',
//        dataType: 'json',
//        success: function (obj) {
//            $('#registerModal').modal("hide");
//        },
//        error: function (obj) {
//            alert('Error!');
//        }
//    });
//}

//function getFormJson() {
//    var obj = {
//        weight: $('#Weight').val(),
//        inventory: $('#Inventory').val(),
//        recipient: {
//            firstName: $('#Recipient_FirstName').val(),
//            lastName: $('#Recipient_LastName').val(),
//            patronymic: $('#Recipient_Patronymic').val(),
//            address: $('#Recipient_Address').val()
//        },
//        sender: {
//            firstName: $('#Sender_FirstName').val(),
//            lastName: $('#Sender_LastName').val(),
//            patronymic: $('#Sender_Patronymic').val(),
//            address: $('#Sender_Address').val()
//        }
//    };
//    return JSON.stringify(obj);
//}
