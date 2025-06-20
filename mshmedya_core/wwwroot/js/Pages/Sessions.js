$(function () {
    GetSessionsList();
});

function GetSessionsList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#SessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_SessionsList", "Sessions"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertSessions', function () {

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

    msh.AjaxGet(msh.GetUrl("_InsertSessions", "Sessions"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertSessions', function () {

    var formData = new FormData();

    var StartTime = $('#StartTime').val();
    var EndTime = $('#EndTime').val();
    var Description = $('#Description').val();

    if (msh.Inue(StartTime)) {
        msh.ToastWarning("Başlangıç Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#StartTime'));
        return false;
    }
    if (msh.Inue(EndTime)) {
        msh.ToastWarning("Bitiş Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#EndTime'));
        return false;
    }

    formData.append("StartTime", StartTime);
    formData.append("Description", Description);
    formData.append("EndTime", EndTime);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Kayıt işlemi başarılı!');
            $('#SessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("InsertSessions", "Sessions"), formData, fncSuccess, fncError);

    return false;
});

SessionsId = 0;

$('body').on('click', '#_DeleteSessions', function () {
    SessionsId = $(this).closest('tr').data('id');
    var title = 'Seans Silme Onay';
    var body = 'Seçilen Seans silinecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteSessions">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteSessions', function () {

    var model =
    {
        Id: SessionsId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi başarılı!');
            $('#SessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteSessions", "Sessions"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteSessions', function () {
    SessionsId = $(this).closest('tr').data('id');
    var title = 'Seans Silme Geri Alma';
    var body = 'Seçilen Seans silme işlemi geri alınacak emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteSessions">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteSessions', function () {

    var model =
    {
        Id: SessionsId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi geri alındı!');
            $('#SessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteSessions", "Sessions"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateSessions', function () {

    SessionsId = $(this).closest('tr').data('id');

    var model =
    {
        Id: SessionsId
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

    msh.AjaxPost(msh.GetUrl("_UpdateSessions", "Sessions"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateSessions', function () {

    var formData = new FormData();

    var StartTime = $('#StartTime').val();
    var EndTime = $('#EndTime').val();
    var Description = $('#Description').val();

    if (msh.Inue(StartTime)) {
        msh.ToastWarning("Başlangıç Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#StartTime'));
        return false;
    }
    if (msh.Inue(EndTime)) {
        msh.ToastWarning("Bitiş Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#EndTime'));
        return false;
    }

    formData.append("StartTime", StartTime);
    formData.append("Description", Description);
    formData.append("EndTime", EndTime);
    formData.append("Id", SessionsId);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#SessionsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateSessions", "Sessions"), formData, fncSuccess, fncError);

    return false;
});