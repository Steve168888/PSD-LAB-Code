<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation-Admin.Master" AutoEventWireup="true" CodeBehind="EditArtist.aspx.cs" Inherits="PSDLab.View.EditArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br /><br />
    <asp:Label runat="server" Text="Edit Artist"></asp:Label>
    <br /><br />
    <asp:Label ID="currentLabel" runat="server" Text=""></asp:Label><br />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label><br />
    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label2" runat="server" Text="Image"></asp:Label><br />
    <asp:Image ID="artistImage" runat="server" width="200" height="200"/>
    <asp:FileUpload ID="imageUpload" runat="server"></asp:FileUpload><br />
    <asp:Button ID="uploadBtn" runat="server" Text="Update" OnClick="uploadBtn_Click"/><br />
    <asp:Label ID="uploadStatus" runat="server" Text=""></asp:Label><br />

</asp:Content>
