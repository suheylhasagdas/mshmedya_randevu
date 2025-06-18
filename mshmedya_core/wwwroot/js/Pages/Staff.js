$(function () {
    GetStaffList();
});

function GetStaffList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#StaffList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_StaffList", "Staff"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertStaff', function () {

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

    msh.AjaxGet(msh.GetUrl("_InsertStaff", "Staff"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertStaff', function () {

    var formData = new FormData();

    var Name = $('#Name').val();
    var Surname = $('#Surname').val();
    var Email = $('#Email').val();
    var Phone = $('#Phone').val();
    var ColorCode = $('#ColorCode').val();

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

    formData.append("Name", Name);
    formData.append("Surname", Surname);
    formData.append("Email", Email);
    formData.append("Phone", Phone);
    formData.append("ColorCode", ColorCode);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Kayıt işlemi başarılı!');
            $('#StaffList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("InsertStaff", "Staff"), formData, fncSuccess, fncError);

    return false;
});

StaffId = 0;

$('body').on('click', '#_DeleteStaff', function () {
    StaffId = $(this).closest('tr').data('id');
    var title = 'Staff Silme Onay';
    var body = 'Seçilen Personel silinecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteStaff">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteStaff', function () {

    var model =
    {
        Id: StaffId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi başarılı!');
            $('#StaffList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteStaff", "Staff"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteStaff', function () {
    StaffId = $(this).closest('tr').data('id');
    var title = 'Staff Silme Geri Alma';
    var body = 'Seçilen Personel silme işlemi geri alınacak emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteStaff">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteStaff', function () {

    var model =
    {
        Id: StaffId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi geri alındı!');
            $('#StaffList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteStaff", "Staff"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateStaff', function () {

    StaffId = $(this).closest('tr').data('id');
    debugger;

    var model =
    {
        Id: StaffId
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

    msh.AjaxPost(msh.GetUrl("_UpdateStaff", "Staff"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateStaff', function () {

    var formData = new FormData();

    var Name = $('#Name').val();
    var Surname = $('#Surname').val();
    var Email = $('#Email').val();
    var Phone = $('#Phone').val();
    var ColorCode = $('#ColorCode').val();

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

    formData.append("Id", StaffId);
    formData.append("Name", Name);
    formData.append("Surname", Surname);
    formData.append("Email", Email);
    formData.append("Phone", Phone);
    formData.append("ColorCode", ColorCode);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#StaffList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateStaff", "Staff"), formData, fncSuccess, fncError);

    return false;
});