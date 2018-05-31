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
        queryParams: { studentId: date },//往后台传递参数
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