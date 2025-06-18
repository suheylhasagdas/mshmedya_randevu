$(function () {
    GetStaffServicesList();
});

function GetStaffServicesList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#StaffServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_StaffServicesList", "StaffServices"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertStaffServices', function () {

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

    msh.AjaxGet(msh.GetUrl("_InsertStaffServices", "StaffServices"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertStaffServices', function () {

    var formData = new FormData();

    var StaffId = $('#StaffId').val();
    var ServiceId = $('#ServiceId').val();

    if (msh.Inue(StaffId)) {
        msh.ToastWarning("Personel Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#StaffId'));
        return false;
    }
    if (msh.Inue(ServiceId)) {
        msh.ToastWarning("Hizmet Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#ServiceId'));
        return false;
    }

    formData.append("StaffId", StaffId);
    formData.append("ServiceId", ServiceId);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Kayıt işlemi başarılı!');
            $('#StaffServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("InsertStaffServices", "StaffServices"), formData, fncSuccess, fncError);

    return false;
});

StaffServicesId = 0;

$('body').on('click', '#_DeleteStaffServices', function () {
    StaffServicesId = $(this).closest('tr').data('id');
    var title = 'Personel Hizmeti Silme Onay';
    var body = 'Seçilen Personel Hizmeti silinecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteStaffServices">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteStaffServices', function () {

    var model =
    {
        Id: StaffServicesId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi başarılı!');
            $('#StaffServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteStaffServices", "StaffServices"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteStaffServices', function () {
    StaffServicesId = $(this).closest('tr').data('id');
    var title = 'Silme İşlemi Geri Alma';
    var body = 'Seçilen silme işlemi geri alınacak emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteStaffServices">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteStaffServices', function () {

    var model =
    {
        Id: StaffServicesId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Silme işlemi geri alındı!');
            $('#StaffServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteStaffServices", "StaffServices"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateStaffServices', function () {

    StaffServicesId = $(this).closest('tr').data('id');
    debugger;

    var model =
    {
        Id: StaffServicesId
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

    msh.AjaxPost(msh.GetUrl("_UpdateStaffServices", "StaffServices"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateStaffServices', function () {

    var formData = new FormData();

    var StaffId = $('#StaffId').val();
    var ServiceId = $('#ServiceId').val();

    if (msh.Inue(StaffId)) {
        msh.ToastWarning("Personel Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#StaffId'));
        return false;
    }
    if (msh.Inue(ServiceId)) {
        msh.ToastWarning("Hizmet Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#ServiceId'));
        return false;
    }

    formData.append("StaffId", StaffId);
    formData.append("ServiceId", ServiceId);
    formData.append("Id", StaffServicesId);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#StaffServicesList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateStaffServices", "StaffServices"), formData, fncSuccess, fncError);

    return false;
});