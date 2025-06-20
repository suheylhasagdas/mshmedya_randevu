function padZero(n) {
    return n.toString().padStart(2, '0');
}

function parseTime(str) {
    const clean = str.replace(/\D/g, '');
    let h = 0, m = 0;
    if (clean.length >= 3) {
        h = parseInt(clean.slice(0, clean.length - 2));
        m = parseInt(clean.slice(-2));
    } else if (clean.length === 2) {
        h = parseInt(clean);
        m = 0;
    }

    h = (isNaN(h) || h < 0 || h > 23) ? 0 : h;
    m = (isNaN(m) || m < 0 || m > 59) ? 0 : m;
    m = Math.round(m / 5) * 5;
    if (m === 60) {
        m = 0;
        h = (h + 1) % 24;
    }

    return { h, m };
}

function formatTime(h, m) {
    return padZero(h) + ':' + padZero(m);
}

function updateTime(input, offsetMinutes) {
    const time = parseTime($(input).val());
    const date = new Date();
    date.setHours(time.h);
    date.setMinutes(time.m + offsetMinutes);
    const newH = date.getHours();
    const newM = Math.round(date.getMinutes() / 5) * 5 % 60;
    $(input).val(formatTime(newH, newM));
}

function MshTimePicker() {
    $('.input-group').has('input.time-input').each(function () {
        const $group = $(this);
        const $input = $group.find('input.time-input');

        // HTML özelliklerini JS üzerinden ver
        $input.attr('maxlength', 5).attr('placeholder', '');

        // Eğer butonlar yoksa ekle
        if ($group.find('.btn-up').length === 0) {
            const $up = $(`<button type="button" class="btn btn-outline-secondary btn-sm btn-up"
            style="border-top-left-radius: 0; border-bottom-left-radius: 0; padding: 2px 8px; line-height: 1;">▲</button>`);
            const $down = $(`<button type="button" class="btn btn-outline-secondary btn-sm btn-down"
            style="border-top-left-radius: 0; border-bottom-left-radius: 0; padding: 2px 8px; line-height: 1;">▼</button>`);

            const $btnGroup = $('<div class="btn-group-vertical"></div>').append($up).append($down);
            $group.append($btnGroup);
        }
    });

    // ▲ Butonu
    $('.input-group').off('click', '.btn-up').on('click', '.btn-up', function () {
        const $input = $(this).closest('.input-group').find('.time-input');
        updateTime($input, 5);
    });

    // ▼ Butonu
    $('.input-group').off('click', '.btn-down').on('click', '.btn-down', function () {
        const $input = $(this).closest('.input-group').find('.time-input');
        updateTime($input, -5);
    });

    // ":" ekleme
    $('.time-input').off('input').on('input', function () {
        let val = $(this).val().replace(/\D/g, '');
        if (val.length > 4) val = val.slice(0, 4);
        if (val.length >= 3) {
            val = val.slice(0, val.length - 2) + ':' + val.slice(-2);
        }
        $(this).val(val);
    });

    // Boş değilse blur ile biçimle
    $('.time-input').off('blur').on('blur', function () {
        const { h, m } = parseTime($(this).val());
        $(this).val(formatTime(h, m));
    });
}