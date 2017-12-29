<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Enterprise.Web.admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="width:100%;margin:0;">
        <div style="padding: 10px 0 10px 10px;">
            <div id="add">
                <asp:Button ID="btnAddUser" runat="server" Text="添加用户" BackColor="#57B157" BorderStyle="None" ForeColor="White" Width="70px" Height="24px" OnClick="btnAddUser_Click" />
            </div>
        </div>

        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserId" ForeColor="#333333" GridLines="None" Width="1062px" Height="120px" OnRowCommand="gvUser_RowCommand" OnRowDeleting="gvUser_RowDeleting" Font-Size="Medium">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="用户编号" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="用户名" SortExpression="Username" />
                <asp:BoundField DataField="RealName" HeaderText="真实姓名" SortExpression="RealName" />
                <asp:BoundField DataField="Phone" HeaderText="手机" SortExpression="Phone" />
                <asp:BoundField DataField="UserType" HeaderText="用户类型" SortExpression="UserType" />
                <asp:BoundField DataField="Status" HeaderText="状态" SortExpression="Status" />
                <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate" />
                <asp:TemplateField ShowHeader="False" HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"  CommandArgument='<%# Bind("UserId") %>' Text="编辑"></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" CommandArgument='<%# Bind("UserId") %>' OnClientClick="return isDelete()"></asp:LinkButton>
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
