<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Demo_Grid1.aspx.cs" Inherits="Admin.Demo_Grid1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" Height="314px" Width="910px">
        <Columns>
            <asp:TemplateField HeaderText="Sr. No">
                <ItemTemplate>
                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("Menu_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="lbl_catid" runat="server" Text='<%#Eval("Menu_Category_Id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_catid" runat="server" Text='<%#Eval("Menu_Category_Id") %>' Width="100px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:Label ID="lbl_items" runat="server" Text='<%#Eval("Menu_Items") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_items" runat="server" Text='<%#Eval("Menu_Items") %>' Width="100px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                    <asp:Label ID="lbl_rate" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_rate" runat="server" Text='<%#Eval("Price") %>' Width="120px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:Label ID="lbl_dis" runat="server" Text='<%#Eval("Discount") %>' Width="100px"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_dis" runat="server" Text='<%#Eval("Discount") %>' Width="100px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate >
                    
                    <asp:Button ID="btn_Edit" CssClass="btn btn-info" runat="server" Text="Update" CommandName="Edit" />
                    <asp:Button ID="btndelete" CssClass="btn btn-danger" runat="server" Text="Delete" CommandArgument='<%#Eval("Menu_Id") %>' OnCommand="btndelete_Command" />
                </ItemTemplate>
              <EditItemTemplate>
                    <asp:Button ID="btn_Update" CssClass="btn btn-primary" runat="server" Text="Update" CommandName="Update" />
                    <%--<asp:Button ID="btn_Cancel" CssClass="btn btn-danger" runat="server" Text="Cancel" CommandName="Cancel" />--%>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#663300" ForeColor="#ffffff" />
        <RowStyle BackColor="#e7ceb6" />

    </asp:GridView>
</asp:Content>
