<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品浏览</title>
    <link href="images/Admin_css.css" type="text/css" rel="stylesheet"/>
    <style type="text/css">
    .price_02 {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 16px;
	font-style: normal;
	line-height: 20px;
	font-weight: bold;
	color: #FF0000;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <tr>
                <td style="height:1px;background-color:#6298e1">
                </td>
            </tr>
            <tr>
                <td align="middle" bgcolor="#ebf2f9" height="30">
                    <table cellspacing="0" width="99%" border="0">
                        <tbody>
                            <tr style="text-align:left;">
                                <td>
                                    货号：<asp:TextBox ID="txtHuoHao" runat="server"></asp:TextBox>&nbsp;产品名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;类别：<asp:DropDownList ID="ddlLeibei" runat="server"></asp:DropDownList>
                                    每页显示<asp:TextBox ID="txtPageSize" runat="server" Width="30" Text="50"></asp:TextBox> 个产品<asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="确定" />
                                </td>
                                <td><a href="ReportOutAgent.aspx" target="_blank" style="color:Red">[发货查询]</a></td>
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
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
                <tr>
                    <td>
                    <%=strLeibeiLink %>
                    </td>
                </tr>
        </table>
<table border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:DataList runat="server" ID="rpData" RepeatColumns="5" RepeatDirection="Horizontal" CellSpacing="0" >
                <ItemTemplate>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height:280px;">
                            <td width="180" style="vertical-align:top;">
                                <table width="160" border="0" cellspacing="0" cellpadding="0">
                                    <tr style="height:200px" valign="top">
                                        <td align="center" valign="top">
                                            <a onclick="window.showModalDialog('ShowPic.aspx?id=<%#Eval("Id") %>',window,'dialogHeight: 600px; dialogWidth: 700px;resizable: yes; status: no;');" style="color:Blue;cursor:pointer;">
                        <%#GetImagesItem((string)Eval("pic")) %></a>
                                            <%--<a href='productinfo.aspx?pid=<%#Eval("productid") %>&class=<%#Eval("typeid_1") %>'>
                                                <img style="border: 0px" alt="" src="pic/<%#Eval("imagepath").ToString() %>" width="182px"
                                                    height="266px" /></a>--%></td>
                                    </tr>
                                    <tr style="height:20px; font-size:16px;">
                                        <td align="center">
                                                [<a href="Default.aspx?leibei=<%#Eval("LeiBei")%>" style="text-decoration:underline;"><%#Eval("LeiBei")%></a>]<font color="blue"><%#Eval("ProductName")%></font>
                                        </td>
                                    </tr>
                                    <tr style="height:20px;">
                                        <td align="left">
                                                货号：<font color="blue"><%#Eval("HuoHao")%>
                                        </td>
                                    </tr>
                                    <tr style="height:20px;">
                                        <td align="left">
                                                建议销售价：<span class="price_02"><%#Eval("PriceSell")%></span>
                                        </td>
                                    </tr>
                                    <tr style="height:20px;">
                                        <td align="left">
                                                尺寸：<%#Eval("Size")%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td style="height: 5px;">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
                                            <tr>
                                                <td align="center" style="margin-top:10px;"><br />
                                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" OnPageChanging="AspNetPager1_PageChanging"
                                                            Width="100%" PageIndexBoxStyle="width:19px" FirstPageText="【首頁】" LastPageText="【尾頁】"
                                                            NextPageText="【下一頁】" PrevPageText="【前一頁】" NumericButtonTextFormatString="【{0}】"
                                                            TextAfterPageIndexBox="頁" TextBeforePageIndexBox="轉到第" CustomInfoHTML="Page  <font color='red'><b>%CurrentPageIndex%</b></font> of  %PageCount%&nbsp;&nbsp;Order %StartRecordIndex%-%EndRecordIndex%">
                                                        </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
</table>
<%--        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <tr>
                <td align="middle" width="80"></td>
                <td align="middle" width="120" style="height:25px">
                    <font color="#ffffff"><strong>类别</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>货号</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>产品名称</strong></font>
                </td>
                <td align="middle" width="120">
                    <strong><font color="#ffffff">产品尺寸</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">重量(kg)</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">建议销售价</font></strong>
                </td>
                <td align="middle">
                    <strong><font color="#ffffff">更新时间</font></strong>
                </td>
                </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9" style="height:25px">
                        <td><a onclick="window.showModalDialog('ShowPic.aspx?id=<%#Eval("Id") %>',window,'dialogHeight: 600px; dialogWidth: 700px;resizable: yes; status: no;');" style="color:Blue">浏览所有图片</a>
                        <%#GetImagesItem((string)Eval("pic")) %>
                        </td>
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
                            &nbsp;<%#Eval("Size")%>
                        </td>
                        <td nowrap style="text-align:right">
                            &nbsp;<%#Eval("Weight")%>
                        </td>
                        <td nowrap style="text-align:right">
                            &nbsp;<%#Eval("PriceSell")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("UpdateOn")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>--%>
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
