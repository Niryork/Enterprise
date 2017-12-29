<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Useredit.aspx.cs" Inherits="Enterprise.Web.admin.Useredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table tr{
           height:25px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <table style="border-collapse:collapse; width: 27%;" >
            <tr>
                <td class="tr" style="width: 8em;">用户名：</td>
                <td>
                    <input id="Username" name="Username" value=" " runat="server" />
                    <input id="UserId" name="UserId" type="hidden" runat="server" value="0" />
                </td>
            </tr>
            <tr>
                <td class="tr">真实姓名：</td>
                <td>
                    <input id="RealName" name="RealName" value=" " runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tr">手机号：</td>
                <td>
                    <input id="Phone" name="Phone" value=" " runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tr">用户类型：</td>
                <td>
                    <input runat="server" id="rdoSuper" name="rdoType" type="radio" value="1" />超级管理员
                    <input runat="server" id="rdoNet" name="rdoType" type="radio" value="0" />网络管理员
                </td>
            </tr>
            <tr>
                <td class="tr">是否可用于登陆：</td>
                <td>
                    <input runat="server" id="rdoYes" name="rdoStatus" type="radio" value="1" />是
                    <input runat="server" id="rdoNo" name="rdoStatus" type="radio" value="0" />否
                </td>
            </tr>
            <tr>
                <td colspan="2" class="tr">
                    <asp:Button ID="btnPost" runat="server" Text="提交并返回" OnClick="btnPost_Click" OnClientClick="return checkPost()" Height="24px" Width="81px" BackColor="#FD6440" BorderStyle="None" />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
