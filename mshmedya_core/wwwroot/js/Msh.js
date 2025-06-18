function SwalFireError(body) {
    swal.fire({
        text: body,
        icon: "error",
        buttonsStyling: true,
        confirmButtonColor: "#1C2C52",
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
        , allowOutsideClick: false
        , allowEscapeKey: false
    })
}

function SwalFireWarning(body) {
    Swal.fire({
        text: body,
        icon: "error",
        buttonsStyling: true,
        confirmButtonColor: "#1C2C52",
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
        , allowOutsideClick: false
        , allowEscapeKey: false
    });
}

function SwalFireSuccess(body) {
    Swal.fire({
        text: body,
        icon: "success",
        buttonsStyling: true,
        confirmButtonColor: "#1C2C52",
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
        , allowOutsideClick: false
        , allowEscapeKey: false
    });
}
function SwalFireSuccessWithRedirect(body, url) {
    Swal.fire({
        text: body,
        icon: "success",
        buttonsStyling: true,
        confirmButtonColor: "#1C2C52",
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
        , allowOutsideClick: false
        , allowEscapeKey: false
    }).then(function (result) {
        if (result.value) {
            window.location.href = url;
        }
    });
}
function SwalFireInfo(body) {
    Swal.fire({
        text: body,
        icon: "error",
        buttonsStyling: true,
        confirmButtonColor: "#1C2C52",
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
        , allowOutsideClick: false
        , allowEscapeKey: false
    });
}

function SwalToastSuccess(text) {
    Swal.fire({
        position: "top-right",
        icon: "success",
        title: text,
        showConfirmButton: false,
        confirmButtonColor: "#1C2C52",
        timer: 3000,
        timerProgressBar: true
    });
}

function SwalToastError(text) {
    Swal.fire({
        position: "middle",
        icon: "error",
        title: text,
        showConfirmButton: true,
        confirmButtonColor: "#1C2C52",
        /*timer: 2000,*/
        timerProgressBar: true
    });
}

function SwalToastWarning(text) {
    Swal.fire({
        position: "top-left",
        icon: "warning",
        title: text,
        showConfirmButton: true,
        confirmButtonColor: "#1C2C52",
        /*timer: 2000,*/
        timerProgressBar: true
    });
}

function OpenPopupModal(title, body, appendConfirmButton, appendCancelButton) {
    $('.popupModal-modal-title').html(title);
    $('.popupModal-modal-body').html(body);

    if (appendConfirmButton) {
        $('.popupModal-modal-footer').append(appendConfirmButton);
    }
    if (appendCancelButton) {
        $('.popupModal-modal-footer').append(appendCancelButton);
    }
    $('#PopupModal').modal({ keyboard: false, backdrop: 'static' });
}

function ClosePopupModal() {
    $('.popupModal-modal-footer').empty();
    $('#PopupModal').modal('hide');
}

function OpenModalModalSizeSm(body) {
    $('.modalSizeSm-body').html(body);
    $('#PopupModal').modal({ keyboard: false, backdrop: 'static' });
}

function OpenModalModalSizeMd(body) {
    $('.modalSizeMd-body').html(body);
    $('#ModalSizeMd').modal({ keyboard: false, backdrop: 'static' });
}

function OpenModalModalSizeLg(body) {
    $('.modalSizeLg-body').html(body);
    $('#ModalSizeLg').modal({ keyboard: false, backdrop: 'static' });
}

function OpenModalModalSizeXl(body) {
    $('.modalSizeXl-body').html(body);
    $('#ModalSizeXl').modal({ keyboard: false, backdrop: 'static' });
}

function CloseModal(modalId) {
    $('#' + modalId).modal('hide');
}

function ShowSuccessMessage(message) {
    var position = toastrPosition.TopRight;
    var color = toastrEnum.success;
    ShowMessage(message, color, position);
}
function ShowErrorMessage(message) {
    var position = toastrPosition.TopLeft;
    var color = toastrEnum.warning;
    ShowMessage(message, color, position);
}

