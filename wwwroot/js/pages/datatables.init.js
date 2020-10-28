$(document).ready(function () {
    $("#datatable").DataTable({
        oLanguage: {
            oAria: {
                sSortAscending: ": 升序排列",
                sSortDescending: ": 降序排列",
            },
            oPaginate: {
                sFirst: "首页",
                sLast: "末页",
                sNext: "下一页",
                sPrevious: "上一页",
            },
            sEmptyTable: "该表中没有数据",
            sInfo: "第 _START_ 页，每页 _END_ 条记录，共计 _TOTAL_ 条记录",
            sInfoEmpty: "该表中无任何数据",
            sInfoFiltered: "(筛选自 _MAX_ 条记录)",
            sInfoPostFix: "",
            sDecimal: "",
            sThousands: ",",
            sLengthMenu: "每页展示 _MENU_ 条记录",
            sLoadingRecords: "加载中...",
            sProcessing: "处理中...",
            sSearch: "搜索：",
            sSearchPlaceholder: "",
            sUrl: "",
            sZeroRecords: "没有找到符合条件的记录",
        }
    });
});