$(function () {
    loadData(-1);  //页面刚刷新时候
    $("#addDiv").css("display", "none");   //加载时候隐藏新增table
    $("#editDiv").css("display", "none");//加载时候隐藏编辑table
});
function loadData(date) {
    $('#tt').datagrid({
        url: '/TeacherArea/StudentList/GetStuInfoList',   //post请求控制器方法需要的数据
        title: '用户数据表格',
        width: 1000,
        height: 410,
        fitColumns: true, //列自适应
        nowrap: false,
        idField: 'StudentId',//主键列的列名
        loadMsg: '正在加载用户的信息...',
        pagination: true,//是否有分页
        singleSelect: false,//是否单行选择
        pageSize: 5,//页大小，一页多少条数据
        pageNumber: 1,//当前页，默认的
        pageList: [5, 10, 15],  //  设置选择每页可以显示多少
        queryParams: { classId: date },//往后台传递参数
        columns: [[//c.UserName, c.UserPass, c.Email, c.RegTime
            { field: 'ck', checkbox: true, align: 'left', width: 50 },
            { field: 'StudentId', title: '学号', width: 80 },
            { field: 'StudentName', title: '姓名', width: 120 },
            { field: 'StudentClassName', title: '班级', width: 120 },
            {
                field: 'kk', title: '考试详情', width: 50,
                formatter: function (value, rowDate, RowIndex) {

                    return "<a href='/TeacherArea/StudentList/StudentAllTest?StudentId=" + rowDate.StudentId + "'>详情</a>";

                }

            },
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
            id: 'btnSetUserRole',
            text: '用户角色分配',
            iconCls: 'icon-edit',
            handler: function () {

                showSetUserRoleInfo();
            }
        }, {
            id: 'btnSetUserAction',
            text: '用户权限分配',
            iconCls: 'icon-edit',
            handler: function () {

                showSetUserActionInfo();
            }
        }],
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
                strId = strId + rows[i].Id + ",";//1,2,3,
            }
            //去掉最后一个逗号.
            strId = strId.substr(0, strId.length - 1);
            //将获取的要删除的记录的ID值发送到服务端.
            $.post("/AdminNewList/DeleteUserInfo", { "strId": strId }, function (data) {

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

//新增
function addInfo() {
    $("#addDiv").css("display", "block");
    $('#addDiv').dialog({
        title: '添加用户数据',
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
            UName: "required",//表示对哪个表单元素进行校验，要写具体的表单元素的name属性的值
            UPwd: {
                required: true,
                minlength: 5
            },
            UEmail: {
                required: true,
                email: true
            }
        },
        messages: {
            UName: "请输入用户名",
            UPwd: {
                required: "请输入密码",
                minlength: jQuery.format("密码不能小于{0}个字 符")
            },
            UEmail: "请输入一个正确的邮箱"
        }
    });
}

//展示一下要修改的数据.
function showEditInfo() {
    //判断一下用户是否选择了要修改的数据
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (rows.length != 1) {
        $.messager.alert("提示", "请选择要修改的数据", "error");
        return;
    }
    //将要修改的数据查询出来，显示到文本框中。
    var id = rows[0].Id;
    $.post("/AdminNewList/ShowEditInfo", { "id": id }, function (data) {
        $("#txtId").val(data.Id);
        $("#txtUName").val(data.UserName);
        $("#txtUPwd").val(data.UserPwd);
        $("#txtUEmail").val(data.UserMail);
    });
    $("#editDiv").css("display", "block");
    $('#editDiv').dialog({
        title: '编辑用户数据',
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
                //表单校验
                validateInfo($("#editForm"));
                $("#editForm").submit();//提交表单
            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#editDiv').dialog('close');
            }
        }]
    });
}

//更新以后调用该方法.
function afterEdit(data) {
    if (data == "ok") {
        $('#editDiv').dialog('close');
        $('#tt').datagrid('reload');//加载表格不会跳到第一页。
    } else {
        $.messager.alert("提示", "修改的数据失败", "error");
    }
    $('#tt').datagrid("clearSelections");
}




