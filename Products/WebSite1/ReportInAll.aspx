<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportInAll.aspx.cs" Inherits="ReportInAll" %>

<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入库帐表</title>
    <link href="images/Admin_css.css" type="text/css" rel="stylesheet"/>
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
                                    <td style="width:100px">帐表日期：<asp:TextBox ID="txtDate" runat="server" onclick="calendar.show(this);" style="width: 80px"></asp:TextBox>—<asp:TextBox ID="txtDate2" runat="server" onclick="calendar.show(this);" style="width: 80px"></asp:TextBox>&nbsp;货号：<asp:TextBox ID="txtHuoHao" runat="server"></asp:TextBox>&nbsp;产品名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;类别：<asp:DropDownList ID="ddlLeibei" runat="server"></asp:DropDownList>&nbsp;代理商：<asp:DropDownList ID="ddlAgent" runat="server"></asp:DropDownList><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查 询" /></td>
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
                <td align="middle" width="60">
                    <font color="#ffffff"><strong>类别</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>货号</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>产品名称</strong></font>
                </td>
                <td align="middle" width="160">
                    <font color="#ffffff"><strong>代理商</strong></font>
                </td>
                <td align="middle" width="160">
                    <strong><font color="#ffffff">入库时间</font></strong>
                </td>
                <td align="middle" width="100">
                    <strong><font color="#ffffff">入库数量</font></strong>
                </td>
                <td align="middle" width="120"></td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9" style="height:25px;">
                        <td>
                            &nbsp;<%#Eval("LeiBei")%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("HuoHao") %>
                        </td>
                        <td>
                            &nbsp;<%#Eval("ProductName") %>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("AgentName")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("ReportDate")%>
                        </td>
                        <td nowrap align="right">
                            &nbsp;<%#Eval("AmountIn")%>
                        </td>
                        <td align="middle"><a onclick="window.showModalDialog('ShowPic.aspx?id=<%#Eval("ProductId") %>',window,'dialogHeight: 600px; dialogWidth: 700px;resizable: yes; status: no;');" style="color:Blue">浏览所有图片</a>
                        <%#GetImagesItem((string)Eval("pic")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr style="height:25px">
                <td align="middle">
                    
                </td>
                <td align="middle" width="120">
                    
                </td>
                <td align="middle" width="120">
                    
                </td>
                <td align="middle">
                    
                </td>
                <td align="middle">
                    
                </td>
                <td align="right">
                    <%=TotalCount %>
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
    </form>
</body>
</html>
