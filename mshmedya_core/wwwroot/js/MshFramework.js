msh = {
    Init: function () {

        var fncLoadInit = function (name) {
            try {
                eval(name + ".init()");
            } catch (e) {
                // console.log("Load error in fncLoadInit " + name);
            }
        };
        fncLoadInit("Metronic");
        fncLoadInit("Layout");
        fncLoadInit("Demo");
        fncLoadInit("ComponentsFormTools");
        fncLoadInit("ComponentsDropdowns");
        fncLoadInit("ComponentsPickers");
        fncLoadInit("TableAdvanced");

        msh.SetHeight();
        msh.HideLoading();

        msh.Load();
        if (page.Load) {
            page.Load();
        }
        if (page.AfterLoad) {
            page.AfterLoad();
        }

        msh.Masks.SetNumericMask(".msh-numeric");
        msh.Masks.SetPositiveIntMask(".msh-positiveInt");
        msh.Masks.SetMoneyMask(".msh-money");
        msh.Masks.SetNumericYearMask(".msh-numeric-year");
    },

    Masks: {
        SetNumericMask: function (idOrClassName) {
            try {
                //$(".ks-numeric").inputmask("numeric", { groupSeparator: page.NumberGroupSeparator, radixPoint: page.NumberDecimalSeparator });
                $(idOrClassName).inputmask({ 'alias': 'decimal', rightAlign: true, 'groupSeparator': page.NumberGroupSeparator, radixPoint: page.NumberDecimalSeparator, 'autoGroup': true });
            } catch (e) {
            }
        },
        SetPositiveIntMask: function (idOrClassName) {
            try {
                $(idOrClassName).inputmask({ 'alias': 'integer', allowMinus: false, allowPlus: false, rightAlign: true });
            } catch (e) {
            }
        },
        SetMoneyMask: function (idOrClassName) {
            try {
                $(idOrClassName).inputmask({ 'alias': 'decimal', rightAlign: true, 'groupSeparator': page.NumberGroupSeparator, radixPoint: page.NumberDecimalSeparator, 'autoGroup': true, digits: 2 });
            } catch (e) {
            }
        },
        SetNumericYearMask: function (idOrClassName) {
            try {
                $(idOrClassName).inputmask({ 'alias': 'integer', rightAlign: true, integerDigits: "4", groupSize: 4 });
                //$(idOrClassName).inputmask({ 'alias': 'decimal', rightAlign: true, 'groupSeparator': "", radixPoint: "", digits: "4" });
                //$(idOrClassName).inputmask("9999");
            } catch (e) {
            }
        }
    },

    SetHeight: function () {
        var resizebg = function () {
            page.DocumentHeight = $(document).height();
            page.DocumentWidth = $(document).width();
            page.WindowHeight = $(window).height();
            page.WindowWidth = $(window).width();
            $('.cs-loader').css("height", page.DocumentHeight);
            var spinnerOffset = $(window).scrollTop() + (page.WindowHeight / 2);
            $('.cs-loader').find(".cs-loader-inner").css("top", spinnerOffset);
        };
        $(window).resize(function () {
            resizebg();
        });
        $(document).scroll(function () {
            resizebg();
        });
        //initial call
        resizebg();
    },

    Inu: function (obj) {
        if (obj == null || obj == undefined) {
            return true;
        }
        return false;
    },

    Inue: function (obj) {
        if (obj == null || obj == undefined || obj == "") {
            return true;
        }
        return false;
    },
    IsEmail: function (email) {
        var EmailRegex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return EmailRegex.test(email);
    },
    IsPhone: function (tel) {
        var TelRegex = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
        return TelRegex.test(tel.replace(/\s/g, '').replaceAll('-', ''));
    },
    ConvertDecimalToString: function (number) {
        var formatedNumber = number + "";
        var temparr = formatedNumber.split('.');

        var firstPart = temparr[0];
        var secondPart = "";
        if (temparr.length > 1) {
            secondPart = temparr[1];
        }
        formatedNumber = "";
        if (!msh.Inue(secondPart)) {
            formatedNumber = page.NumberDecimalSeparator + secondPart;
        }
        var firstPartArray = firstPart.split("");
        var counter = 0;
        for (var i = firstPartArray.length - 1; i >= 0; i--) {
            formatedNumber = firstPartArray[i] + formatedNumber;
            counter++;
            if (counter == 3 && i != 0) {
                counter = 0;
                formatedNumber = page.NumberGroupSeparator + formatedNumber;
            }
        }

        return formatedNumber;
    },

    ConvertStringToDecimal: function (numberText) {
        numberText = numberText.replaceAll(page.NumberGroupSeparator, "");
        numberText = numberText.replaceAll(page.NumberDecimalSeparator, ".");
        numberText = numberText.replaceAll("_", "");
        return parseFloat(numberText);
    },

    ConvertMaskToString: function (maskText) {
        maskText = maskText.replaceAll(".", "");
        return maskText.replaceAll("_", "");
    },

    GetUrl: function (action, controller) {
        var str = "/" + controller + "/" + action;
        if (!msh.Inue(msh.WebBaseUrlPath)) {
            str = "/" + msh.WebBaseUrlPath + str;
        }
        return str;
    },

    //GetApiUrl: function (path) {
    //    var pathBase = page.BaseUrlPath;
    //    if (pathBase.substring(pathBase.length - 1, pathBase.length) != "/") {
    //        pathBase = pathBase + "/";
    //    }
    //    if (path.substring(0, 1) == "/") {
    //        path = path.substring(1, path.length);
    //    }
    //    return pathBase + path;
    //},

    //Load: function () {



    //    AjaxFileUpload = function (url, fileId, fncSuccess, fncError) {
    //        var fileupload = document.getElementById(fileId);

    //        if (fileupload.files.length == 1) {
    //            var formData = new FormData();
    //            for (var i = 0; i < fileupload.files.length; i++) {
    //                var file = fileupload.files[i];

    //                // Check the file type.
    //                //if (!file.type.match('image.*')) {
    //                //    continue;
    //                //}

    //                // Add the file to the request.
    //                formData.append('dosyalar[]', file, file.name);
    //                var antiForgeryToken = $('input[name="__RequestVerificationToken"]').val();
    //                msh.ShowLoading();
    //                $.ajax({
    //                    url: url,
    //                    type: 'POST',
    //                    headers: { '__RequestVerificationToken': antiForgeryToken },
    //                    data: formData,
    //                    cache: false,
    //                    dataType: 'json',
    //                    contentType: false,
    //                    processData: false,
    //                    success: fncSuccess,
    //                    error: fncError,
    //                    complete: function () {
    //                        // STOP LOADING SPINNER
    //                        msh.HideLoading();
    //                    }
    //                });
    //            }
    //        }
    //    };

    //    page.CommonModalCallBackFunction = null;
    //    page.ShowCommonModalInformation = function (title, content) {
    //        page.CommonModalCallBackFunction = null;
    //        $('#page_common_modal').find(".modal-title").html(title);
    //        $('#page_common_modal').find(".modal-body").html('<p>' + content + '</p>');
    //        $('#page_common_modal').find(".modal-ok").hide();
    //        $('#page_common_modal').modal('show');
    //    }
    //    page.ShowCommonModal = function (title, content, callbackFnc) {
    //        page.CommonModalCallBackFunction = callbackFnc;
    //        $('#page_common_modal').find(".modal-title").html(title);
    //        $('#page_common_modal').find(".modal-body").html('<p>' + content + '</p>');
    //        $('#page_common_modal').find(".modal-ok").show();
    //        $('#page_common_modal').modal('show');
    //    }
    //    $('#page_common_modal').find(".modal-ok").click(function () {
    //        if (!msh.Inu(page.CommonModalCallBackFunction)) {
    //            page.CommonModalCallBackFunction();
    //            page.CommonModalCallBackFunction = null;
    //        }
    //    })
    //},

    AjaxRequest: function (type, url, dataprm, fncSuccess, fncError) {
        $.ajax({
            async: true,
            cache: false,
            url: url,
            type: type,
            datatype: "json",
            contentType: 'application/json; charset=utf-8',
            data: dataprm,
            cache: false,
            success: function (data) {
                fncSuccess(data);
                //if (!msh.Inu(data.IsAuthorized) && !msh.Inue(data.Description) && data.IsAuthorized == false) {
                //    page.ShowCommonModalInformation(data.Title, data.Description);
                //} else if (!msh.Inu(data.IsException) && !msh.Inue(data.ErrorMessage) && data.IsException == true) {
                //    msh.ToastError(data.ErrorMessage);
                //} else if (!msh.Inu(fncSuccess)) {
                //    fncSuccess(data);
                //}
            },
            error: fncError,
            beforeSend: function (xhr) { showLoadingDiv(); },
        }).always(function () { dismisLoadingDiv(); });
    },
    AjaxGet: function (url, data, fncSuccess, fncError) {
        msh.AjaxRequest("GET", url, data, fncSuccess, fncError);
    },
    AjaxPost: function (url, data, fncSuccess, fncError) {
        msh.AjaxRequest("POST", url, data, fncSuccess, fncError);
    },
    AjaxPostFormData: function (url, data, fncSuccess, fncError) {
        msh.AjaxRequestFormData("POST", url, data, fncSuccess, fncError);
    },
    AjaxRequestFormData: function (type, url, dataprm, fncSuccess, fncError) {
        $.ajax({
            async: true,
            cache: false,
            contentType: false,
            processData: false,
            type: type,
            url: url,
            data: dataprm,
            success: function (result) {
                fncSuccess(result);

            },
            error: fncError,
            beforeSend: function (xhr) { showLoadingDiv(); },
        }).always(function () { dismisLoadingDiv(); })
    },

    ToastInfo: function (msg) {
        var opt = {
            duration: 3000,
            closeButton: true,
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "slideDown",
            hideMethod: "slideUp",
            progressBar: true
        };
        toastr.info(msg, "", opt);
    },

    ToastSuccess: function (msg) {
        var opt = {
            timeOut: 3000,
            extendedTimeOut: 3000,
            duration: 5000,
            closeButton: true,
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "slideDown",
            hideMethod: "slideUp",
            progressBar: true
        };
        toastr.success(msg, "", opt);
    },

    ToastWarning: function (msg) {
        var opt = {
            duration: 3000,
            closeButton: true,
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "slideDown",
            hideMethod: "slideUp",
            progressBar: true
        };
        toastr.warning(msg, "", opt);
    },

    ToastError: function (msg) {
        var opt = {
            timeOut: 3000,
            extendedTimeOut: 3000,
            duration: 60000,
            closeButton: true,
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "slideDown",
            hideMethod: "slideUp",
            progressBar: true
        };
        toastr.error(msg, "", opt);
    },

    ToJavaScriptDate: function (value) {
        var result = null;
        if (value != null) {
            var pattern = /Date\(([^)]+)\)/;
            var results = pattern.exec(value);
            var dt = new Date(parseFloat(results[1]));
            var day = null;
            var month = null;
            switch (dt.getDate()) {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    day = "0" + dt.getDate();
                    break;
                default:
                    day = dt.getDate();
                    break;
            }
            var tempMonth = dt.getMonth() + 1;
            switch (tempMonth) {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    month = "0" + tempMonth;
                    break;
                default:
                    month = tempMonth;
                    break;
            }
            result = day + "-" + month + "-" + dt.getFullYear();
        }
        else { result = ""; }

        return result;
    },

    GetQueryString: function (name) {
        var vars = [];
        var hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars[name];
    },

    focusTheEmptyInput: function (inputName) {

        var elOffset = inputName.offset().top;
        var elHeight = inputName.height();
        var windowHeight = $(window).height();
        var offset;
        if (elHeight < windowHeight) {
            offset = elOffset - ((windowHeight / 2) - (elHeight / 2));
        }
        else {
            offset = elOffset;
        }
        $('html, body').animate({
            scrollTop: offset
        }, 500, function () {
            inputName.focus();
        });
        inputName.css("border-color", "#C42323");
    }
};


String.prototype.replaceAll = function (find, replace) {
    var str = this;
    if (find == replace) {
        return str;
    }
    if (find == '.') {
        return str.split(find).join(replace);
    }
    return str.replace(new RegExp(find, 'g'), replace);
};