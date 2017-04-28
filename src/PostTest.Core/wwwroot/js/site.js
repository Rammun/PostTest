//"use strict";

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
//            alert('Не валидные параметры!');
//        }
//    });
//}

//function getFormJson() {
//    var parcel = {
//        weight: $('#parcel_weight').val(),
//        inventory: $('#parcel_inventory').val(),
//        recipient: {
//            firstName: $('#recipient_firstName').val(),
//            lastName: $('#recipient_lastName').val(),
//            patronymic: $('#recipient_patronymic').val(),
//            address: $('#recipient_address').val()
//        },
//        sender: {
//            firstName: $('#sender_firstName').val(),
//            lastName: $('#sender_lastName').val(),
//            patronymic: $('#sender_patronymic').val(),
//            address: $('#sender_address').val()
//        }
//    };
//    return JSON.stringify(parcel);
//}