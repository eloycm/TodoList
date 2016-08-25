
var grid = $("#grid");
$(document).ready(function () {
    gridIni();

});
function gridIni() {
    emptygrid("ToDoList");
    $("#grid").jqGrid({
        url: '/getlist/paged',
        mtype: "GET",
        datatype: "json",
        gridview:true,
        colModel: [
            { label: 'Id', name: 'ID',index: 'ID', key: true, width: 75 },
            { label: 'Title', name: 'Title',index:'Title', width: 150 },
            { label: 'Description', name: 'Description',index:'Description', width: 150 },
            { label: 'Due on', name: 'DueDate',index:'DueDate', width: 150 },
            { label: 'Completed', name: 'IsCompleted', Index:'IsCompleted', width: 150 }
        ],
        viewrecords: true,
        height: 250,
        rowNum: 20,
        pager: "#gridPager"
    });
    function emptygrid(title) {
        $("#tcontainer").empty();
        $("#tcontainer").append('<h3>' + title + '</h3><table id="grid"></table><div id="gridPager"></div>');
    }
}
