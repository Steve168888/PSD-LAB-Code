﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation-Admin.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="PSDLab.View.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br /><br />
    <asp:Label ID="Label3" runat="server" Text="Insert Artist"></asp:Label><br />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label><br />
    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label2" runat="server" Text="Image"></asp:Label><br />
    <asp:FileUpload ID="imageUpload" runat="server"></asp:FileUpload><br />
    <asp:Button ID="uploadBtn" runat="server" Text="Upload" OnClick="uploadBtn_Click"/><br />
    <asp:Label ID="uploadStatus" runat="server" Text=""></asp:Label><br />
</asp:Content>
