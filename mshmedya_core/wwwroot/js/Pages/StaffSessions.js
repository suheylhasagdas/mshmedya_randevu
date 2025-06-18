$(function () {
    GetStaffSessionsList();
});

function GetStaffSessionsList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#StaffSessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_StaffSessionsList", "StaffSessions"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertStaffSessions', function () {

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

    msh.AjaxGet(msh.GetUrl("_InsertStaffSessions", "StaffSessions"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertStaffSessions', function () {

    var formData = new FormData();

    var StaffId = $('#StaffId').val();
    var SessionId = $('#SessionId').val();

    if (msh.Inue(StaffId)) {
        msh.ToastWarning("Personel Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#StaffId'));
        return false;
    }
    if (msh.Inue(SessionId)) {
        msh.ToastWarning("Seans Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#SessionId'));
        return false;
    }

    formData.append("StaffId", StaffId);
    formData.append("SessionId", SessionId);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Kayıt işlemi başarılı!');
            $('#StaffSessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("InsertStaffSessions", "StaffSessions"), formData, fncSuccess, fncError);

    return false;
});

StaffSessionId = 0;

$('body').on('click', '#_DeleteStaffSessions', function () {
    StaffSessionId = $(this).closest('tr').data('id');
    var title = 'Kayıt Silme Onay';
    var body = 'Seçilen kayıt silinecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteStaffSessions">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteStaffSessions', function () {

    var model =
    {
        Id: StaffSessionId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi başarılı!');
            $('#StaffSessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteStaffSessions", "StaffSessions"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteStaffSessions', function () {
    StaffSessionId = $(this).closest('tr').data('id');
    var title = 'Silme İşlemi Geri Alma';
    var body = 'Seçilen silme işlemi geri alınacak emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteStaffSessions">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteStaffSessions', function () {

    var model =
    {
        Id: StaffSessionId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi geri alındı!');
            $('#StaffSessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteStaffSessions", "StaffSessions"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateStaffSessions', function () {

    StaffSessionId = $(this).closest('tr').data('id');
    debugger;

    var model =
    {
        Id: StaffSessionId
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

    msh.AjaxPost(msh.GetUrl("_UpdateStaffSessions", "StaffSessions"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateStaffSessions', function () {

    var formData = new FormData();

    var StaffId = $('#StaffId').val();
    var SessionId = $('#SessionId').val();

    if (msh.Inue(StaffId)) {
        msh.ToastWarning("Personel Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#StaffId'));
        return false;
    }
    if (msh.Inue(SessionId)) {
        msh.ToastWarning("Seans Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#SessionId'));
        return false;
    }

    formData.append("StaffId", StaffId);
    formData.append("SessionId", SessionId);
    formData.append("Id", StaffSessionId);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#StaffSessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateStaffSessions", "StaffSessions"), formData, fncSuccess, fncError);

    return false;
});