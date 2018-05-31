$(function () {
    loadData(-1);  //页面刚刷新时候
    $("#SendTestPaper").css("display", "none");
});
function loadData(date) {
    $('#tt').datagrid({
        url: '/TeacherArea/BaseTestPaperList/GetBaseTestPaperAllInfo',   //post请求控制器方法需要的数据
        title: '基试卷列表',
        width: 1000,
        height: 410,
        fitColumns: true, //列自适应
        nowrap: false,
        idField: 'ViewBaseTestPaperId',//主键列的列名
        loadMsg: '正在加载试卷的信息...',
        pagination: true,//是否有分页
        singleSelect: false,//是否单行选择
        pageSize: 5,//页大小，一页多少条数据
        pageNumber: 1,//当前页，默认的
        pageList: [5, 10, 15],  //  设置选择每页可以显示多少
        queryParams: { ViewTestQuestionId: date },//往后台传递参数
        columns: [[//c.UserName, c.UserPass, c.Email, c.RegTime
            { field: 'ck', checkbox: true, align: 'left', width: 50 },
            { field: 'ViewBaseTestPaperId', title: '编号', width: 80 },
            { field: 'ViewBaseTestPaperName', title: '名称', width: 80 },
            { field: 'ViewBaseTestPaperType', title: '类型备注', width: 120 },
                 {
                     field: 'ViewBaseTestPaperCreateTime', title: '发布时间', width: 80, align: 'right',
                     formatter: function (value, row, index) {
                         if (value == null)   //时间如果为null，就会报错，所以判断下
                         {
                             return null;
                         }
                         else {
                             return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d");

                         }
                     }
                 }
        ]],
        toolbar: [{
            id: 'btnDelete',
            text: '删除',
            iconCls: 'icon-remove',
            handler: function () {

                deleteInfo();
            }
        },{
            id: 'CreateTestPaper',
            text: '发布试卷',
            iconCls: 'icon-add',
            handler: function () {
                CreatTestPaper();
            }
        }],
    });
}

//组合试卷
function CreatTestPaper() {

    $("#SendTestPaper").css("display", "block");
    $('#SendTestPaper').dialog({
        title: '添加试卷信息',
        width: 400,
        height: 200,
        collapsible: true,
        maximizable: true,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function () {

                CreateSendTestPaper();
                //  $("#CreateBasePaperForm").submit();//提交表单
            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#SendTestPaper').dialog('close');
            }
        }]
    });
}

function CreateSendTestPaper()
{
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (!rows || rows.length == 0) {
        $.messager.alert("提醒", "请选择要发布的试卷!", "error");
        return;
    }
    if(rows.length!=1)
    {
        $.messager.alert("提醒", "请选择1套题,请勿多选!", "error");
        return;
    }
    var stubaseTestPaperId = rows[0].ViewBaseTestPaperId;
    var stuClassId = $("#stuClass").val();
    var stuCourseId = $("#stuCourse").val();
   // alert("nihao");

    var StartTime = $('#StartTime').datetimebox('getValue');
    var EndTime = $('#EndTime').datetimebox('getValue');
    alert(StartTime);
    $.post("/TeacherArea/BaseTestPaperList/CreatSendPaper", { "stubaseTestPaperId": stubaseTestPaperId, "stuClassId": stuClassId, "stuCourseId": stuCourseId, "StartTime": StartTime, "EndTime": EndTime }, function (data) {

        if (data == "ok") {
            alert("试卷发布成功!");
            $('#tt').datagrid("reload", {});//加载表格不会跳到第一页。
            //清除上次操作的历史的记录。
            $('#tt').datagrid("clearSelections")
        } else {
            $.messager.alert("提醒", "试卷发布失败!", "error");
        }

    });
}


//删除数据
function deleteInfo() {
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (!rows || rows.length == 0) {
        //alert("请选择要修改的商品！");
        $.messager.alert("提醒", "请选择要删除的记录!", "error");
        return;
    }
    $.messager.confirm("提示", "确定要删除数据吗", function (r) {
        if (r) {
            //获取要删除的记录的ID值。
            var rowsLength = rows.length;
            var strId = "";
            for (var i = 0; i < rowsLength; i++) {
                strId = strId + rows[i].ViewTestQuestionId + ",";//1,2,3,
            }
            //去掉最后一个逗号.
            strId = strId.substr(0, strId.length - 1);
            //将获取的要删除的记录的ID值发送到服务端.
            $.post("/TeacherArea/TestQuestionList/DeleteTestQuestions", { "strId": strId }, function (data) {

                if (data == "ok") {
                    alert("删除成功!");
                    $('#tt').datagrid("reload", {});//加载表格不会跳到第一页。
                    //清除上次操作的历史的记录。
                    $('#tt').datagrid("clearSelections")
                } else {
                    $.messager.alert("提醒", "删除记录失败!", "error");
                }
            });
        }
    });
}

