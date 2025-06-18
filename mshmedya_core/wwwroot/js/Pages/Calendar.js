$(function () {
    GetAppointmentsList();
});

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
            GetMshCalendar();
        }
    };
    var fncError = function (jqXHR, textStatus, errorThrown) {
        ParseErrorResult(jqXHR, textStatus, errorThrown);
    };
    debugger;
    msh.AjaxPostFormData(msh.GetUrl("InsertAppointments", "Appointments"), formData, fncSuccess, fncError);

    return false;
});