function ShowWarningMessage(message) {
    var position = toastrPosition.BottomCenter;
    var color = toastrEnum.error;

    ShowMessage(message, color, position);
}

function ShowMessage(message, toastrEnum, toastrPosition) {

    var position = '';

    switch (toastrPosition) {
        case 1:
            position = 'toast-bottom-center';
            break;
        case 2:
            position = 'toast-top-right';
            break;
        case 3:
            position = 'toast-top-left';
            break;
    }

    toastr.options = {
        'closeButton': true,
        'debug': false,
        'newestOnTop': false,
        'progressBar': true,
        'positionClass': position,
        'preventDuplicates': false,
        'onclick': null,
        'showDuration': '300',
        'hideDuration': '1000',
        'timeOut': '5000',
        'extendedTimeOut': '1000',
        'showEasing': 'swing',
        'hideEasing': 'linear',
        'showMethod': 'fadeIn',
        'hideMethod': 'fadeOut'
    };

    switch (toastrEnum) {
        case 1:
            toastr.info(message);
            break;
        case 2:
            toastr.success(message);
            break;
        case 3:
            toastr.warning(message);
            break;
        case 4:
            toastr.error(message);
            break;
    }
}

var toastrEnum = {
    info: 1,
    success: 2,
    warning: 3,
    error: 4
};

var toastrPosition = {
    BottomCenter: 1,
    TopRight: 2,
    TopLeft: 3
};

function ParseErrorResult(jqXHR, textStatus, errorThrown) {
    try {
        parseJson(jqXHR.responseText);
    } catch (e) {
        var text = jqXHR.responseText.split("\n")[0].split(":")[1];

        if (text !== undefined) {
            SwalToastError(jqXHR.responseText.split("\n")[0].split(":")[1]);
        }
        else {
            SwalToastError(GetErrorMessage(jqXHR.status));
        }
    }
}

function GetErrorMessage(statuscode) {
    switch (statuscode) {
        case 400:
            return 'HTTP - 400, Kötü istek';
        case 401:
            return 'HTTP - 401, Yetkisiz giriş denemesi';
        case 403:
            return 'HTTP - 403, Bu sayfaya girmeye yetkili değilsiniz';
        case 404:
            return 'HTTP - 404, Sayfa veya link bulunamadı';
        case 405:
            return 'HTTP - 405, İzin verilmeyen metod';
        case 408:
            return 'HTTP - 408, İstek zaman aşımına uğradı';
        case 500:
            return 'HTTP - 500, İç sunucu hatası';
        case 503:
            return 'HTTP - 501, Servis kullanılamıyor';
        case 504:
            return 'HTTP - 501, Ağ geçidi zaman aşımı oluştu';
        default:
            return 'Bir hata oluştu';
    }
}

function ValidateFormWithNoMessage(formArray, ignoreArray) {

    var isFormsValid = VForm(formArray, false, ignoreArray);

    return isFormsValid;
}

function ValidateFormWithMessage(formArray) {

    var isFormsValid = VForm(formArray, true, ignoreArray);

    return isFormsValid;
}

