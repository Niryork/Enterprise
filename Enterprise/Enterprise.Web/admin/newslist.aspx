<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="newslist.aspx.cs" Inherits="Enterprise.Web.admin.newslist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="width: 100%; margin: 0;">
        <div style="padding: 10px 0 10px 10px;">
            <div id="add">
                <asp:Button ID="btnAddUser" runat="server" Text="添加新闻" BackColor="#57B157" BorderStyle="None" ForeColor="White" Width="70px" Height="24px" OnClick="btnAddUser_Click" />
            </div>
        </div>

        <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False" Width="1060px" OnRowDeleting="gvNew_RowDeleting" OnRowCommand="gvNews_RowCommand">
            <Columns>
                <asp:BoundField DataField="NewsId" HeaderText="新闻编号" SortExpression="NewsId" />
                <asp:BoundField DataField="CategoryName" HeaderText="新闻分类" SortExpression="CategoryName" />
                <asp:BoundField DataField="Title" HeaderText="新闻标题" SortExpression="Title" />
                <asp:BoundField DataField="Status" HeaderText="状态" SortExpression="Status" />
                <asp:BoundField DataField="Click" HeaderText="点击数" SortExpression="Click" />
                <asp:BoundField DataField="CreateUser" HeaderText="创建作者" SortExpression="CreateUserId" />
                <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate" />
                <asp:BoundField DataField="UpdateUser" HeaderText="更新用户" SortExpression="UpdateUserId" />
                <asp:BoundField DataField="UpdateDate" HeaderText="更新时间" SortExpression="UpdateDate" />
                <asp:TemplateField ShowHeader="False" HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Bind("NewsId") %>' Text="编辑"></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" CommandArgument='<%# Bind("NewsId") %>' OnClientClick="return isDelete()"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Height="30px" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    <script>
        function isDelete() {
            if (confirm("是否确认删除")) {
                return true;
            }
            return false;
        }
    </script>

</asp:Content>
