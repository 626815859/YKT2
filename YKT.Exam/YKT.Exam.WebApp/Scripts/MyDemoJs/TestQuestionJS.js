﻿$(function () {
    loadData(-1);  //页面刚刷新时候
    $("#addDiv").css("display", "none");   //加载时候隐藏新增table
    $("#editDiv").css("display", "none");//加载时候隐藏编辑table
    $("#createBaseTestPaperDiv").css("display", "none");
    //  $("#options").css("display", "none");  ///隐藏选择的选择项


    $("#ViewTestQuestionType").change(function () {
        var checkValue = $("#ViewTestQuestionType").val();
        if(checkValue==0)   //选择题
        {
            $("#JianDaType").css("display", "none");  //隐藏
            $("#options").css("display", "block");  //隐藏选择的选择项
            $("#JudgeType").css("display", "none");  //隐藏
        }
        else if(checkValue==1)    //判断题
        {
            $("#JianDaType").css("display", "none");  //隐藏
            $("#JudgeType").css("display", "block");  //隐藏选择的选择项
            $("#options").css("display", "none");  //显示选择的选择项
        }
        else if (checkValue==3)
        {
            $("#JudgeType").css("display", "none");  ///
            $("#options").css("display", "none");  //显示选择的选择项
            $("#JianDaType").css("display", "block");  //
        }
        else     //其他
        {
            $("#JianDaType").css("display", "none");  //隐藏选择的选择项
            $("#JudgeType").css("display", "none");  //隐藏选择的选择项
            $("#options").css("display", "none");  //显示选择的选择项
        }

    })

});
function loadData(date) {
    $('#tt').datagrid({
        url: '/TeacherArea/TestQuestionList/GetTestQuestionAllInfo',   //post请求控制器方法需要的数据
        title: '题库数据表格',
        width: 1000,
        height: 410,
        fitColumns: true, //列自适应
        nowrap: false,
        idField: 'ViewTestQuestionId',//主键列的列名
        loadMsg: '正在加载题库的信息...',
        pagination: true,//是否有分页
        singleSelect: false,//是否单行选择
        pageSize: 5,//页大小，一页多少条数据
        pageNumber: 1,//当前页，默认的
        pageList: [5, 10, 15],  //  设置选择每页可以显示多少
        queryParams: { ViewTestQuestionId: date },//往后台传递参数
        columns: [[//c.UserName, c.UserPass, c.Email, c.RegTime
            { field: 'ck', checkbox: true, align: 'left', width: 50 },
            { field: 'ViewTestQuestionId', title: '编号', width: 80 },
            { field: 'ViewTestQuestionType', title: '类型', width: 80 },
            { field: 'ViewTestQuestionName', title: '题名', width: 120 },
            { field: 'ViewTestQuestionResult', title: '答案', width: 120 },
            { field: 'ViewTestQuestionGrade', title: '分数', width: 120 }
        ]],
        toolbar: [{
            id: 'btnDelete',
            text: '删除',
            iconCls: 'icon-remove',
            handler: function () {

                deleteInfo();
            }
        }, {
            id: 'btnAdd',
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {

                addInfo();
            }
        }, {
            id: 'btnEidt',
            text: '编辑',
            iconCls: 'icon-edit',
            handler: function () {

                showEditInfo();
            }
        }, {
            id: 'btnCreatTestPaper',
            text: '形成试卷',
            iconCls: 'icon-add',
            handler:function(){
                CreatTestPaper();
            }
        }],
    });
}
//新增
function addInfo() {
    $("#addDiv").css("display", "block");
    $('#addDiv').dialog({
        title: '添加题库数据',
        width: 800,
        height: 200,
        collapsible: true,
        maximizable: true,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function () {
                //表单校验
                validateInfo($("#addForm"));   //addForm是最开始隐藏的那个添加表单的Id
                $("#addForm").submit();//提交表单
            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#addDiv').dialog('close');
            }
        }]
    });
}
//完成添加后调用该方法
function afterAdd(data) {
    if (data == "ok") {
        $('#addDiv').dialog("close");
        $('#tt').datagrid("reload", {});//加载表格不会跳到第一页。
        $("#addForm input").val("");
    }
    else {
        $.messager.alert("提醒", "添加失败!", "error");
    }
}

//表单校验
function validateInfo(control) {
    control.validate({//表示对哪个form表单进行校验，获取form标签的id属性的值
        rules: {//表示验证规则
            ViewTestQuestionName: "required",//表示对哪个表单元素进行校验，要写具体的表单元素的name属性的值
            ViewTestQuestionResult: "required",
            ViewTestQuestionGrade: "required"
        },
        messages: {
            ViewTestQuestionName: "请输入用户名",
            ViewTestQuestionResult: "请输入答案",
            ViewTestQuestionGrade: "请输入分值"
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
//组合试卷
function CreatTestPaper() {

    $("#createBaseTestPaperDiv").css("display", "block");
    $('#createBaseTestPaperDiv').dialog({
        title: '添加试卷信息',
        width: 800,
        height: 200,
        collapsible: true,
        maximizable: true,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function () {
            
                CreateBasePaperPost();
              //  $("#CreateBasePaperForm").submit();//提交表单
            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#createBaseTestPaperDiv').dialog('close');
            }
        }]
    });
}

function CreateBasePaperPost()
{
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (!rows || rows.length == 0) {
        $.messager.alert("提醒", "请选择要组成的试题!", "error");
        return;
    }
    //获取要选中的记录的ID值。
    var rowsLength = rows.length;
    var strId = "";
    for (var i = 0; i < rowsLength; i++) {
        strId = strId + rows[i].ViewTestQuestionId + ",";//1,2,3,
    }
    //去掉最后一个逗号.
    strId = strId.substr(0, strId.length - 1);

   // $.messager.alert("提醒", "测试!", "error");

    $.post("/TeacherArea/TestQuestionList/CreatBaseTestPaper", { "strId": strId, "baseTestPaperName": $("#baseTestPaperName").val(), "baseTestPaperType": $("#baseTestPaperType").val() }, function (data) {

        if (data == "ok") {
            alert("试卷组合成功!");
            $('#tt').datagrid("reload", {});//加载表格不会跳到第一页。
            //清除上次操作的历史的记录。
            $('#tt').datagrid("clearSelections")
        } else {
            $.messager.alert("提醒", "试卷组合失败!", "error");
        }
    });

}


