<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation-Admin.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="PSDLab.View.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br /><br />
    <asp:Label ID="Label3" runat="server" Text="Insert Artist"></asp:Label><br />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label><br />
    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label4" runat="server" Text="Desc"></asp:Label><br />
    <asp:TextBox ID="descBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label><br />
    <asp:TextBox ID="priceBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label6" runat="server" Text="Stock"></asp:Label><br />
    <asp:TextBox ID="stockBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label2" runat="server" Text="Image"></asp:Label><br />
    <asp:FileUpload ID="imageUpload" runat="server"></asp:FileUpload><br />
    <asp:Button ID="uploadBtn" runat="server" Text="Upload" OnClick="uploadBtn_Click"/><br />
    <asp:Label ID="uploadStatus" runat="server" Text=""></asp:Label><br />
</asp:Content>
