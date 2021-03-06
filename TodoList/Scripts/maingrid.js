﻿
var grid = $("#grid");
$(document).ready(function () {
    gridIni();

    $(".jqgrow td input").on("click",function () {
        alert('ciao');
    });

    $("#insertlink").on("click", function (e) {

        GetModalEdit("Todo/Create");
    });
    $("#deleteall").on("click", function (e) {

        DeleteCompleted();
    });
    $('#chkShowAll').change(function () {
        gridIni();
    });
});
 function gridIni(){
    var myurl= $("#chkShowAll").is(':checked')?"getlist/paged":"getlist/PagedNonCompleted";
    gridIniAction(myurl);
    
}

function gridIniAction(targeturl) {
    emptygrid("ToDoList");
    $("#grid").jqGrid({
        url: targeturl,
        mtype: "GET",
        datatype: "json",
        styleUI : 'Bootstrap',
        jsonReader: { repeatitems: false },

        colModel: [
            { label:'',name: 'edit', search: false, index: 'ID',align: 'center', cellsalign: 'center', width: 60, sortable: false, formatter: editLink },
            {  label:'',name: 'delete', search: false, index: 'ID', align: 'center', cellsalign: 'center', width: 60, sortable: false, formatter: deleteLink },
            { label: 'Id', name: 'ID',index: 'ID', key: true, width: 30 },
            { label: 'Title', name: 'Title',index:'Title', width: 250 },
            { label: 'Description', name: 'Description',index:'Description', width: 350 },
            { label: 'Due on', name: 'DueDate', index: 'DueDate', width: 150, formatter: 'date', formatoptions: { srcformat: 'm/d/Y', newformat: 'm/d/Y' } },
            {
                label: 'Completed', name: 'IsCompleted', Index: 'IsCompleted', width: 150, editable: true,
                edittype: 'checkbox', editoptions: { value: "True:False" },
                formatter: "checkbox", formatoptions: { disabled: false }
            }
        ],
       
        height: 250,
        rowNum: 20,
        pager: "#gridPager",
        loadComplete: function () {
            
            $(".jqgrow td input").on("click", function (e) {
                var ischecked = $(this).is(':checked');
                var newid = $(e.target).closest('tr')[0].id;

                $.post("/OnOff/Edit",
                    { id: newid, newvalue: ischecked },
                        gridIni
                    );

            });
            $(".jqgrow td[title=edit]").on("click", function (e) {
                var id = $(e.target).closest('tr')[0].id;
                //alert('edit ' + id);
                GetModalEdit("/ToDo/Details/"+id)
            });
            $(".jqgrow td[title=delete]").on("click", function (e) {
                var id = $(e.target).closest('tr')[0].id;
                if (!confirm('are you sure you want to delete this item?'))
                    return;

                $.post("/ToDo/Delete/"+id, function (data) {
                    gridIni();
                });
            });
           
        }
    });
    function editLink(cellValue, options, rowdata, action) {
        var rs = "<a href='#'>edit</a>";
        return rs;
    }
    function deleteLink(cellValue, options, rowdata, action) {
        var rs = "<a href='#'>delete</a>";
        return rs;
    }
    function emptygrid(title) {
        $("#tcontainer").empty();
        $("#tcontainer").append('<h3>' + title + '</h3><table id="grid"></table><div id="gridPager"></div>');
    }
      
}
function GetModalEdit(url) {

    $.get(url, function (data) {
        $('#todoContainer').html(data);

        $('#todoModal').modal('show');
    });

}
window.closeModal = function () {
    $('#todoModal').modal('hide');
}
function DeleteCompleted()
{
    if (!confirm('are you sure you want to delete all completed items?'))
        return;
    $.post("/ToDo/DeleteAllCompletedTasks", function (data) {
        gridIni();
    });

}