<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="Enterprise.Web.admin.productlist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <div style="padding:10px 0 10px 10px;">
            <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click">添加产品</asp:LinkButton>
        </div>

        <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" Height="104px" Width="1064px" OnRowDeleting="gvProduct_RowDeleting" OnRowCommand="gvProduct_RowCommand" DataKeyNames="ProductId" CssClass="gvProduct fl">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="产品编号" ReadOnly="True" SortExpression="ProductId" />
                <asp:BoundField DataField="CategoryName" HeaderText="产品分类" SortExpression="Name" />
                <asp:BoundField DataField="Name" HeaderText="产品名称" />
                <asp:TemplateField HeaderText="缩略图" SortExpression="Thumb">
                    <ItemTemplate>
                        <asp:Image ID="imgThumb" runat="server" ImageUrl='<%# Bind("ThumbUrl") %>' />
                    </ItemTemplate>
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Status" HeaderText="状态" />
                <asp:BoundField DataField="Click" HeaderText="点击数" SortExpression="Click" />
                <asp:BoundField DataField="SortIndex" HeaderText="排序" SortExpression="SortIndex" />
                <asp:BoundField DataField="CreateUserId" HeaderText="创建作者" SortExpression="CreateUserId" />
                <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate" />
                <asp:BoundField DataField="UpdateUserId" HeaderText="更新作者" SortExpression="UpdateUserId" />
                <asp:BoundField DataField="UpdateDate" HeaderText="更新时间" SortExpression="UpdateDate" />

                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Bind("ProductId") %>' Text="编辑"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# Bind("ProductId") %>' Text="删除" OnClientClick="return isDelete()"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
    <webdiyer:AspNetPager ID="pageProduct" runat="server" FirstPageText="First" LastPageText="Last" NextPageText="Next" 
        OnPageChanging="pageProduct_PageChanging" PageIndexBoxType="TextBox" PageSize="2" PrevPageText="Prev" ShowPageIndexBox="Always" 
        SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"></webdiyer:AspNetPager>
    <script>
        function isDelete() {
            if (confirm("是否确认删除")) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
