$(function () {
    GetServicesList();
});

function GetServicesList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#ServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_ServicesList", "Services"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertServices', function () {

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

    msh.AjaxGet(msh.GetUrl("_InsertServices", "Services"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertServices', function () {

    var formData = new FormData();

    var Name = $('#Name').val();
    var Description = $('#Description').val();
    var Duration = $('#Duration').val();

    if (msh.Inue(Name)) {
        msh.ToastWarning("Ad Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Name'));
        return false;
    }
    if (msh.Inue(Description)) {
        msh.ToastWarning("Açıklama Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Description'));
        return false;
    }

    if (msh.Inue(Duration)) {
        msh.ToastWarning("Süre Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Duration'));
        return false;
    }

    formData.append("Name", Name);
    formData.append("Description", Description);
    formData.append("Duration", Duration);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Kayıt işlemi başarılı!');
            $('#ServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("InsertServices", "Services"), formData, fncSuccess, fncError);

    return false;
});

ServicesId = 0;

$('body').on('click', '#_DeleteServices', function () {
    ServicesId = $(this).closest('tr').data('id');
    var title = 'Hizmet Silme Onay';
    var body = 'Seçilen Hizmet silinecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteServices">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteServices', function () {

    var model =
    {
        Id: ServicesId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi başarılı!');
            $('#ServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteServices", "Services"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteServices', function () {
    ServicesId = $(this).closest('tr').data('id');
    var title = 'Hizmet Silme Geri Alma';
    var body = 'Seçilen Hizmet silme işlemi geri alınacak emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteServices">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteServices', function () {

    var model =
    {
        Id: ServicesId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi geri alındı!');
            $('#ServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteServices", "Services"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateServices', function () {

    ServicesId = $(this).closest('tr').data('id');
    debugger;

    var model =
    {
        Id: ServicesId
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

    msh.AjaxPost(msh.GetUrl("_UpdateServices", "Services"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateServices', function () {

    var formData = new FormData();



    var Name = $('#Name').val();
    var Description = $('#Description').val();
    var Duration = $('#Duration').val();

    if (msh.Inue(Name)) {
        msh.ToastWarning("Ad Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Name'));
        return false;
    }
    if (msh.Inue(Description)) {
        msh.ToastWarning("Açıklama Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Description'));
        return false;
    }

    if (msh.Inue(Duration)) {
        msh.ToastWarning("Süre Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#Duration'));
        return false;
    }

    formData.append("Id", ServicesId);
    formData.append("Name", Name);
    formData.append("Description", Description);
    formData.append("Duration", Duration);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#ServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateServices", "Services"), formData, fncSuccess, fncError);

    return false;
});