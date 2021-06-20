<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add_Item.aspx.cs" Inherits="Admin.Add_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row{
            margin-top:40px;
            margin-bottom:40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><h1><b>Add Items </b></h1></center>
    <div class="container">
        <div class="row form-group">
            <div class="col-md-6">
                <asp:Label ID="Label1" runat="server" Text="Category : " Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlcat" CssClass="form-control" runat="server">
                    <asp:ListItem>--Select Category--</asp:ListItem>
                    <asp:ListItem>1 Veg</asp:ListItem>
                    <asp:ListItem>2 Non-Veg</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="Label2" runat="server" Text="Name : " Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-6">
                <asp:Label ID="Label3" runat="server" Text="Rate : " Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtrate" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="Label4" runat="server" Text="Discount : " Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtdis" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
        <center><asp:Button ID="btnsave" CssClass="btn btn-danger"  runat="server" Text="Save" OnClick="btnsave_Click" /></center>
            </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [Menu_Id], [Menu_Category_Id], [Menu_Items], [Price], [Discount] FROM [Menu_Item]"></asp:SqlDataSource>
</asp:Content>
