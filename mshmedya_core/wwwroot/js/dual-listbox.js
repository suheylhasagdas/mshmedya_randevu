'use strict';

// Class definition
var KTDualListbox = function () {
    // Private functions
    var demo1 = function () {
        // Dual Listbox
        var _this = document.getElementById('kt_dual_listbox_1');

        // init dual listbox
        var dualListBox = new DualListbox(_this, {
            addEvent: function (value) {
                console.log(value);
            },
            removeEvent: function (value) {
                console.log(value);
            },
            availableTitle: 'Available options',
            selectedTitle: 'Selected options',
            addButtonText: 'Add',
            removeButtonText: 'Remove',
            addAllButtonText: 'Add All',
            removeAllButtonText: 'Remove All'
        });
    };

    return {
        // public functions
        init: function () {
            demo1();
            //demo2();
            //demo3();
            //demo4();
        },
    };
}();

window.addEventListener('load', function(){
    KTDualListbox.init();
});
