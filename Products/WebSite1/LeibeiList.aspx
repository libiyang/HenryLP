<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeibeiList.aspx.cs" Inherits="LeibeiList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>类别管理</title>
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
                                    <td><a href="LeibeiEdit.aspx" target="_blank" style="color:Blue">添加类别</a></td>
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
                <td align="middle" width="150px"></td>
                <td align="left" width="">
                    <font color="#ffffff"><strong>类型</strong></font>
                </td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9">
                        <td align="middle" height="24">
                            <a href="LeibeiEdit.aspx?id=<%#Eval("Id") %>" style="color:Blue">修改</a>&nbsp;&nbsp;<a href="LeibeiEdit.aspx?id=<%#Eval("Id") %>&del=1" style="color:Blue">删除</a>
                        </td>
                        <td>
                            &nbsp;<%#Eval("LeibeiName")%>&nbsp;&nbsp;[<a href="ProductList.aspx?leibei=<%#Eval("LeibeiName") %>" style="color:Blue">查看产品</a>]
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
