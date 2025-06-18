$(function () {
    GetCustomersList();

});

function GetCustomersList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#CustomersList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_CustomersList", "Customers"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertCustomers', function () {

    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            OpenModalModalSizeLg(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_InsertCustomers", "Customers"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertCustomers', function () {

    var formData = new FormData();

    var Name = $('#Name').val();
    var Surname = $('#Surname').val();
    var Email = $('#Email').val();
    var Phone = $('#Phone').val();
    var Address = $('#Address').val();
    var City = $('#City').val();
    var Country = $('#Country').val();
    var Gender = $('#Gender').val();
    
    if (msh.Inue(Name)) {
        msh.ToastWarning("Ad Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Name'));
        return false;
    }
    if (msh.Inue(Surname)) {
        msh.ToastWarning("Soyad Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Surname'));
        return false;
    }

    if (msh.Inue(Email)) {
        msh.ToastWarning("E-Posta Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Email'));
        return false;
    }

    if (msh.Inue(Phone)) {
        msh.ToastWarning("Telefon Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Phone'));
        return false;
    }

    if (msh.Inue(Address)) {
        msh.ToastWarning("Adres Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Address'));
        return false;
    }

    formData.append("Name", Name);
    formData.append("Surname", Surname);
    formData.append("Email", Email);
    formData.append("Phone", Phone);
    formData.append("Address", Address);
    formData.append("City", City);
    formData.append("Country", Country);
    formData.append("Gender", Gender);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Kayıt işlemi başarılı!');
            $('#CustomersList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("InsertCustomers", "Customers"), formData, fncSuccess, fncError);

    return false;
});

CustomersId = 0;

$('body').on('click', '#_DeleteCustomers', function () {
    CustomersId = $(this).closest('tr').data('id');
    var title = 'Customers Silme Onay';
    var body = 'Seçilen Customers silinecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteCustomers">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteCustomers', function () {

    var model =
    {
        Id: CustomersId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi başarılı!');
            $('#CustomersList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteCustomers", "Customers"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteCustomers', function () {
    CustomersId = $(this).closest('tr').data('id');
    var title = 'Customers Silme Geri Alma';
    var body = 'Seçilen Customers silme işlemi geri alınacak emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteCustomers">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteCustomers', function () {

    var model =
    {
        Id: CustomersId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi geri alındı!');
            $('#CustomersList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteCustomers", "Customers"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateCustomers', function () {

    CustomersId = $(this).closest('tr').data('id');
    debugger;

    var model =
    {
        Id: CustomersId
    }

    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            OpenModalModalSizeLg(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UpdateCustomers", "Customers"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateCustomers', function () {

    var formData = new FormData();

    var Name = $('#Name').val();
    var Surname = $('#Surname').val();
    var Email = $('#Email').val();
    var Phone = $('#Phone').val();
    var Address = $('#Address').val();
    var City = $('#City').val();
    var Country = $('#Country').val();
    var Gender = $('#Gender').val();

    if (msh.Inue(Name)) {
        msh.ToastWarning("Ad Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Name'));
        return false;
    }
    if (msh.Inue(Surname)) {
        msh.ToastWarning("Soyad Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Surname'));
        return false;
    }

    if (msh.Inue(Email)) {
        msh.ToastWarning("E-Posta Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Email'));
        return false;
    }

    if (msh.Inue(Phone)) {
        msh.ToastWarning("Telefon Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Phone'));
        return false;
    }

    if (msh.Inue(Address)) {
        msh.ToastWarning("Adres Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Address'));
        return false;
    }

    formData.append("Id", CustomersId);
    formData.append("Name", Name);
    formData.append("Surname", Surname);
    formData.append("Email", Email);
    formData.append("Phone", Phone);
    formData.append("Address", Address);
    formData.append("City", City);
    formData.append("Country", Country);
    formData.append("Gender", Gender);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#CustomersList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateCustomers", "Customers"), formData, fncSuccess, fncError);

    return false;
});