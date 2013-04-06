<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeibeiEdit.aspx.cs" Inherits="LeibeiEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <tr bgcolor="#ebf2f9"><td style="width:100px">类别名称：</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>&nbsp;</td><td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="确定" /></td></tr>
        </table>    
    </div>
    </form>
</body>
</html>
