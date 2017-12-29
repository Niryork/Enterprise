<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="newsedit.aspx.cs" Inherits="Enterprise.Web.admin.newsedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/wangEditor/css/wangEditor.min.css" rel="stylesheet" />
    <script src="js/wangEditor/js/wangEditor.min.js"></script></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="margin: 0; width: 100%;">
        <table style="margin-left: 10px; width: 1047px;">
            <tr>
                <td style="width: 70px;">新闻分类:</td>
                <td>
                    <asp:DropDownList ID="ddlCategoryName" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>标题:</td>
                <td>
                    <input id="NewsId" name="NewsId" type="hidden" runat="server" value="0" />
                    <input id="Newstitle" style="width: 220px;" name="Name" value=" " runat="server" />


                </td>
            </tr>
            <tr>
                <td>状态:</td>
                <td>
                    <input runat="server" id="rdoYes" name="rdoStatus" type="radio" value="1" />显示
                    <input runat="server" id="rdoNo" name="rdoStatus" type="radio" value="0" />不显示
                </td>
            </tr>
            <tr>
                <td>内容:</td>
                <td>
                    <div class="content" style="position: relative; margin: 10px 0;">
                        <div id="newsedit" class="editor" style="width: 100%; height: 200px;">
                            <p>Please input content</p>
                        </div>
                        <asp:HiddenField ID="hdContent" runat="server" />

                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="tr">
                    <asp:HiddenField ID="hdUpdateUser" runat="server" />
                    <asp:Button ID="btnPost" runat="server" Text="提交并返回" OnClick="btnPost_Click" OnClientClick="return checkPost()" Height="24px" Width="81px" BackColor="#FD6440" BorderStyle="None" />
                </td>
            </tr>
        </table>
    </div>
    <script>
        var editor = new wangEditor('newsedit');
        editor.config.menus = [
            'source',
            '|',     // '|' 是菜单组的分割线
            'bold',
            'underline',
            'italic',
            'strikethrough',
            'forecolor',
            'bgcolor',
            '|',
            'fontsize',
            'alignleft',
            'aligncenter',
            'alignright',
            '|',
            'img',
            'undo',
            'redo',
            'fullscreen'
        ];


        //上传图片
        // 上传图片
        editor.config.uploadImgUrl = '/admin/api/uploadImgApi.ashx';

        editor.config.uploadImgFileName = 'UploadImg'

        // 自定义上传事件
        editor.config.uploadImgFns.onload = function (resultText, xhr) {
            // resultText 服务器端返回的text
            // xhr 是 xmlHttpRequest 对象，IE8、9中不支持

            // 上传图片时，已经将图片的名字存在 editor.uploadImgOriginalName
            var originalName = editor.uploadImgOriginalName || '';
            // alert(resultText);
            // 如果 resultText 是图片的url地址，可以这样插入图片：
            editor.command(null, 'insertHtml', '<img src="' + resultText + '" alt="' + originalName + '" style="max-width:100%;"/>');
            // 如果不想要 img 的 max-width 样式，也可以这样插入：
            // editor.command(null, 'InsertImage', resultText);
        };


        //创建富文本编辑器
        editor.create();

        //数据初始化
        editor.$txt.html(decodeURIComponent($("#<%=hdContent.ClientID%>").val()));

        function checkPost() {
            var content = encodeURIComponent(editor.$txt.html());
            $("#<%=hdContent.ClientID%>").val(content);
                if (confirm("是否确认提交？")) {
                    return true;
                }

                return false;
        }
    </script>

</asp:Content>
