<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="HeadControl.ascx" tagname="HeadControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
    <link href="images/Admin_css.css" type="text/css" rel="stylesheet"/>

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
                                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查找" />
                                    </td>
                                    <td><a href="ProductAdd.aspx" target="_blank" style="color:Blue">添加新产品</a>&nbsp;&nbsp;<a href="SalesFooterUploadPic.aspx" style="color:Blue" >上传SalesFooter图片</a></td>
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
                <td align="middle" width="100"></td>
                <td align="middle" width="60">
                    <font color="#ffffff"><strong>类别</strong></font>
                </td>
                <td align="middle" width="100">
                    <font color="#ffffff"><strong>货号</strong></font>
                </td>
                <td align="middle" width="100">
                    <font color="#ffffff"><strong>产品名称</strong></font>
                </td>
                <td align="middle" width="100">
                    <strong><font color="#ffffff">产品尺寸</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">重量(kg)</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">工厂价</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">建议售价</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">工厂库存</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">欣迪库存</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">英冠库存</font></strong>
                </td>
                <td align="middle" width="100">
                    <strong><font color="#ffffff">代理商</font></strong>
                </td>
                <td align="middle" width="80">
                    <strong><font color="Red">汇总</font></strong>
                </td>
                <td align="middle" width="60">
                    <strong><font color="#ffffff">更新时间</font></strong>
                </td>
                <td align="middle" width="80"></td>
                <td align="middle">
                    <strong><font color="#ffffff">备注</font></strong>
                </td>
            </tr>
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#ebf2f9">
                        <td align="middle" height="24">
                            <a href="ProductEdit.aspx?id=<%#Eval("Id") %>" style="color:Blue">修改</a>&nbsp;<a href="javascript:void(0);" onclick="delOp('<%#Eval("Id") %>',this);" style="color:Blue">删除</a>
                            &nbsp;<a onclick="window.open('ReportOut.aspx?a=<%=new System.Random().Next(1, 99999) %>&id=<%#Eval("Id") %>','','dialogHeight: 400px, dialogWidth: 400px,resizable: yes, status: no');" style="color:Blue;">出库</a>
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
                        <td nowrap>
                            &nbsp;<%#Eval("Weight")%>
                        </td>
                        <td style="text-align:right">
                            &nbsp;<%#Eval("PriceFactory")%>
                        </td>
                        <td  style="text-align:right">
                            &nbsp;<%#Eval("PriceSell")%>
                        </td>
                        <td  style="text-align:right">
                            &nbsp;<%#Eval("AmountKc")%>
                        </td>
                        <td  style="text-align:right">
                            &nbsp;<%#Eval("AmountHZ")%>
                        </td>
                        <td  style="text-align:right">
                            &nbsp;<%#Eval("AmountXM")%>
                        </td>
                        <td>
                            &nbsp;<%#Eval("Agent")%>
                        </td>
                        <td nowrap align="right">
                            &nbsp;<%#((decimal)Eval("PriceFactory")*(int)Eval("AmountOut"))%>
                        </td>
                        <td nowrap>
                            &nbsp;<%#((DateTime)Eval("UpdateOn")).ToString("yyyy-MM-dd")%>
                        </td>
                            <td><a onclick="window.showModalDialog('ShowPic.aspx?id=<%#Eval("Id") %>',window,'dialogHeight: 600px; dialogWidth: 700px;resizable: yes; status: no;');" style="color:Blue">浏览图片</a>
                            <%#GetImagesItem((string)Eval("pic")) %></td>
                        <td nowrap>
                            &nbsp;<%#Eval("Remark")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr style="height:25px">
                <td align="middle" width="100"></td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="100">
                </td>
                <td align="middle" width="100">
                </td>
                <td align="middle" width="100">
                </td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="60">
                </td>
                <td align="middle" width="100">
                </td>
                <td align="right" width="80">
                    <%=TotalFee %>
                </td>
                <td>
                </td>
                <td></td>
                <td align="middle">
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="0" width="99%" border="0">
                                            <tr>
                                                <td align="center" style="margin-top:10px;"><br />
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
