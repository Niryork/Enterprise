<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Enterprise.Web.admin.LogIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.10.2.min.js"></script>
    <style>
        #imgcode{
            min-width:60px;
            min-height:10px;
        }
        .table {
            width: 100%;
            height: 271px;
            border-collapse: collapse;
        }

        .container {
            width: 400px;
            min-height: 270px;
            margin: auto;
        }

        .header {
            height: 40px;
            text-align: center;
            background-color: #d6dbe9;
        }

        .trwidth {
            height: 40px;
            line-height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Login ID="login" runat="server" OnAuthenticate="login_Authenticate" RememberMeText="记住我。" Width="400px" Height="26px" OnLoggingIn="login_LoggingIn" OnLoggedIn="login_LoggedIn" OnLoginError="login_LoginError">
                <LayoutTemplate>
                    <table class="table">
                        <tbody>
                            <tr class="header">
                                <td colspan="2">用户登录</td>
                            </tr>
                            <tr class="trwidth">
                                <td style="text-align: right;">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" Width="140px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="login">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="trwidth">
                                <td style="text-align: right;">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="login">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="trwidth">
                                <td style="text-align: right;">
                                    <asp:Label ID="lblCheckCode" runat="server" AssociatedControlID="CheckCode">验证码:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CheckCode" runat="server" TextMode="SingleLine" Width="60px"></asp:TextBox>
                                  
                                    <img id="imgcode" src="api/ValidatecodeApi.aspx" onclick="freshcode()" />
                                    <asp:RequiredFieldValidator ID="CheckCodeRequired" runat="server" ControlToValidate="CheckCode" ErrorMessage="必须填写“验证码”。" ToolTip="必须填写“验证码”。" ValidationGroup="login">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="记住我。" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; color: Red;" colspan="2">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录" ValidationGroup="login" BackColor="White" BorderColor="White" BorderStyle="Solid" Height="29px" Width="94px" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:Login>

        </div>

    </form>
    <script>
        function freshcode() {
            document.getElementById("imgcode").src = "api/ValidatecodeApi.aspx?_=" + Math.random();
        }
    </script>
</body>
</html>
