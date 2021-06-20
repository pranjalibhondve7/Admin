<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Admin.Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><h1><b>Item Details</b></h1></center>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Category : " Font-Size="Large"></asp:Label>
    <asp:DropDownList ID="ddlcat" CssClass="form-control" runat="server">
        <%--<asp:ListItem>--Select Item--</asp:ListItem>--%>
        <asp:ListItem>Veg</asp:ListItem>
        <asp:ListItem>Non-Veg</asp:ListItem>

    </asp:DropDownList><br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Item : " Font-Size="Large"></asp:Label>
    <asp:TextBox ID="txtitem" CssClass="form-control" runat="server"></asp:TextBox><br />
    <br />
    <center><asp:Button ID="btnsave" CssClass="btn btn-danger" runat="server" Text="Save" OnClick="btnsave_Click" Width="100px" /><br /></center>
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="589px">
        <Columns>

            <asp:BoundField HeaderText="Item_Id" DataField="Menu_Id" />
            <asp:BoundField HeaderText="Cat_Id" DataField="Menu_Category_Id" />
            <asp:BoundField HeaderText="Name" DataField="Menu_Items" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnselect" CssClass="btn btn-primary" runat="server" CommandArgument='<%#Eval("Menu_Id") %>' Text="Select" OnCommand="btnselect_Command" />
                    <asp:Button ID="btndelete" CssClass="btn btn-danger" runat="server" CommandArgument='<%#Eval("Menu_Id") %>' Text="Delete" OnCommand="btndelete_Command" />
                </ItemTemplate>
            </asp:TemplateField>
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
    <br />
    <br />
    <br />
    <div class="container">
        <div class="form-group">
            <div class="card">
                <asp:Label ID="Label3" runat="server" Text="Item Id : " Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtitemid" runat="server" /><br />
                <asp:Label ID="Label4" runat="server" Text="Cat_Id : " Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtid" runat="server" /><br />
                <asp:Label ID="Label5" runat="server" Text="Item Name : " Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtname" runat="server" /><br />
                <asp:Button ID="btnupdate" CssClass="btn btn-info" runat="server" Text="Update" OnClick="btnupdate_Click" />
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [Menu_Id], [Menu_Category_Id], [Menu_Items] FROM [Menu_Item]"></asp:SqlDataSource>
</asp:Content>
