$(function () { // will trigger when the document is ready
    $('.datepicker').datepicker({
        format: 'mm-dd-yyyy'
    });
});

function PostForm(targetUrl) {
    var frm = $('#frm');

    if (!formisvalid(frm))
        return;
    
    var formData = new FormData($('#frm')[0]);

    $.ajax(
            {
                url: targetUrl,
                type: "POST",
                async: true,
                data: formData,
                processData: false,
                contentType: false
            }).done(function () {

                window.parent.closeModal();
                gridIni();
            });
}
function formisvalid(theform)
{
    var validator = theform.validate();
    var anyError = false;

    theform.find("input").each(function () {
        if (!validator.element(this)) { 
            anyError = true;
        }
    });

    return !anyError;
}
