$(function () {
    GetAppointmentsList();
});

function GetAppointmentsList() {
    var fncSuccess = function (result) {
        if (typeof result == 'object') {
            SwalFireError(result.responseText);
        }
        else {
            $('#AppointmentsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxGet(msh.GetUrl("_AppointmentsList", "Appointments"), null, fncSuccess, fncError);

    return false;
}

$('body').on('click', '#_InsertAppointments', function () {

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

    msh.AjaxGet(msh.GetUrl("_InsertAppointments", "Appointments"), null, fncSuccess, fncError);

    return false;
});
$('body').on('click', '#InsertAppointments', function () {

    var formData = new FormData();

    var CustomerId = $('#CustomerId').val();
    var StaffId = $('#StaffId').val();
    var ServiceId = $('#ServiceId').val();
    var SessionId = selectedSessionId;
    var AppointmentDate = selectedDate;

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
    if (msh.Inue(CustomerId)) {
        msh.ToastWarning("Müşteri Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#CustomerId'));
        return false;
    }
    if (msh.Inue(CustomerId)) {
        msh.ToastWarning("Müşteri Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#CustomerId'));
        return false;
    }
    if (msh.Inue(AppointmentDate)) {
        msh.ToastWarning("Randevu Tarihi Alanı Dolu Olmalıdır!");
        return false;
    }
    if (msh.Inue(SessionId)) {
        msh.ToastWarning("Seans Alanı Dolu Olmalıdır!");
        return false;
    }

    formData.append("StaffId", StaffId);
    formData.append("ServiceId", ServiceId);
    formData.append("CustomerId", CustomerId);
    formData.append("AppointmentDate", AppointmentDate);
    formData.append("SessionId", SessionId);


    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Randevu Başarıyla Oluşturuldu!');
            $('#AppointmentsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };
    debugger;
    msh.AjaxPostFormData(msh.GetUrl("InsertAppointments", "Appointments"), formData, fncSuccess, fncError);

    return false;
});

AppointmentsId = 0;

$('body').on('click', '#_DeleteAppointments', function () {
    AppointmentsId = $(this).closest('tr').data('id');
    var title = 'Randevu İptal Onay';
    var body = 'Seçilen Randevu iptal edilecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="DeleteAppointments">Sil</a>');
    return false;
});

$('body').on('click', '#DeleteAppointments', function () {

    var model =
    {
        Id: AppointmentsId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Randevu İptal işlemi başarılı!');
            $('#AppointmentsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_DeleteAppointments", "Appointments"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#_UndoDeleteAppointments', function () {
    AppointmentsId = $(this).closest('tr').data('id');
    var title = 'İptal İşlemi Geri Alma';
    var body = 'Seçilen Randevu aktif edilecek emin misiniz?';
    OpenPopupModal(title, body, '<a class="btn btn-success" onclick="ClosePopupModal();">Vazgeç</a> <a class="btn btn-danger" id="UndoDeleteAppointments">Geri Al</a>');
    return false;
});

$('body').on('click', '#UndoDeleteAppointments', function () {

    var model =
    {
        Id: AppointmentsId
    }
    debugger;
    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            ClosePopupModal();
            msh.ToastSuccess('Randevu başarıyla aktif edildi');
            $('#AppointmentsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPost(msh.GetUrl("_UndoDeleteAppointments", "Appointments"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});


$('body').on('click', '#_UpdateAppointments', function () {

    AppointmentsId = $(this).closest('tr').data('id');
    debugger;

    var model =
    {
        Id: AppointmentsId
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

    msh.AjaxPost(msh.GetUrl("_UpdateAppointments", "Appointments"), JSON.stringify(model), fncSuccess, fncError);

    return false;
});

$('body').on('click', '#UpdateAppointments', function () {

    var formData = new FormData();

    var CustomerId = $('#CustomerId').val();
    var StaffId = $('#StaffId').val();
    var ServiceId = $('#ServiceId').val();
    var SessionId = selectedSessionId;
    var AppointmentDate = selectedDate;

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
    if (msh.Inue(CustomerId)) {
        msh.ToastWarning("Müşteri Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#CustomerId'));
        return false;
    }
    if (msh.Inue(CustomerId)) {
        msh.ToastWarning("Müşteri Alanı Dolu Olmalıdır!");
        msh.focusTheEmptyInput($('#CustomerId'));
        return false;
    }
    if (msh.Inue(AppointmentDate)) {
        msh.ToastWarning("Randevu Tarihi Alanı Dolu Olmalıdır!");
        return false;
    }
    if (msh.Inue(SessionId)) {
        msh.ToastWarning("Seans Alanı Dolu Olmalıdır!");
        return false;
    }

    formData.append("StaffId", StaffId);
    formData.append("ServiceId", ServiceId);
    formData.append("CustomerId", CustomerId);
    formData.append("AppointmentDate", AppointmentDate);
    formData.append("SessionId", SessionId);
    formData.append("Id", AppointmentsId);

    var fncSuccess = function (result) {
        if (typeof result == 'object')
            SwalToastWarning(result.responseText);
        else {
            CloseModal('ModalSizeLg');
            msh.ToastSuccess('Güncelleme işlemi başarılı!');
            $('#AppointmentsList').html(result);
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };

    msh.AjaxPostFormData(msh.GetUrl("UpdateAppointments", "Appointments"), formData, fncSuccess, fncError);

    return false;
});

