<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportOutAgent.aspx.cs" Inherits="ReportOutAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发货查询</title>
    <link href="images/Admin_css.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
                <tr style="height:25px;text-align:left">
                    <td bgcolor="#ebf2f9" height="30">
                        <table cellspacing="0" width="99%" border="0">
                            <tbody>
                                <tr>
                                    <td style="width:100px">发货日期：</td><td><asp:TextBox ID="txtDate" runat="server" onclick="calendar.show(this);" style="width: 80px"></asp:TextBox><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查 询" /></td>
            <td>
                <a href="Login.aspx?logout=1" style="text-decoration:underline;font-size:14px;"><font color="Red"><strong>退出登入</strong></font></a>
            </td>
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
                <td align="middle" width="160">
                    <font color="#ffffff"><strong>货号</strong></font>
                </td>
                <td align="middle" width="160">
                    <font color="#ffffff"><strong>产品名称</strong></font>
                </td>
                <td align="middle" width="160">
                    <strong><font color="#ffffff">出库数量</font></strong>
                </td>
                <td align="middle" width="160">
                    <strong><font color="Red">汇总</font></strong>
                </td>
                <td align="middle"></td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9" style="height:25px;">
                        <td>
                            &nbsp;<%#Eval("HuoHao") %>
                        </td>
                        <td>
                            &nbsp;<%#Eval("ProductName") %>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("AmountOut")%>
                        </td>
                        <td nowrap align="right">
                            &nbsp;<%#Eval("AmountFee")%>
                        </td>
                        <td align="middle"><a onclick="window.showModalDialog('ShowPic.aspx?id=<%#Eval("ProductId") %>',window,'dialogHeight: 600px; dialogWidth: 700px;resizable: yes; status: no;');" style="color:Blue">浏览所有图片</a>
                        <%#GetImagesItem((string)Eval("pic")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr style="height:25px">
                <td align="middle" width="160">
                    
                </td>
                <td align="middle">
                    
                </td>
                <td align="middle">
                    
                </td>
                <td width="160" align="right">
                    <%=TotalFee %>
                </td>
                <td align="middle"></td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
                <tr>
                    <td height="5">
                    </td>
                </tr>
        </table>
    </div>
    <script src="Js/calendar.js" type="text/javascript"></script>
    </div>
    </form>
</body>
</html>
