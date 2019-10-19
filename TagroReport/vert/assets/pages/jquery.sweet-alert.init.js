/**
 * Theme: Adminto Admin Template
 * Author: Coderthemes
 * SweetAlert
 */

!function ($) {
    "use strict";

    var SweetAlert = function () {
    };

    //examples 
    SweetAlert.prototype.init = function () {

        //Basic
        $('#sa-basic').click(function () {
            swal("یه پیام اینجاست :)");
        });

        //A title with a text under
        $('#sa-title').click(function () {
            swal("یه پیام اینجاست :)", "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.")
        });

        //Success Message
        $('#sa-success').click(function () {
            swal("کارت خوب بود :)", "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.", "success")
        });

        //Warning Message
        $('#sa-warning').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: 'btn-warning',
                confirmButtonText: "آره، اونو پاک کن!",
                closeOnConfirm: false
            }, function () {
                swal("پاک شد!", "فایل خیالی شما پاک شد.", "success");
            });
        });

        //Parameter
        $('#sa-params').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "آره، اونو پاک کن!",
                cancelButtonText: "لغو",
                closeOnConfirm: false,
                closeOnCancel: false
            }, function (isConfirm) {
                if (isConfirm) {
                    swal("پاک شد!", "فایل خیالی شما پاک شد.", "success");
                } else {
                    swal("لغو شد", "فایل خیالی شما امنه :)", "error");
                }
            });
        });

        //Custom Image
        $('#sa-image').click(function () {
            swal({
                title: "شیرین!",
                text: "تصویر دلخواه شما در اینجا قرار می گیرد.",
                imageUrl: "assets/plugins/bootstrap-sweetalert/thumbs-up.jpg"
            });
        });

        //Auto Close Timer
        $('#sa-close').click(function () {
            swal({
                title: "بسته شدن خودکار هشدار!",
                text: "من 2 ثانیه دیگه بسته میشم.",
                timer: 2000,
                showConfirmButton: false
            });
        });

        //Primary
        $('#primary-alert').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "info",
                showCancelButton: true,
                cancelButtonClass: 'btn-success waves-effect waves-light',
                confirmButtonClass: 'btn-primary waves-effect waves-light',
                confirmButtonText: 'اصلی!'
            });
        });

        //Info
        $('#info-alert').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: 'btn-info waves-effect waves-light',
                confirmButtonText: 'اطلاعات!'
            });
        });

        //Success
        $('#success-alert').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "success",
                showCancelButton: true,
                confirmButtonClass: 'btn-success waves-effect waves-light',
                confirmButtonText: 'موفقیت آمیز!'
            });
        });

        //Warning
        $('#warning-alert').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: 'btn-warning waves-effect waves-light',
                confirmButtonText: 'هشدار!'
            });
        });

        //Danger
        $('#danger-alert').click(function () {
            swal({
                title: "مطمئنی؟",
                text: "دیگه نمی تونی این فایل خیالی رو برگردونی :)",
                type: "error",
                showCancelButton: true,
                confirmButtonClass: 'btn-danger waves-effect waves-light',
                confirmButtonText: 'خطر!'
            });
        });


    },
        //init
        $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert
}(window.jQuery),

//initializing 
    function ($) {
        "use strict";
        $.SweetAlert.init()
    }(window.jQuery);