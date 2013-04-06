<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员/代理商管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <tr bgcolor="#ebf2f9"><td style="width:100px">用户名称：</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>登录帐号：</td><td><asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>登录密码：</td><td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>用户类型：</td><td><asp:RadioButtonList ID="rbUserType" runat="server"><asp:ListItem Text="代理商" Value="2" Selected="True"></asp:ListItem><asp:ListItem Text="管理员" Value="1"></asp:ListItem></asp:RadioButtonList></td></tr>
            <tr bgcolor="#ebf2f9"><td>&nbsp;</td><td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="确定" /></td></tr>
        </table>
    
    </div>
    </form>
</body>
</html>