// ignore Array parametresi verilmez ise hidden fieldlara bakmaz
// '.a, .b' gönderilirse hidden fieldlara da bakar
function VForm(formArray, showMessage, ignore) {
    $('.is-invalid').removeClass('is-invalid');
    $('.is-valid').removeClass('is-valid');
    $('.is-invalid-select2').removeClass('is-invalid-select2');
    $('.is-valid-select2').removeClass('is-valid-select2');

    $('body').find('#select2Validate').remove();

    var isFormsValid = true;
    var error = '';

    for (i = 0; i < formArray.length; ++i) {

        var $form = formArray[i];

        $form.removeData("validator");
        $form.removeData("unobtrusiveValidation");
        $.validator.setDefaults({ ignore: '.ignore' });
        $.validator.unobtrusive.parse($form);

        if (!$form.valid()) {
            isFormsValid = false;
            var validator = $form.validate();

            $.each(validator.errorMap, function (index, value) {
                var element = $('body').find('[name = "' + index + '"]');
                var data = element.data('type');

                if (data) {
                    var span = $('body').find('[name = "' + index + '"]').next('span').find('.selection').find('.select2-selection');
                    span.removeClass('is-valid-select2').addClass('is-invalid-select2');
                    span.find('#select2Validate').remove();
                    span.append('<span id="select2Validate" class="is-invalid-select2-icon"><span>')

                }
                else {
                    element.removeClass('is-valid').addClass('is-invalid');
                }
                error += value + '<br>';
            });

            $.each(validator.successList, function (index, value) {
                var data = $(this).data('type');
                var id = $(this).attr('name');

                if (data) {
                    var span = $('body').find('[name = "' + id + '"]').next('span').find('.selection').find('.select2-selection');
                    span.removeClass('is-invalid-select2');
                    span.find('#select2Validate').remove();
                }
                else {
                    $('body').find('[name = "' + id + '"]').removeClass('is-invalid');
                }
            });

        }
    }

    if (!isFormsValid && showMessage) {
        ShowErrorMessage(error, toastrEnum.warning, toastrPosition.TopLeft);
    }

    return isFormsValid;
}



function showLoadingDiv() {
    var loading = $('body').find('#page-loading-upload');

    if (loading.length === 0) {
        $('body').append('<div id="page-loading-upload" class="page-loading-overlay page-loading-overlay-fixed" style="width: auto; height: auto; display: block;"><div id="page-loading-loading"><div></div></div></div>');
    }
}

function dismisLoadingDiv() {
    $('body').find('#page-loading-upload').remove();
}

/// property => aranacak property adı
function GetDataFromPageModel(propertyName, value, listName, index) {
    var stringObject = $('#PageModel').html();

    if (stringObject !== undefined) {
        var jsonObject = JSON.parse(stringObject);
        if (jsonObject !== undefined) {
            var filtered_json = find_in_object(jsonObject, { [propertyName]: value });

            var data = filtered_json[0];
            if (listName && index > -1) {
                data = data[listName][index];
            }
            return data;
        }
    }


    return null;
}

function find_in_object(my_object, my_criteria) {
    return my_object.filter(function (obj) {
        return Object.keys(my_criteria).every(function (c) {
            return obj[c] === my_criteria[c];
        });
    });
}

