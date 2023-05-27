<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation-Customer.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="PSDLab.View.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br /><br />
    <asp:Label ID="nameLabel" runat="server" Text="Album Name"></asp:Label><br />
    <asp:Image ID="albumImage" runat="server" width="200" height="200"/><br />
    <asp:Label ID="descLabel" runat="server" Text="Album Desc"></asp:Label><br />
    <asp:Label ID="priceLabel" runat="server" Text="Album Price"></asp:Label><br />
    <asp:Label ID="stockLabel" runat="server" Text="Album Stock"></asp:Label><br />
</asp:Content>
