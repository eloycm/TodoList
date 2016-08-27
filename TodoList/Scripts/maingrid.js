
var grid = $("#grid");
$(document).ready(function () {
    gridIni();

    $(".jqgrow td input").on("click",function () {
        alert('ciao');
    });
});
function gridIni() {
    emptygrid("ToDoList");
    $("#grid").jqGrid({
        url: '/getlist/paged',
        mtype: "GET",
        datatype: "json",
        jsonReader: { repeatitems: false },

        colModel: [
            { name: 'edit', search: false, index: 'ID', width: 30, sortable: false, formatter: editLink },
            { name: 'delete', search: false, index: 'ID', width: 35, sortable: false, formatter: deleteLink },
            { label: 'Id', name: 'ID',index: 'ID', key: true, width: 75 },
            { label: 'Title', name: 'Title',index:'Title', width: 150 },
            { label: 'Description', name: 'Description',index:'Description', width: 150 },
            { label: 'Due on', name: 'DueDate', index: 'DueDate', width: 150, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
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
                alert('ciao ' + newid + 'checked' + ischecked);

            });
            $(".jqgrow td[title=edit]").on("click", function (e) {
                var id = $(e.target).closest('tr')[0].id;
                //alert('edit ' + id);
                GetModalEdit("/ToDo/Details/"+id)
            });
            $(".jqgrow td[title=delete]").on("click", function (e) {
                var id = $(e.target).closest('tr')[0].id;
                alert('delete ' + id);
            });
            //td[title=Herbert]'
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
    function GetModalEdit(url) {

        $.get(url, function(data) {
            $('#todoContainer').html(data);

            $('#todoModal').modal('show');
        });

    }
    window.closeModal = function () {
        $('#todoModal').modal('hide');
    };

    
}
