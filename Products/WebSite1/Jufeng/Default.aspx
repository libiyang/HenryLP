<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Jufeng_Default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品浏览</title>
    <link href="../images/Admin_css.css" type="text/css" rel="stylesheet"/>
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
    <script language="JavaScript" type="text/javascript">
         function openn(){
          var args = openn.arguments;
          if(args[0] == 0) return;
          location.href=(args[0]);
      }
      function delOp(id,obj) {
          if (confirm("确定删除吗？")) {
              window.open("ProductDel.aspx?id=" + id);
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
                                    <td nowrap>
                                        货号：<asp:TextBox ID="txtHuoHao" runat="server"></asp:TextBox>&nbsp;产品名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;类别：<asp:DropDownList ID="ddlLeibei" runat="server"></asp:DropDownList>
                                        &nbsp;下单状态：<asp:DropDownList ID="ddlState" runat="server">
                                            <asp:ListItem Text="所有状态" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="可下单" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="不可下单" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查找" />
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
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
                <tr>
                    <td>
                    <%=strLeibeiLink %>
                    </td>
                </tr>
        </table>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
            <tr style="height:25px">
                <td align="middle" width="100"></td>
                <td align="middle" width="100"></td>
                <td align="middle" width="60">
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
                <td align="middle" width="120">
                    <strong><font color="#ffffff">销售价</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="#ffffff">更新时间</font></strong>
                </td>
                <td align="middle">
                    <strong><font color="#ffffff"></font></strong>
                </td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="<%#(Container.ItemIndex+1)%2 == 0 ?"#ebf2a9":"#ebf2f9"%>">
                            <td><a href="ShowPic.aspx?id=<%#Eval("Id") %>" style="color:Blue;cursor:pointer" target="_blank">浏览大图</a>
                            <%#GetImagesItem((string)Eval("pic")) %></td>
                        <td align="middle" height="24">
                            
                            <%# GetProductState((DateTime)Eval("UpdateOn"), (int)Eval("Id"))%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("LeiBei")%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("HuoHao") %>
                        </td>
                        <td>
                            &nbsp;<%#Eval("ProductName")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#Eval("Size")%>
                        </td>
                        <td  style="text-align:right">
                            &nbsp;<%#Eval("PriceSell")%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#((DateTime)Eval("UpdateOn")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td nowrap>
                            
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
            <tr>
                <td align="center" style="margin-top: 10px;">
                    <br />
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" OnPageChanging="AspNetPager1_PageChanging"
                        Width="100%" PageIndexBoxStyle="width:19px" FirstPageText="【首頁】" LastPageText="【尾頁】"
                        NextPageText="【下一頁】" PrevPageText="【前一頁】" NumericButtonTextFormatString="【{0}】"
                        TextAfterPageIndexBox="頁" TextBeforePageIndexBox="轉到第" CustomInfoHTML="Page  <font color='red'><b>%CurrentPageIndex%</b></font> of  %PageCount%&nbsp;&nbsp;Order %StartRecordIndex%-%EndRecordIndex%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td height="5">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