function ValidateEmail(email) {
    var pattern = /^\w+([-+.'][^\s]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;

    if (!pattern.test(email)) {
        return false;
    }

    return true;
}

$(document).delegate('textarea', 'keydown', function (e) {
    var keyCode = e.keyCode || e.which;

    if (keyCode == 9) {
        e.preventDefault();
        var start = this.selectionStart;
        var end = this.selectionEnd;

        // set textarea value to: text before caret + tab + text after caret
        $(this).val($(this).val().substring(0, start)
            + "\t"
            + $(this).val().substring(end));

        // put caret at right position again
        this.selectionStart =
            this.selectionEnd = start + 1;
    }
});


jQuery.fn.ToNumeric =
    function () {
        return this.each(function () {
            $(this).keydown(function (e) {
                var key = e.charCode || e.keyCode || 0;
                // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
                // home, end, period, and numpad decimal
                return (
                    key === 8 ||
                    (key >= 35 && key <= 40) ||
                    (key >= 48 && key <= 57) ||
                    (key >= 96 && key <= 105));
            });
        });
    };

jQuery.fn.ToDouble =
    function () {
        return this.each(function () {
            $(this).keydown(function (e) {
                var key = e.charCode || e.keyCode || 0;
                var value = $(this).val();


                if (key === 188) {
                    value += ',';
                    $(this).val(value);
                }

                var res = value.split(',');

                if (res.length === 3) {
                    $(this).val(value.substring(0, value.length - 1));
                    ShowErrorMessage('1\'den fazla virgül kullanamazsınız');
                    return false;
                }

                //var n = value.includes(",");

                //if (n) {
                //    return value.substring(0, value.length - 1);
                //}


                return (
                    key === 8 ||
                    (key >= 35 && key <= 40) ||
                    (key >= 48 && key <= 57) ||
                    (key >= 96 && key <= 105));
            });
        });
    };

function PopulateSubPageData(SubPageDataDivId, result) {
    var isShow = $('#' + SubPageDataDivId).attr('data-show');

    if (isShow === 'true') {
        $('#' + SubPageDataDivId).slideUp('fast', function () {
            $('#' + SubPageDataDivId).slideDown('fast', function () {
                $('#' + SubPageDataDivId).attr('data-show', 'true');
                $('#' + SubPageDataDivId).html(result);
            });
        });
    }
    else {
        $('#' + SubPageDataDivId).attr('data-show', 'true');
        $('#' + SubPageDataDivId).html(result);
        $('#' + SubPageDataDivId).slideDown('fast', function () {
        });
    }
}

function CloseSubPageData(SubPageDataDivId) {
    var isShow = $('#' + SubPageDataDivId).attr('data-show');

    if (isShow === 'true') {
        $('#' + SubPageDataDivId).slideUp('fast', function () {
            $('#' + SubPageDataDivId).attr('data-show', 'false');
            $('#' + SubPageDataDivId).empty();
        });
    }
}

function parseJson(result) {
    var json = jQuery.parseJSON(result);
    SwalToastError(json.responseText);
}

$(function () {
    justNumber();
    justDecimal();
});

function justNumber() {
    $(".justNumber").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
};

function justDecimal() {
    $(".justDecimal").on("input", function (evt) {
        this.value = this.value
            .replace(/[^\d,]/g, '')             // numbers and decimals only
            .replace(/(^[\d]{5})[\d]/g, '$1')   // not more than 2 digits at the beginning
            .replace(/(\..*)\./g, '$1')         // decimal can't exist more than once
            .replace(/(\,[\d]{4})./g, '$1');    // not more than 4 digits after decimal
    });
};

function ConvertToClass(formName) {
    var form = $('#' + formName);

    var array = form.serializeArray();

    var model = {};

    $.each(array, function (i, item) {
        model[item.name] = item.value;
    });

    return model;
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function TCKNValidate(a) {
    if (a.substr(0, 1) == 0 || a.length != 11) {
        return false;
    }
    var i = 9, md = '', mc = '', digit, mr = '';
    while (digit = a.charAt(--i)) {
        i % 2 == 0 ? md += digit : mc += digit;
    }
    if (((eval(md.split('').join('+')) * 7) - eval(mc.split('').join('+'))) % 10 != parseInt(a.substr(9, 1), 10)) {
        return false;
    }
    for (c = 0; c <= 9; c++) {
        mr += a.charAt(c);
    }
    if (eval(mr.split('').join('+')) % 10 != parseInt(a.substr(10, 1), 10)) {
        return false;
    }
    return true;
}


function CardNumberValidate(cardNumber) {
    var rege = /^[A-F0-9]{14}$/;

    if (!rege.test($('#CardNo').val()))
        return false;

    return true;
}

//datepicker tarihleri turkce tanimlari
!function (a) {

    a.fn.datepicker.dates.tr = { days: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"], daysShort: ["Pz", "Pzt", "Sal", "Çar", "Prş", "Cu", "Cts"], daysMin: ["Pz", "Pzt", "Sal", "Çar", "Prş", "Cu", "Ct"], months: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"], monthsShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"], today: "Bugün", clear: "Temizle", weekStart: 1, format: "dd.mm.yyyy" }

}(jQuery);