
/**
* Theme: Adminto Admin Template
* Author: Coderthemes
* Demo: Editable (Inline editing)
* 
*/


$(function(){

    //modify buttons style
    $.fn.editableform.buttons = 
    '<button type="submit" class="btn btn-primary editable-submit btn-sm waves-effect waves-light"><i class="zmdi zmdi-check"></i></button>' +
    '<button type="button" class="btn editable-cancel btn-sm waves-effect"><i class="zmdi zmdi-close"></i></button>';
    
    //editables 
    $('#username').editable({
     type: 'text',
     pk: 1,
     name: 'username',
     title: 'نام کاربری را وارد کنید'
   });
    
    $('#firstname').editable({
      validate: function(value) {
       if($.trim(value) == '') return 'این زمینه الزامی است';
     }
   });
    
    $('#sex').editable({
      prepend: "انتخاب نشده",
      source: [
      {value: 1, text: 'مرد'},
      {value: 2, text: 'زن'}
      ],
      display: function(value, sourceData) {
       var colors = {"": "#98a6ad", 1: "#5fbeaa", 2: "#5d9cec"},
       elem = $.grep(sourceData, function(o){return o.value == value;});

       if(elem.length) {
         $(this).text(elem[0].text).css("color", colors[value]);
       } else {
         $(this).empty();
       }
     }
   });
    
    $('#status').editable();
    
    $('#group').editable({
      showbuttons: false
    });

    $('#dob').editable();

    $('#comments').editable({
      showbuttons: 'bottom'
    });

    //inline


  $('#inline-username').editable({
     type: 'text',
     pk: 1,
     name: 'username',
     title: 'نام کاربری را وارد کنید',
     mode: 'inline'
   });
    
    $('#inline-firstname').editable({
      validate: function(value) {
       if($.trim(value) == '') return 'این زمینه الزامی است';
     },
     mode: 'inline'
   });
    
    $('#inline-sex').editable({
      prepend: "انتخاب نشده",
      mode: 'inline',
      source: [
      {value: 1, text: 'مرد'},
      {value: 2, text: 'زن'}
      ],
      display: function(value, sourceData) {
       var colors = {"": "#98a6ad", 1: "#5fbeaa", 2: "#5d9cec"},
       elem = $.grep(sourceData, function(o){return o.value == value;});

       if(elem.length) {
         $(this).text(elem[0].text).css("color", colors[value]);
       } else {
         $(this).empty();
       }
     }
   });
    
    $('#inline-status').editable({mode: 'inline'});
    
    $('#inline-group').editable({
      showbuttons: false,
      mode: 'inline'
    });

    $('#inline-dob').editable({mode: 'inline'});

    $('#inline-comments').editable({
      showbuttons: 'bottom',
      mode: 'inline'
    });



  });