<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportOut.aspx.cs" Inherits="ReportOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出库</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <%--<tr bgcolor="#ebf2f9"><td style="width:100px">出库日期：</td><td><asp:TextBox ID="txtDate" runat="server" onclick="calendar.show(this);" style="width: 80px"></asp:TextBox></td></tr>--%>
            <tr bgcolor="#ebf2f9"><td style="width:100px">产品名称：</td><td><asp:Label ID="lblName" runat="server"></asp:Label></td></tr>
            <tr bgcolor="#ebf2f9"><td>产品货号：</td><td><asp:Label ID="lblHuoHao" runat="server"></asp:Label></td></tr>
            <tr bgcolor="#ebf2f9"><td>出库数量：</td><td><asp:TextBox ID="txtAmount" runat="server" style="width: 80px"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>实际销售价：</td><td><asp:TextBox ID="txtPriceSell" runat="server" Text="0"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>代理商<%--<input type="checkbox" id="cbSelectAllType" />全选--%></td><td><asp:CheckBoxList ID="cbAgent" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"></asp:CheckBoxList></td></tr>
            <tr bgcolor="#ebf2f9"><td>备注说明</td><td><asp:TextBox ID="txtRemark" runat="server" MaxLength="250" Width="500px"></asp:TextBox></td></tr>
            <tr bgcolor="#ebf2f9"><td>&nbsp;</td><td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="确定" /></td></tr>
        </table>
    </div>
    <script src="Js/calendar.js" type="text/javascript"></script>
    </form>
</body>
</html>
