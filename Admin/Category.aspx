<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

    <asp:Label ID="Label1" runat="server" Text="Category : " font-size="18px"></asp:Label>
    <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox><br />

    <center><asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-danger" OnClick="btnsave_Click" /></center><br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="350px" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="Menu_Category_Id" HeaderText="CAT ID" />
            <asp:BoundField DataField="Category_Name" HeaderText="Category Name" />           
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
        </div>
    <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [Menu_Category_Id], [Category_Name] FROM [Menu_Category]"></asp:SqlDataSource>
</asp:Content>
