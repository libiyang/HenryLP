<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportOrderStat.aspx.cs" Inherits="Jufeng_ReportOrderStat" %>

<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单</title>
    <link href="../images/Admin_css.css" type="text/css" rel="stylesheet"/>
    <script language="JavaScript" type="text/javascript">
        function delOp(id, obj) {
            if (confirm("确定删除吗？")) {
                window.open("ReportOrderDel.aspx?id=" + id);
                alert('操作成功');
                delCol();
            }
        }
        function delCol() {
            try {
                var Elm = event.srcElement;
                while (Elm && Elm.tagName != "TR") {
                    Elm = Elm.parentElement;
                }
                if (Elm.parentElement.rows.length <= 1) {
                    return;
                }
                Elm.parentElement.deleteRow(Elm.rowIndex);
            } catch (e) {
            }
        }
    </script>
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
                                    <td style="width:100px">帐表日期：<asp:TextBox ID="txtDate" runat="server" onclick="calendar.show(this);" style="width: 80px"></asp:TextBox>—<asp:TextBox ID="txtDate2" runat="server" onclick="calendar.show(this);" style="width: 80px"></asp:TextBox><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查 询" /></td>
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
            <tr style="height:25px;font-size:14px;">
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>代理商</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>货号</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>产品名称</strong></font>
                </td>
                <td align="middle" width="100">
                    <strong><font color="#ffffff">下单数量</font></strong>
                </td>
                <td align="left"></td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9" style="height:25px;">
                        <td nowrap>
                            &nbsp;<%#Eval("AgentName")%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("HuoHao") %>
                        </td>
                        <td>
                            &nbsp;<%#Eval("ProductName") %>
                        </td>
                        <td nowrap align="right">
                            &nbsp;<%#Eval("OrderAmount")%>
                        </td>
                        <td align="middle">
                         <a href="ShowPic.aspx?id=<%#Eval("ProductId") %>" style="color:Blue;cursor:pointer" target="_blank">浏览大图</a>
                        <%#GetImagesItem((string)Eval("pic")) %>
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
    <script src="../Js/calendar.js" type="text/javascript"></script>
    </form>
</body>
</html>
