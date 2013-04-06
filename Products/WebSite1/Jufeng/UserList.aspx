<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Jufeng_UserList" %>

<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员/代理商管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeadControl ID="HeadControl1" runat="server" />
    
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
                <tr style="height:25px;text-align:left">
                    <td bgcolor="#ebf2f9" height="30">
                        <table cellspacing="0" width="99%" border="0">
                            <tbody>
                                <tr>
                                    <td><a href="UserEdit.aspx" target="_blank" style="color:Blue">添加用户/代理商</a></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
        </table>
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
                <tr>
                    <td height="5">
                    </td>
                </tr>
        </table>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <tr style="height:25px">
                <td align="middle" width="100"></td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>用户名称</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>登录帐号</strong></font>
                </td>
                <td align="middle" width="120">
                    <strong><font color="#ffffff">登录密码</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">用户类型</font></strong>
                </td>
                <td align="middle">
                    <strong><font color="#ffffff">最后登录时间</font></strong>
                </td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9">
                        <td align="middle" height="24">
                            <a href="UserEdit.aspx?id=<%#Eval("Id") %>" style="color:Blue">修改</a>&nbsp;&nbsp;<a href="UserEdit.aspx?id=<%#Eval("Id") %>&del=1" style="color:Blue">删除</a>
                        </td>
                        <td>
                            &nbsp;<%#Eval("UserName")%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("LoginName")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("Password")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#(int)Eval("UserType")==1?"<font color='red'>管理员</font>":"代理商"%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("LastLoginDate")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
                <tr>
                    <td height="5">
                    </td>
                </tr>
        </table>
    </div>
    </form>
</body>
</html>
