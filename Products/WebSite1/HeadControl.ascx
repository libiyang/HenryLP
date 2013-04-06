<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeadControl.ascx.cs" Inherits="HeadControl" %>

<table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
        <tr style="height:25px;text-align:left">
        <%if (Session["UserType"].ToString() == "2")
          { %>
            <td style="width:100px">
                <a href="ProductList2.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>产品管理</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="ReportOutDate.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>日帐表</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="ReportOutAll.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>月帐表</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="ReportInAll.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>入库帐表</strong></font></a>
            </td>
            <td>
                <a href="Login.aspx?logout=1" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>退出登入</strong></font></a>
            </td>
        <%}
          else
          { %>
            <td style="width:100px">
                <a href="ProductList.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>产品管理</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="ReportOutDate.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>日帐表</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="ReportOutAll.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>月帐表</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="ReportInAll.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>入库帐表</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="UserList.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>用户管理</strong></font></a>
            </td>
            <td style="width:100px">
                <a href="LeibeiList.aspx" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>类别管理</strong></font></a>
            </td>
            <td>
                <a href="Login.aspx?logout=1" style="text-decoration:underline;font-size:14px;"><font color="#ffffff"><strong>退出登入</strong></font></a>
            </td>
            
            <%} %>
        </tr>
</table>