<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="Jufeng_ProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
    
    <script type="text/javascript" src="/js/jquery-1.4.4.min.js"></script>

    <link href="/JS/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JS/jquery.uploadify-v2.1.0/swfobject.js"></script>
    <script type="text/javascript" src="/JS/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.js"></script> 
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#uploadify1").uploadify({
                'uploader': '/JS/jquery.uploadify-v2.1.0/uploadify.swf',
                'script': '/UploadFiles2013.aspx',
                'cancelImg': '/JS/jquery.uploadify-v2.1.0/cancel.png',
                'folder': '/UploadFile',
                'queueID': 'fileQueue1',
                'buttonText': 'Upload',
                'sizeLinit': 1024 * 1024 * 2,
                'auto': true,
                'multi': true,
                'onComplete': fun1

            });
            $("#cbSelectAllType").click(function() {
                var cb = $("#cbAgent").find("input[type='checkbox']");
                //alert(cb.length);
                if ($("#cbSelectAllType").attr("checked")) {
                    //alert('全选');
                    cb.attr("checked", "checked");
                }
                else {
                    cb.attr("checked", "");
                }
            });
        });
        function removeDiv(id) {
            $("#div" + id).remove();
            $("#img" + id).remove();
        }
        function fun1(event, queueID, fileObj, response, data) {
            var Image = "<img id='img" + queueID + "' width='216px' src='/PPic2013/" + response + "'/>";
            var Delete = "<a href='javascript:void(0);' onclick=\"javascript:removeDiv('" + queueID + "')\">刪除</a>";
            var Div = "<div id='div" + queueID + "' style='margin-top:5px;text-align:center;width:130px;'>" + Delete + "<input type='hidden' id='himage" + queueID + "' name='himage1' value='" + response + "'/></div>";
            $("#image1").append(Image + Div);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="99%" bgcolor="#6298e1" border="0">
        <tr bgcolor="#ebf2f9"><td style="width:100px">类别</td><td><asp:DropDownList ID="ddlLeibei" runat="server"></asp:DropDownList></td></tr>
        <tr bgcolor="#ebf2f9"><td>货号</td><td><asp:TextBox ID="txtHuoHao" runat="server"></asp:TextBox></td></tr>
        <tr bgcolor="#ebf2f9"><td>产品名称</td><td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td></tr>
        <tr bgcolor="#ebf2f9"><td>产品尺寸</td><td><asp:TextBox ID="txtSize" runat="server"></asp:TextBox></td></tr>
        <tr bgcolor="#ebf2f9"><td>美金价</td><td><asp:TextBox ID="txtPriceFactory" runat="server" Text="0"></asp:TextBox></td></tr>
        <%--<tr bgcolor="#ebf2f9"><td>销售价</td><td><asp:TextBox ID="txtPriceSell" runat="server" Text="0"></asp:TextBox></td></tr>--%>
            <tr bgcolor="#ebf2f9">
                <td>
                    图片
                </td>
                <td>
                    <div id="image1">
                    </div>
                    <div id="fileQueue1">
                    </div>
                    <input type="file" name="uploadify1" id="uploadify1" /><span style="color: Red;
                        font-size: 16px;">您可以同时选择多张上傳圖片。</span>
                </td>
            </tr>
        <tr><td></td><td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="保存" /></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
