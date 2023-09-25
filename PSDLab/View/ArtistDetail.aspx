<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation-Customer.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="PSDLab.View.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br /><br />
    
    <asp:Label ID="nameLabel" runat="server" Text="Artist Name"></asp:Label><br />
    <asp:Image ID="artistImage" runat="server" width="200" height="200"/>
    <br /><br />
    <% int artID = getArtistID(); %>
    <% int visitorRole = getVisitorRole(); %>
    <asp:Repeater ID="albumRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span>Album Name : <%# Eval("albumName") %></span><br />
                <asp:Image runat="server" ImageUrl='<%# Eval("albumImage") %>' Width="500px" height="500px"/><br />
                <span>Price : <%# Eval("albumPrice") %></span><br />
        <span>Desc : <%# Eval("albumDesc") %></span><br />
                 <% if (visitorRole == 3) { %>
                <asp:Button Text="Add Cart" ID="AddCart" runat="server" OnClick="AddCart_Click" CommandArgument='<%# Eval("albumId") %>'/>
            <% } %>
                
                <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CommandArgument='<%# Eval("albumId") %>'/>
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
    <br /><br />
    <asp:Button ID="addAlbumBtn" runat="server" Text="Add Album" OnClick="addAlbumBtn_Click"/>

</asp:Content>
