<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesFooter.aspx.cs" Inherits="Jufeng_SalesFooter" %>

<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>外销合同</title>
    <script language="JavaScript" type="text/javascript">
        function delOp(id, obj) {
            if (confirm("确定删除吗？")) {
                window.open("SalesFooterDel.aspx?id=" + id);
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
<body><%--外销合同号 产品货号 产品描述 产品尺寸 单位 币别 美金售价。--%>

    <form id="form1" runat="server">
    <div>
        <uc1:HeadControl ID="HeadControl1" runat="server" />
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
                <tr style="height:25px;text-align:left">
                    <td bgcolor="#ebf2f9" height="30">
                        <table cellspacing="0" width="99%" border="0">
                            <tbody>
                                <tr>
                                    <td nowrap>
                                        合同号：<asp:TextBox ID="txtSCID" runat="server"></asp:TextBox>&nbsp;
                                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查找" />
                                    </td>
                                    <td><a href="SalesFooterUploadPic.aspx" style="color:Blue" >上传图片</a></td>
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
                <td align="middle" width="80"></td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>外销合同号</strong></font>
                </td>
                <td align="middle" width="120">
                    <font color="#ffffff"><strong>产品货号</strong></font>
                </td>
                <td align="middle" width="120">
                    <strong><font color="#ffffff">产品描述</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">产品尺寸</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">单位</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">币别</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">美金售价</font></strong>
                </td>
                <td align="middle"></td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9">
                        <td align="middle" height="24">
                            <a href="javascript:void(0);" onclick="delOp('<%#Eval("Id") %>',this);" style="color:Blue">删除</a>
                        </td>
                        <td>
                            &nbsp;<%#Eval("SCID")%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("Productid")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("DesChn")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("Size")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("Unit")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("Ccurrency")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("SellPrice")%>
                        </td>
                        <td nowrap>
                            <%#GetImagesItem((string)Eval("PhotoPath"))%>
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
